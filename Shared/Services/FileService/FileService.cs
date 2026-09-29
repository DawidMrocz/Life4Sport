using Framework.Shared.Attribiutes.Dependency;
using Framework.Shared.Configuration;
using Framework.Shared.Enums;
using Framework.Shared.Models.File;
using Framework.Shared.Services.SettingService;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Framework.Shared.Services.FileService
{
    public interface IFileServiceModels
    {
        public DbSet<FileModel> Files { get; set; }
    }

    public class FileService<TDbContext> : IFileService
        where TDbContext : DbContext, IFileServiceModels
    {
        private readonly TDbContext _dbContext;
        private readonly DbSet<FileModel> _dbSet;
        private readonly ISettingService _settingService;

        public FileService(ISettingService settingService, TDbContext dbContext)
        {
            _settingService = settingService;
            _dbContext = dbContext;
            _dbSet = dbContext.Set<FileModel>();
        }

        public async Task<List<FileModel>> Create(List<IFormFile> files, int? userId = null, string? role = null, long? maxFileSize = null, string[]? allowedExtensions = null, FileStoreOption option = FileStoreOption.Database)
        {
            List<FileModel> createdFiles = new();

            foreach (IFormFile formFile in files.Where(f => f.Length > 0))
                createdFiles.Add(await Create(formFile, userId, role, maxFileSize, allowedExtensions, option));

            return createdFiles;
        }

        public async Task<FileModel> Create(IFormFile formFile, int? userId = null, string? role = null, long? maxFileSize = null, string[]? allowedExtensions = null, FileStoreOption option = FileStoreOption.Database)
        {
            byte[]? content;
            using (Stream stream = formFile.OpenReadStream())
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    content = memoryStream.ToArray();
                }
            }

            if (formFile.Length <= 0) throw new Exception("No file");

            if (maxFileSize is not null)
                if ((formFile.Length / 1024 / 1024) > maxFileSize)
                    throw new Exception($"Max allowed file size is {maxFileSize}Mb");

            if (allowedExtensions is not null)
                if (!allowedExtensions.Select(e => e.ToLower()).Contains(formFile.FileName[(formFile.FileName.LastIndexOf('.') + 1)..].ToLower()))
                    throw new Exception("Not allowed extension");

            FileModel newFileModel = new()
            {
                Name = formFile.FileName,
                Created = DateTime.Now,
                UserId = userId,
                Role = role,
            };

            if (option is FileStoreOption.Database)
            {
                newFileModel.Content = content;
                newFileModel.FileGuid = Guid.NewGuid();
            }
            else
                newFileModel.FileGuid = Guid.NewGuid();

            await _dbSet.AddAsync(newFileModel);

            if (option is FileStoreOption.Local)
                using (var fs = new FileStream(GetFilePath(newFileModel), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                {
                    fs.Write(content, 0, content.Length);
                    fs.Close();
                }

            await _dbContext.SaveChangesAsync();
            return newFileModel;
        }

        public async Task Delete(int fileId)
        {
            FileModel model = await _dbSet.Where(f => f.Id == fileId).FirstOrDefaultAsync()
                 ?? throw new Exception("File not found");

            string path = GetFilePath(model);
            if (!File.Exists(path)) throw new FileNotFoundException($"File not found: {path}");

            if (model.Content is not null) File.Delete(path);

            _dbSet.Remove(model);
            await _dbContext.SaveChangesAsync();
        }

        private static string GetFilePath(FileModel model)
        {
            if (!Directory.Exists(FrameworkConfiguration.SaveFilePath))
                throw new Exception($"Save file path not created");
            DirectoryInfo dir = new(FrameworkConfiguration.SaveFilePath);
            if (!dir.Exists) dir.Create();

            return dir.FullName + Path.DirectorySeparatorChar + $"{model.Id}_{model.FileGuid}_{model.Name}";
        }

        public async Task<FileModel> Get(int fileId)
        {
            FileModel model = await _dbSet.Where(f => f.Id == fileId).FirstOrDefaultAsync()
                 ?? throw new Exception("File not found");

            if (model.Content is not null) return model;

            string path = GetFilePath(model);
            if (!File.Exists(path)) throw new FileNotFoundException($"File not found: {path}");

            model.Content = await File.ReadAllBytesAsync(path);
            return model;
        }
    }
}
