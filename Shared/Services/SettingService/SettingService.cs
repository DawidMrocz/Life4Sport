using Framework.Shared.Attribiutes.Dependency;
using Framework.Shared.Models.Setting;
using Framework.Shared.Services.EmailService;
using Microsoft.EntityFrameworkCore;

namespace Framework.Shared.Services.SettingService
{
    [DependencyInjection(typeof(ISettingService))]
    internal class SettingService<TDbContext> : ISettingService
        where TDbContext : DbContext, IEmailServiceModels
    {
        private readonly TDbContext _dbContext;
        private readonly DbSet<SettingModel> _dbSet;

        public SettingService(TDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<SettingModel>();
        }
        public async Task<SettingModel?> Get(string key)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.Key == key);
        }
    }
}
