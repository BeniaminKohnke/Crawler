using System.Data.SqlClient;

namespace Crawler.CrawlerFiles
{
    internal static class DataAccess
    {
        public static void SaveProduct(int shopId, Product product)
        {
            File.AppendAllText(@"C:\Users\benia\Desktop\urls.txt", product.Url + "\n");
        }

        public static int GetShopIdFromUrl(string url)
        {
            return 0;
        }

        public static void SaveLog(Logger.LogLevel level, string message, string memberName)
        {

        }
    }
}
