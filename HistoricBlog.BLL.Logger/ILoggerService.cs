using System;

namespace HistoricBlog.BLL.Logger
{
    public interface ILoggerService
    {
        void Log(string message);
        void Error(Exception exception);
        void Error(string message);
        void Error(string message, Exception exception);

        void Debug(string message);

    }
}
