using Framework.Shared.Models.File;
using Framework.Shared.Models.Token;
using Framework.Shared.Models.User;
using Framework.Shared.Requests.User;
using Framework.Shared.Services.FileService;
using Framework.Shared.Services.LoggerService;
using Framework.Shared.Services.SettingService;
using Framework.Shared.Services.User;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Framework.Identity.Services.User
{
    public interface IUserServiceModels
    {
        public DbSet<TokenModel> Tokens { get; set; }
        public DbSet<FileModel> Files { get; set; }
    }

    internal partial class UserRepository<TDbContext, TModel> : IUserRepository<TModel>
        where TDbContext : DbContext, IUserServiceModels
        where TModel : UserBaseModel
    {
        private readonly TDbContext _dbContext;
        private readonly DbSet<TModel> _dbSet;
        private readonly ILogger _logger;
        private readonly ISettingService _settingService;
        private readonly IFileService _fileService;

        public UserRepository(ILogger logger, ISettingService settingService, IFileService fileService, TDbContext dbContext)
        {
            _logger = logger;
            _settingService = settingService;
            _fileService = fileService;
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TModel>();
        }


        public async Task<int> Register(TModel model, RegisterDto request)
        {
            (byte[], byte[]) result = CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            model.PasswordHash = result.Item2;
            model.PasswordSalt = result.Item1;

            if (request.ProfilePhoto is not null)
            {
                FileModel createdFile = await _fileService.Create(request.ProfilePhoto);
                //model.Photo = createdFile.Id;
            }

            if (request.Files.Any())
            {
                List<FileModel> createdFiles = await _fileService.Create(request.Files);
                //model.Documents.AddRange(createdFiles.Select(f => f.Id));
            }

            await _dbSet.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model.Id;
        }

        private static (byte[], byte[]) CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return (passwordSalt, passwordHash);
        }



  

        public async Task<TModel> Register(TModel model)
        {
            await _dbSet.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }
  
    }
}
