using System;

namespace HistoricBlog.BLL.Logger
{
    public class LoggerService : ILoggerService
    {

        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        public void Error(Exception exception)
        {
            _log.Error(exception.Message);
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            _log.Error(message,exception);
        }

        public void Log(string message)
        {
            _log.Info(message);
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }
    }
}
