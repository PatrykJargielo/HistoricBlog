using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.DAL.Base
{
    public class GenericResult<T>
    {
        public string Message { get; set; }
        public bool IsVaild { get; set; }
        public T Result { get; set; }
    }
}
