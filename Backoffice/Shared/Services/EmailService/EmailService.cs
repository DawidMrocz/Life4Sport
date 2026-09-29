using Framework.Shared.Attribiutes.Dependency;
using Framework.Shared.Data;
using Framework.Shared.Services.EmailService;

namespace Shared.Services.EmailService
{
    [DependencyInjection(typeof(IEmailService))]
    internal partial class EmailService : IEmailService
    {
        private readonly FrameworkDbContext _frameworkDbContext;

        public EmailService(FrameworkDbContext sharedDbContext)
        {
            _frameworkDbContext = sharedDbContext ?? throw new Exception("SharedDbContext not found");
        }
    }
}
//dotnet ef database update --verbose --project CommandService.Data   --startup-project CommandService