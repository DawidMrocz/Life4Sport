using Framework.Shared.Attribiutes.Dependency;
using Framework.Shared.Models.Template;
using Framework.Shared.Services.SettingService;
using Microsoft.EntityFrameworkCore;

namespace Framework.Shared.Services.EmailService
{
    public interface IEmailServiceModels
    {
        public DbSet<TemplateModel> Templates { get; set; }
    }

    [DependencyInjection(typeof(IEmailService))]
    internal partial class EmailService<TDbContext> : IEmailService
        where TDbContext : DbContext, IEmailServiceModels
    {
        private readonly DbSet<TemplateModel> _dbSet;
        private readonly ISettingService _settingService;

        public EmailService(ISettingService settingService, TDbContext dbContext)
        {
            _settingService = settingService;
            _dbSet = dbContext.Set<TemplateModel>();
        }
    }
}