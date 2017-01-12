using System.ComponentModel.DataAnnotations;

namespace HistoricBlog.DAL.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
