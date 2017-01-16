using System.Collections.Generic;

namespace HistoricBlog.DAL.Base
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        List<string> Validation();
    }
}