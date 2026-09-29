using Framework.Shared.Models.Setting;

namespace Framework.Shared.Services.SettingService
{
    public interface ISettingService
    {
        Task<SettingModel?> Get(string key);
    }
}
