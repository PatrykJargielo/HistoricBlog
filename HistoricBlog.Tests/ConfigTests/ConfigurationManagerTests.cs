using Microsoft.VisualStudio.TestTools.UnitTesting;
using HistoricBlog.BLL.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace HistoricBlog.BLL.Config.Tests
{
    [TestClass()]
    public class ConfigurationManagerTests
    {
        [TestMethod()]
        public void GetAppSetting_Tests()
        {
            //Arrange
            var key = EKeyConfig.Emailexp.ToString().ToLower();
            var expectedResult = "[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}";
            var configurationManagerMock = new Mock<ConfigurationManager>();

            //Act
            var result = configurationManagerMock.Object.GetAppSetting(key);
            //Assert
            Assert.AreEqual(expectedResult,result);
        }

        [TestMethod()]
        public void GetConnectionString_Tests()
        {
           
        }
    }
}