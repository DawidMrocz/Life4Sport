using Framework.Shared.Configuration;
using Framework.Shared.Enums;
using Framework.Shared.Models.File;
using Framework.Shared.Models.User;
using Framework.Shared.Requests.User;
using System.Data;
using System.Security.Cryptography;

namespace Framework.Identity.Services.User
{
    internal partial class UserService
    {
        public async Task Register(RegisterDto request)
        {
            UserModel? userInDb = await GetByLoginOrEmail(request.Email);

            if (userInDb is not null) throw new Exception("User already exists");

            UserModel model = new()
            {
                Email = request.Email,
                Login = request.Login,
                Block = new Block(),
                Role = RoleEnum.User.ToString(),
                Address = new Address()
                {
                    PostalCode = request.PostalCode,
                    City = request.City,
                    Street = request.Street,
                    Country = request.Country,
                }
            };

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            model.Password = new Password()
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            if (request.ProfilePhoto is not null)
            {
                FileModel createdFile = await _fileService.Create(request.ProfilePhoto);
                model.Files.Photo = createdFile.Id;
            }

            if (request.Files.Any())
            {
                List<FileModel> createdFiles = await _fileService.Create(request.Files);
                model.Files.Documents.AddRange(createdFiles.Select(f => f.Id));
            }

            await _identityDbContext.Users.AddAsync(model);
            await _identityDbContext.SaveChangesAsync();

            _messageProducer.SendMessage(model, FrameworkConfiguration.RabbitMQ_Host, "UserRegistration");

        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
