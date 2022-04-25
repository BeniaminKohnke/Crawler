using Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrawlerTests
{
    [TestClass]
    public class DataAccessTest
    {
        [TestMethod]
        public void DownloadFileTest()
        {
            //DataAccess.DownloadFile();
        }

        [TestMethod]
        public void ConfigurationTest()
        {
            DataAccess.DownloadConfiguration();
        }

        [TestMethod]
        public void SaveProductTest()
        {
            var product = new Product("AAAA", "AAAA", "SSSS");

            DataAccess.SaveProduct(product);
        }
    }
}