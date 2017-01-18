using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Configs
{
    public class Config : BaseEntity
    {
        [Required]
        public string ConfigurationKey { get; set; }
        [Required]
        public string ConfigurationValue { get; set; }

        public override List<string> Validation()
        {
            var lista = new List<string>();

            if (string.IsNullOrEmpty(ConfigurationKey))
            {
                lista.Add("Key cannot be empty");

            }
            if (string.IsNullOrEmpty(ConfigurationValue))
            {
                lista.Add("Value cannot be empty");
            }
            return lista;
        }
    }
}
