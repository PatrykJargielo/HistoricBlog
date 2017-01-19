using System.ComponentModel.DataAnnotations;

namespace HistoricBlog.WebApi.Models
{
    public abstract class BaseViewModel
    {
        [Key]
        public int Id { get; set; }
    }
}