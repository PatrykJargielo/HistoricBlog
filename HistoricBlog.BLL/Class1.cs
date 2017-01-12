using HistoricBlog.BLL.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.BLL
{
    public class Class1
    {
        private ILoggerService _loggerServicel;

        public Class1( ILoggerService logger)
        {
            _loggerServicel = logger;
        }

        public void Test()
        {
            _loggerServicel.Log("Metoda testujaca");
        }
    }
}
