using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HistoricBlog.BLL.Config;
using HistoricBlog.DAL;
using HistoricBlog.DAL.Configs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;
using HistoricBlog.BLL.Logger;

namespace HistoricBlog.Tests.ConfigTests
{
    [TestClass]
    public class ConfigurationServiceTests
    {
        private readonly Mock<HistoricBlogDbContext> _historicalBlogDbContextMock = new Mock<HistoricBlogDbContext>();
        private ConfigRepository _configRepository;
        private readonly ConfigurationManager _configurationManager  = new ConfigurationManager();
        private readonly Mock<LoggerService> _loggerServiceMock = new Mock<LoggerService>();

        [TestMethod]
        public void GetConfig_EmailRegexp_FromDatabaseIfThereIs()
        {
            //Arrange
            var fixture = new Fixture();
            var emailKey = EKeyConfig.Emailexp;
            var emailRegexp = fixture.Create<string>();
            var loginRegexp = fixture.Create<string>();
            var passwordRegexp = fixture.Create<string>();
            var credentialRegexp = fixture.Create<string>();
            
            var configs = new List<Config>
            {
                fixture.Build<Config>()
                    .With(c => c.ConfigurationKey, EKeyConfig.Emailexp.ToString().ToLower())
                    .With(c => c.ConfigurationValue, emailRegexp)
                    .Create(),
                fixture.Build<Config>()
                    .With(c => c.ConfigurationKey, EKeyConfig.Loginexp.ToString().ToLower())
                    .With(c => c.ConfigurationValue, loginRegexp)
                    .Create(),
                fixture.Build<Config>()
                    .With(c => c.ConfigurationKey, EKeyConfig.Passwordexp.ToString().ToLower())
                    .With(c => c.ConfigurationValue, passwordRegexp)
                    .Create(),
                fixture.Build<Config>()
                    .With(c => c.ConfigurationKey, EKeyConfig.Credentialsexp.ToString().ToLower())
                    .With(c => c.ConfigurationValue, credentialRegexp)
                    .Create()
            }.AsQueryable();

            var configMock = new Mock<DbSet<Config>>();
            SetupDbSetConfig(configMock, configs);
            SetupDbContext(configMock);

            _configRepository = new ConfigRepository(_historicalBlogDbContextMock.Object);
            var configService = new ConfigurationService(_configRepository, _configurationManager);

            configService.LoggerService = _loggerServiceMock.Object;
            //Act
            var result = configService.GetConfig(emailKey);
            //Assert
            Assert.AreEqual(result.Result,configs.First().ConfigurationValue);
        }

        [TestMethod]
        public void GetConfig_EmailRegexp_FromXmlIfThereIsntInDatabase()
        {
            //Arrange
            var fixture = new Fixture();
            var emailKey = EKeyConfig.Emailexp;
            var expectedResult = "[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}";
            var configs = new List<Config>().AsQueryable();

            var configMock = new Mock<DbSet<Config>>();

            SetupDbSetConfig(configMock, configs);
            
            SetupDbContext(configMock);
           
            var configRepository = new ConfigRepository(_historicalBlogDbContextMock.Object);
            var configService = new ConfigurationService(configRepository,_configurationManager);
            configService.LoggerService = _loggerServiceMock.Object;
            
            //Act
            var result = configService.GetConfig(emailKey);

            //Assert
            Assert.AreEqual(result.Result, expectedResult);
        }

        private void SetupDbSetConfig(Mock<DbSet<Config>> configSetMock, IQueryable<Config> configsQueryable )
        {
            configSetMock.As<IQueryable<Config>>().Setup(cm => cm.Provider).Returns(configsQueryable.Provider);
            configSetMock.As<IQueryable<Config>>().Setup(cm => cm.Expression).Returns(configsQueryable.Expression);
            configSetMock.As<IQueryable<Config>>().Setup(cm => cm.ElementType).Returns(configsQueryable.ElementType);
            configSetMock.As<IQueryable<Config>>().Setup(cm => cm.GetEnumerator()).Returns(configsQueryable.GetEnumerator());
        }

        private void SetupDbContext(Mock<DbSet<Config>> configSetMock)
        {
            _historicalBlogDbContextMock.Setup(context => context.Config).Returns(configSetMock.Object);
            _historicalBlogDbContextMock.Setup(context => context.Set<Config>()).Returns(configSetMock.Object);
        }
    }
}
