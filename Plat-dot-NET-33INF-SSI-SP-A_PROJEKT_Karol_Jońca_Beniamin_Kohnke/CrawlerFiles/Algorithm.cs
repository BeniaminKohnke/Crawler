using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Text.RegularExpressions;

namespace Crawler.CrawlerFiles
{
    internal sealed class Algorithm
    {
        public bool IsRunning { get; private set; } = false;
        private readonly TimeSpan _timeout = new(0,10,0);
        private readonly TimeSpan _delay = new(0, 0, 1);
        private DateTime _timeoutStart;

        private readonly IWebDriver _edgeDriver = new EdgeDriver();

        ~Algorithm()
        {
            _edgeDriver.Close();
            _edgeDriver.Quit();
        }

        //@$"https://store.steampowered.com/search/results/?query&start={x*50}&count=50&dynamic_data=&snr=1_7_7_230_7&infinite=1" <-- api
        //https://store.epicgames.com/pl/browse?sortBy=releaseDate&sortDir=DESC&count=40
        //regex: ^https://store.epicgames.com/pl/p/\S+$
        //needs expansion
        public void CrawlPage(string url, string domain, string regex)
        {
            IsRunning = true;
            var productRegex = new Regex(regex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            _timeoutStart = DateTime.Now;
            var urlQueue = new Queue<string>();
            var urlsToSkip = new List<string>();
            var shopId = DataAccess.GetShopIdFromUrl(url);
            urlQueue.Enqueue(url);

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
                            if(newUrl.Contains(domain))
                            {
                                if (newUrl[0] == '/')
                                {
                                    newUrl = "https://store.epicgames.com" + newUrl;
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
                                    urlQueue.Enqueue(newUrl);
                                }
                            }
                            else
                            {
                                urlsToSkip.Add(newUrl);
                            }
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
            //var url = htmlNode.GetAttribute("href");

            if (!string.IsNullOrEmpty(url))
            {
                return new(string.Empty, url, string.Empty);
            }

            return null;
        }

        private bool CheckTimeout(bool reset = false)
        {
            if(!reset)
            {
                return DateTime.Now - _timeoutStart > _timeout;
            }
            _timeoutStart = DateTime.Now;
            return false;
        }

        public void AbortCurrentAction()
        {
            IsRunning = false;
        }
    }
}
