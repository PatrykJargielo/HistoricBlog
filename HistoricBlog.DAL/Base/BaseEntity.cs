using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace HistoricBlog.DAL.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        public abstract List<string> Validation();
    }
}