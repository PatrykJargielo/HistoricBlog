using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HistoricBlog.DAL.Configs;
using static System.Configuration.ConfigurationManager;
using HistoricBlog.DAL.Base;
using HistoricBlog.BLL.Logger;

namespace HistoricBlog.BLL.Config
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly ConfigRepository _configRepository;
        public ILoggerService LoggerService { get; set; }


        public ConfigurationService(ConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }
        public GenericResult<string> GetConfig(EKeyConfig key)
        {
            var genericResult = new GenericResult<string>();
            string keyString = Convert.ToString(key).ToLower();
            //pobieram z bazy wartosc by klucz

            var genericResultByDb = _configRepository.GetAll(x => x.ConfigurationKey == keyString);
            //sprawdzam warunek czy wartosc jest pobrana, jezeli jest true to zwracam ta wartosc
            if (genericResultByDb.Result.Any())
            {

                genericResult.Result = genericResultByDb.Result.First().ConfigurationValue;
                genericResult.IsVaild = true;
                return genericResult;
            }
            //nie ma wartosci w bazie to sprawdzam w webconfig
            var keyFromWebConfig = AppSettings[keyString];
            //jezeli wartosc web.configa jest pobrana to zwracam ja
            if (!string.IsNullOrEmpty(keyFromWebConfig))
            {
                genericResult.IsVaild = true;
                genericResult.Result = keyFromWebConfig;
                return genericResult;
            }
            //zlogowac blad log.error nie pobrano wartosci ani z bazy ani z webconfig
            LoggerService.Error("Couldnt withdraw information from database and web.config");
            //return GenericResult<string>
            return genericResult;
        }



    }

}
