using Framework.Shared.Enums;
using Framework.Shared.Models.User;
using Framework.Shared.Requests.User;
using System.Security.Cryptography;

namespace Framework.Shared.Extensions.Mappings.User
{
    public static class ToUserModelExtension
    {
        public static UserModel ToUserModel(this RegisterDto request)
        {
            UserModel model = new()
            {

                Email =request.Email,

                Block = new Block(),
                Role = RoleEnum.User.ToString()
            };

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            model.Password.PasswordHash = passwordHash;
            model.Password.PasswordSalt = passwordSalt;

            if (request.ProfilePhoto is not null)
                Console.WriteLine("Dodanie pliku");

            return model;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static void AddFile(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
