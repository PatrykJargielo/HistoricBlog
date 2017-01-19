using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HistoricBlog.DAL.Configs;
using HistoricBlog.DAL.Base;
using HistoricBlog.BLL.Logger;

namespace HistoricBlog.BLL.Config
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigRepository _configRepository;
        private readonly IConfigurationManager _configurationManager;
        public ILoggerService LoggerService { get; set; }


        public ConfigurationService(IConfigRepository configRepository, IConfigurationManager configurationManager)
        {
            _configRepository = configRepository;
            _configurationManager = configurationManager;
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
            var keyFromWebConfig = _configurationManager.GetAppSetting(keyString);
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
