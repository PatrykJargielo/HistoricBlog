using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HistoricBlog.BLL.Base;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.BLL.Config
{
    public interface IConfigurationService
    {
        //GetRegexConfig(string emailregex)
        //{
            
        //}

        GenericResult<string> GetConfig(EKeyConfig key);


    }
}
