using Framework.Shared.Attribiutes.Dependency;
using Framework.Shared.Configuration;
using Framework.Shared.Data;
using Framework.Shared.Enums;
using Framework.Shared.Models.File;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Framework.Shared.Services.FileService
{
    [DependencyInjection(typeof(IFileService))]
    internal class FileService : IFileService
    {
        private readonly FrameworkDbContext _sharedDbContext;
        public FileService(FrameworkDbContext sharedDbContext) => _sharedDbContext = sharedDbContext;

        public async Task<List<FileModel>> Create(List<IFormFile> files, long? maxFileSize = null, string[]? allowedExtensions = null, FileStoreOption option = FileStoreOption.Database)
        {
            List<FileModel> createdFiles = new();

            foreach (IFormFile formFile in files.Where(f => f.Length > 0))
                createdFiles.Add(await Create(formFile, maxFileSize, allowedExtensions, option));

            return createdFiles;
        }

        public async Task<FileModel> Create(IFormFile formFile, long? maxFileSize = null, string[]? allowedExtensions = null, FileStoreOption option = FileStoreOption.Database)
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
            };

            if (option is FileStoreOption.Database)
                newFileModel.Content = content;
            else
                newFileModel.FileGuid = Guid.NewGuid();

            await _sharedDbContext.Files.AddAsync(newFileModel);

            if (option is FileStoreOption.Local)
                using (var fs = new FileStream(GetFilePath(newFileModel), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                {
                    fs.Write(content, 0, content.Length);
                    fs.Close();
                }

            await _sharedDbContext.SaveChangesAsync();
            return newFileModel;
        }

        public async Task Delete(int fileId)
        {
            FileModel model = await _sharedDbContext.Files.Where(f => f.Id == fileId).FirstOrDefaultAsync()
                 ?? throw new Exception("File not found");

            string path = GetFilePath(model);
            if (!File.Exists(path)) throw new FileNotFoundException($"File not found: {path}");

            if (model.FileGuid is not null) File.Delete(path);

            _sharedDbContext.Files.Remove(model);
            await _sharedDbContext.SaveChangesAsync();
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
            FileModel model = await _sharedDbContext.Files.Where(f => f.Id == fileId).FirstOrDefaultAsync()
                 ?? throw new Exception("File not found");

            if (model.FileGuid is not null) return model;

            string path = GetFilePath(model);
            if (!File.Exists(path)) throw new FileNotFoundException($"File not found: {path}");

            model.Content = await File.ReadAllBytesAsync(path);
            return model;
        }
    }
}
