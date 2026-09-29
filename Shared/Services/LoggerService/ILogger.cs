using log4net.Core;

namespace Framework.Shared.Services.LoggerService
{
    public interface ILogger
    {
        void Log(Type type, Level logType, string message, Exception ex);
    }
}
