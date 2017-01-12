using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.BLL.Logger
{
    class LoggerService : ILoggerService
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
            throw new NotImplementedException();
        }
    }
}
