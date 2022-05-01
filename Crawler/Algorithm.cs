using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Text.RegularExpressions;

namespace Crawler
{
    public sealed class Algorithm
    {
        private readonly TimeSpan _delay = new(0, 0, 1);
        private readonly List<string> _storedUrls = new();

        private readonly IWebDriver _edgeDriver = new EdgeDriver();

        private CrawlerConfiguration _configuration = new();

        public string Url { get; set; } = string.Empty;
        public string StartingUrl { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public string Regex { get; set; } = string.Empty;

        public bool IsRunning { get; private set; } = false;

        ~Algorithm()
        {
            _edgeDriver.Close();
            _edgeDriver.Quit();
        }

        public void LoadConfiguration(string configName)
        {
            IsRunning = false;
            var config = DataAccess.DownloadConfiguration(configName);
            if(config != null)
            {
                _configuration = config;
            }
        }

        public void SaveConfiguration(CrawlerConfiguration config)
        {
            IsRunning = false;
            _configuration = config;
            if (!string.IsNullOrEmpty(_configuration.ConfigurationName))
            {
                DataAccess.SaveConfiguration(_configuration);
            }
        }

        public void Run()
        {
            if(_configuration != null)
            {
                IsRunning = true;

                RunCrawler();

                switch(_configuration.ExtractionMethod)
                {
                    case ExtractionMethod.SCRAPPER:
                        RunScraper();
                        break;
                    case ExtractionMethod.CURL:
                        RunCURLRequester();
                        break;
                    case ExtractionMethod.ONLY_URL:
                        DataAccess.SaveCrawlerResult(_configuration.SaveFolderName, _storedUrls);
                        break;
                }

                IsRunning = false;
            }
        }

        public void RunCrawler()
        {
            var productRegex = _configuration.ValidatorType.HasFlag(ValidatorType.REGEX) ? new Regex(Regex, RegexOptions.Compiled | RegexOptions.IgnoreCase) : null;
            var urlQueue = new Queue<string>();
            var urlsToSkip = new List<string>();
            urlQueue.Enqueue(StartingUrl);

            while (urlQueue.TryDequeue(out var nextUrl) && IsRunning)
            {
                if(!urlsToSkip.Contains(nextUrl))
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
                                if (newUrl.Contains(Domain))
                                {
                                    if (newUrl[0] == '/')
                                    {
                                        newUrl = Url + newUrl;
                                    }

                                    switch (_configuration.ValidatorType)
                                    {
                                        case ValidatorType.REGEX:
                                            {
                                                if (productRegex != null && productRegex.IsMatch(newUrl))
                                                {
                                                    _storedUrls.Add(newUrl);
                                                    urlsToSkip.Add(newUrl);
                                                }
                                                break;
                                            }
                                        case ValidatorType.XPATH:
                                            {
                                                break;
                                            }
                                        case ValidatorType.CSS_SELECTOR:
                                            {
                                                break;
                                            }
                                    }


                                    if (!urlsToSkip.Contains(newUrl))
                                    {
                                        Logger.Log(Logger.LogLevel.INFO, $"Algorithm found: {newUrl}", _configuration.ConfigurationName);
                                        urlQueue.Enqueue(newUrl);
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
            }
        }

        public void RunScraper()
        {
            foreach(var url in _storedUrls)
            {

            }
        }

        public void RunCURLRequester()
        {
            foreach(var url in _storedUrls)
            {

            }
        }

        public void AbortCurrentAction()
        {
            IsRunning = false;
        }
    }
}
