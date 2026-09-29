using Framework.Shared.Attribiutes.Dependency;
using Framework.Shared.Data;
using Framework.Shared.MessageBroker.RabbitMQ;
using Framework.Shared.Models.User;
using Framework.Shared.Requests.User;
using Framework.Shared.Services.FileService;
using Framework.Shared.Services.LoggerService;
using Framework.Shared.Services.SettingService;
using Framework.Shared.Services.User;
using MassTransit;

namespace Framework.Identity.Services.User
{
    [DependencyInjection(typeof(IUserService))]
    internal partial class UserService : IUserService
    {
        private readonly FrameworkDbContext _identityDbContext;
        private readonly ILogger _logger;
        private readonly ISettingService _settingService;
        private readonly IFileService _fileService;
       // private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMessageProducer _messageProducer;

        public UserService(ILogger logger, ISettingService settingService, IFileService fileService, FrameworkDbContext identityDbContext, IMessageProducer messageProducer)
        {
            _logger = logger;
            _settingService = settingService;
            _fileService = fileService;
            _identityDbContext = identityDbContext;
           // _publishEndpoint = publishEndpoint;
            _messageProducer = messageProducer;
        }

        public Task Block(int userId)
        {
            throw new NotImplementedException();
        }

        public Task ChangePassword(ChangePasswordDto request)
        {
            throw new NotImplementedException();
        }

        public Task ChangeRole(string role)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int userId)
        {
            throw new NotImplementedException();
        }



        public Task<UserModel?> Profile()
        {
            throw new NotImplementedException();
        }



        public Task RemindPassword(string email)
        {
            throw new NotImplementedException();
        }

        public Task Update(params object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
