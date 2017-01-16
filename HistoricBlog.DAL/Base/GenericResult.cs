using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.DAL.Base
{
    public class GenericResult<T>
    {
        public bool IsVaild { get; set; }
        public T Result { get; set; }
        public List<string> Messages { get; set; }

        public void AssignResult(T entity)
        {
            if(IsVaild) Result = entity;
        }
    }
}
