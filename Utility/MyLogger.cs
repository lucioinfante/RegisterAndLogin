using System;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Utility
{
    public class MyLogger : ILogger
    {
        // singleton design pattern.
        private static MyLogger instance;
        private static Logger logger;
        public static MyLogger GetInstance() {
            if (instance == null)
                instance = new MyLogger();
            return instance;
        }
        private Logger GetLogger() {
            if (MyLogger.logger == null)
                MyLogger.logger = LogManager.GetLogger("LoginAppLoggerrule");
            return MyLogger.logger;
        }

        public void Debug(string message)
        {
            GetLogger().Debug(message);
        }
        public void Error(string message)
        {
            GetLogger().Error(message);
        }
        public void Info(string message)
        {
            GetLogger().Info(message);
        }
        public void Warning(string message)
        {
            GetLogger().Warn(message);
        }
    }
}
