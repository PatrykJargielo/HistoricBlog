using System.ComponentModel.DataAnnotations;

namespace HistoricBlog.DAL.Entities.BaseEntity
{
    public abstract class BaseId : IBaseId
    {
        [Key]
        public int Id { get; set; }
    }
}
