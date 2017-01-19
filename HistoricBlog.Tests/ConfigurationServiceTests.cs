using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HistoricBlog.DAL.Configs;
using Ploeh.AutoFixture;
using HistoricBlog.BLL.Config;
using HistoricBlog.DAL;
using Moq;

namespace HistoricBlog.Tests
{
    [TestClass]
    public class ConfigurationServiceTests
    {

        [TestMethod]
        public void GetConfig_FromDatabaseIfThereIs()
        {
            //Arrange
            var fixture = new Fixture();
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
            configMock.As<IQueryable<Config>>().Setup(cm => cm.Provider).Returns(configs.Provider);
            configMock.As<IQueryable<Config>>().Setup(cm => cm.Expression).Returns(configs.Expression);
            configMock.As<IQueryable<Config>>().Setup(cm => cm.ElementType).Returns(configs.ElementType);
            configMock.As<IQueryable<Config>>().Setup(cm => cm.GetEnumerator()).Returns(configs.GetEnumerator);

            var historicalBlogDbContextMock = new Mock<HistoricBlogDbContext>();

            historicalBlogDbContextMock.Setup(context => context.Config).Returns(configMock.Object);
            var configRepository = new ConfigRepository(historicalBlogDbContextMock.Object);
            var configService = new ConfigurationService(configRepository);
            
            //Act
           
            //Assert
        }

        [TestMethod]
        public void GetConfig_FromXmlIfThereIsntInDatabase()
        {

        }

     
}
}
