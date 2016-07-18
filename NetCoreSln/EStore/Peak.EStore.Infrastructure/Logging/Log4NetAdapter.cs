using log4net.Config;
using Peak.EStore.Infrastructure.Configuration;

namespace Peak.EStore.Infrastructure.Logging
{
    public class Log4NetAdapter : ILogger
    {
        private readonly log4net.ILog _log;
        public Log4NetAdapter()
        {
            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(ApplicationSettingsFactory.GetApplicationSettings().LoggerName);
        }
        public void Log(string message)
        {
            _log.Info(message);
        }
    }
}