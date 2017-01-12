using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.BLL.Logger
{
    public interface ILoggerService
    {
        void Log(string message);
        void Error(Exception exception);
        void Error(string message);
        void Error(string message, Exception exception);

    }
}
