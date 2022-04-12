using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Text.RegularExpressions;

namespace Crawler.CrawlerFiles
{
    internal sealed class Algorithm
    {
        public string Url { get; set; } = string.Empty;
        public string StartingUrl { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public string Regex { get; set; } = string.Empty;

        public bool IsRunning { get; private set; } = false;
        private readonly TimeSpan _delay = new(0, 0, 1);

        private readonly IWebDriver _edgeDriver = new EdgeDriver();

        ~Algorithm()
        {
            _edgeDriver.Close();
            _edgeDriver.Quit();
        }

        //@$"https://store.steampowered.com/search/results/?query&start={x*50}&count=50&dynamic_data=&snr=1_7_7_230_7&infinite=1" <-- api
        //https://store.epicgames.com/pl/browse?sortBy=releaseDate&sortDir=DESC&count=40
        //regex: ^https://store.epicgames.com/pl/p/\S+$
        ////a[@role='link' and @aria-label and not(@id)]
        //needs expansion
        public void CrawlPage()
        {
            IsRunning = true;
            var productRegex = new Regex(Regex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var urlQueue = new Queue<string>();
            var urlsToSkip = new List<string>();
            var shopId = DataAccess.GetShopIdFromUrl(Url);
            urlQueue.Enqueue(StartingUrl);

            while(urlQueue.TryDequeue(out var nextUrl) && IsRunning)
            {
                _edgeDriver.Navigate().GoToUrl(nextUrl);
                urlsToSkip.Add(nextUrl);

                var pageNodes = _edgeDriver.FindElements(By.XPath("//a"));
                foreach (var node in pageNodes)
                {
                    try
                    {
                        var newUrl = node.GetAttribute("href");
                        if (newUrl != null)
                        {
                            if(newUrl.Contains(Domain))
                            {
                                if (newUrl[0] == '/')
                                {
                                    newUrl = Url + newUrl;
                                }

                                if (productRegex.IsMatch(newUrl))
                                {
                                    var product = GetProductFromNode(node, newUrl);
                                    if (product != null)
                                    {
                                        DataAccess.SaveProduct(shopId, product);
                                    }
                                    urlsToSkip.Add(newUrl);
                                }

                                if (!urlsToSkip.Contains(newUrl))
                                {
                                    Logger.Log(Logger.LogLevel.INFO, $"Algorithm found: {newUrl}");
                                    urlQueue.Enqueue(newUrl);
                                    urlsToSkip.Add(newUrl);
                                }
                            }
                            urlsToSkip.Add(newUrl);
                        }
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(_delay);
            }
            IsRunning = false;
        }

        private Product? GetProductFromNode(IWebElement htmlNode, string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                return new(string.Empty, url, string.Empty);
            }

            return null;
        }

        public void AbortCurrentAction()
        {
            IsRunning = false;
        }
    }
}
