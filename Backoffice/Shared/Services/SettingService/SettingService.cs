using Framework.Shared.Attribiutes.Dependency;
using Framework.Shared.Data;
using Framework.Shared.Models.Setting;
using Microsoft.EntityFrameworkCore;

namespace Framework.Shared.Services.SettingService
{
    [DependencyInjection(typeof(ISettingService))]
    internal class SettingService : ISettingService
    {
        private readonly FrameworkDbContext _sharedDbContext;

        public SettingService(FrameworkDbContext sharedDbContext)
        {
            _sharedDbContext = sharedDbContext;
        }
        public async Task<SettingModel?> Get(string key)
        {
            return await _sharedDbContext.Settings.FirstOrDefaultAsync(s => s.Key == key);
        }
    }
}
