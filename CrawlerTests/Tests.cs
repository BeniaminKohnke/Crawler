using Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CrawlerTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod, TestCategory("DataAccessTest")]
        public void DownloadConfigurationTest()
        {
            var confFile = DataAccess.DownloadConfiguration("TEST");

            Assert.IsNotNull(confFile);
        }

        [TestMethod, TestCategory("DataAccessTest")]
        public void DownloadConfigurationWrongDataTest()
        {
            var confFile = DataAccess.DownloadConfiguration("XYZ");

            Assert.IsNull(confFile);
        }

        [TestMethod, TestCategory("DataAccessTest")]
        public void DownloadConfigurationCheckIfDataIsCorrectTest()
        {
            var confFile = DataAccess.DownloadConfiguration("TEST");

            Assert.AreEqual(confFile?.ConfigurationName, "TEST");
        }

        [TestMethod, TestCategory("DataAccessTest")]
        public void SaveProductTest()
        {
            var product = new Product("TEST", "TEST@TEST.TEST", "TEST", 10, 10);

            DataAccess.SaveProduct("TEST", product);
        }

        [TestMethod, TestCategory("DataAccessTest")]
        public void GetConfigurationsExistingCongigurationTest()
        {
            var configs = DataAccess.GetConfigurations();

            Assert.IsTrue(configs.Contains("TEST"));
        }

        [TestMethod, TestCategory("DataAccessTest")]
        public void GetConfigurationsNonExistingCongigurationTest()
        {
            var configs = DataAccess.GetConfigurations();

            Assert.IsFalse(configs.Contains(string.Empty));
        }

        [TestMethod, TestCategory("LoggerTest")]
        public void LogTest()
        {
            try
            {
                var name = ((Product)null).Name;
            } 
            catch(NullReferenceException e)
            {
                Logger.Log(Logger.LogLevel.INFO, "TEST_LOG", "TEST", e);
            }

            Assert.IsTrue(Logger.TryGetLog(out var log));
        }

        [TestMethod, TestCategory("LoggerTest")]
        public void LogCheckIfCorrectDataTest()
        {
            try
            {
                var name = ((Product)null).Name;
            }
            catch (NullReferenceException e)
            {
                Logger.Log(Logger.LogLevel.INFO, "TEST_LOG", "TEST", e);
            }

            Logger.TryGetLog(out var log);
            Assert.IsTrue(log.Contains("TEST_LOG"));
        }

        [TestMethod, TestCategory("LoggerTest")]
        public void TryGetLogWithoutLogsTest()
        {
            Assert.IsFalse(Logger.TryGetLog(out var log));
            Assert.IsNull(log);
        }

        [TestMethod, TestCategory("CrawlerConfigurationMethodsTest")]
        public void GetValidatorNameForRegexTest()
        {
            Assert.AreEqual("REGEX", CrawlerConfigurationMethods.GetValidatorName(CrawlerConfigurationMethods.ValidatorType.REGEX));
        }

        [TestMethod, TestCategory("CrawlerConfigurationMethodsTest")]
        public void GetValidatorNameForCSSSelectorTest()
        {
            Assert.AreEqual("CSS_SELECTOR", CrawlerConfigurationMethods.GetValidatorName(CrawlerConfigurationMethods.ValidatorType.CSS_SELECTOR));
        }

        [TestMethod, TestCategory("CrawlerConfigurationMethodsTest")]
        public void GetValidatorNameForXPathTest()
        {
            Assert.AreEqual("XPATH", CrawlerConfigurationMethods.GetValidatorName(CrawlerConfigurationMethods.ValidatorType.XPATH));
        }

        [TestMethod, TestCategory("CrawlerConfigurationMethodsTest")]
        public void GetValidatorNameForNoneTest()
        {
            Assert.AreEqual(string.Empty, CrawlerConfigurationMethods.GetValidatorName(CrawlerConfigurationMethods.ValidatorType.NONE));
        }

        [TestMethod, TestCategory("CrawlerConfigurationMethodsTest")]
        public void GetValidatorTypeForRegexTest()
        {
            Assert.AreEqual(CrawlerConfigurationMethods.ValidatorType.REGEX, CrawlerConfigurationMethods.GetValidatorType("REGEX"));
        }

        [TestMethod, TestCategory("CrawlerConfigurationMethodsTest")]
        public void GetValidatorTypeForCSSSelectorTest()
        {
            Assert.AreEqual(CrawlerConfigurationMethods.ValidatorType.CSS_SELECTOR, CrawlerConfigurationMethods.GetValidatorType("CSS_SELECTOR"));
        }

        [TestMethod, TestCategory("CrawlerConfigurationMethodsTest")]
        public void GetValidatorTypeForXPathTest()
        {
            Assert.AreEqual(CrawlerConfigurationMethods.ValidatorType.XPATH, CrawlerConfigurationMethods.GetValidatorType("XPATH"));
        }

        [TestMethod, TestCategory("CrawlerConfigurationMethodsTest")]
        public void GetValidatorTypeForNoneTest()
        {
            Assert.AreEqual(CrawlerConfigurationMethods.ValidatorType.NONE, CrawlerConfigurationMethods.GetValidatorType(string.Empty));
        }
    }
}