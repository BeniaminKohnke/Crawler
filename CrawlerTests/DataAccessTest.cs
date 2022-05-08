using Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrawlerTests
{
    [TestClass]
    public class DataAccessTest
    {
        [TestMethod]
        public void ConfigurationTest()
        {
            DataAccess.DownloadConfiguration("TEST");
        }

        [TestMethod]
        public void SaveProductTest()
        {
            var product = new Product("TEST", "TEST@TEST.TEST", "TEST", 10, 10);

            DataAccess.SaveProduct("TEST", product);
        }
    }
}