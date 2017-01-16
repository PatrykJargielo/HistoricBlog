using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HistoricBlog.Web.ViewModels
{
    public abstract class BaseViewModel
    {
        [Key]
        public int Id { get; set; }
    }
}