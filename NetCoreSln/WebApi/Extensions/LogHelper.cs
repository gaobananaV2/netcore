using System;
using log4net;
using log4net.Config;

[assembly: XmlConfigurator(ConfigFile = @"Config/log4net.config", Watch = true)] 
namespace WebApi.Extensions
{
    public static class LogHelper
    {
        static readonly ILog Loginfo = LogManager.GetLogger("loginfo");
        static readonly ILog Logerror = LogManager.GetLogger("logerror");
        
        public static void Error(string errorMsg, Exception ex = null)
        {
            if (ex != null)
            {
                Logerror.Error(errorMsg, ex);
            }
            else
            {
                Logerror.Error(errorMsg);
            }
        }

        public static void Info(string msg)
        {
            Loginfo.Info(msg);
        }

    }
}
