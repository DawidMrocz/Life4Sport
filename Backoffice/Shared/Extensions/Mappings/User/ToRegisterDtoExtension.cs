using Framework.Shared.ApiModels.User.Request;
using Framework.Shared.Requests.User;

namespace Framework.Shared.Extensions.Mappings.User
{
    public static class ToRegisterDtoExtension
    {
        public static RegisterDto ToRegisterDto(this RegisterRequest request)
        {
            return new RegisterDto
               (
                   request.Email,
                   request.Login,
                   request.FirstName,
                   request.LastName,
                   request.BirthDate,
                   request.Password,
                   request.Gender,
                   request.Phone,
                   request.ProfilePhoto
               );
        }
    }
}