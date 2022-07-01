using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;
using System.Text.RegularExpressions;

namespace Crawler
{
    public sealed class Algorithm
    {
        private readonly Regex _priceRegex = new(@"\d+(?:[.,]\d{2})?", RegexOptions.Compiled);
        private readonly Regex _xpathAttributeRegex = new(@"/@([a-z]+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private readonly TimeSpan _delay = new(0, 0, 1);
        private readonly IWebDriver _webDriver = new ChromeDriver();
        private CrawlerConfiguration _configuration = new();
        private List<string> _storedUrls = new();

        public int ItemsLimit { get; set; } = 0;
        public bool IsRunning { get; private set; } = false;

        ~Algorithm()
        {
            _webDriver.Close();
            _webDriver.Quit();
        }

        public CrawlerConfiguration? LoadConfiguration(string configName)
        {
            IsRunning = false;
            var config = DataAccess.DownloadConfiguration(configName);
            if (config != null)
            {
                _configuration = config;
            }
            return config;
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
            if (_configuration != null)
            {
                Logger.Log(Logger.LogLevel.INFO, "Crawling process started.", _configuration.ConfigurationName);
                IsRunning = true;

                RunCrawler();
                _storedUrls = _storedUrls.Distinct().ToList();

                switch (_configuration.ExtractionMethod)
                {
                    case CrawlerConfigurationMethods.ExtractionMethod.SCRAPPER:
                        RunScraper();
                        break;
                    case CrawlerConfigurationMethods.ExtractionMethod.CURL:
                        RunCURLRequester();
                        break;
                    case CrawlerConfigurationMethods.ExtractionMethod.ONLY_URL:
                        DataAccess.SaveCrawlerResult(_configuration.SaveFolderName, _storedUrls);
                        break;
                }

                _storedUrls.Clear();
                IsRunning = false;
                Logger.Log(Logger.LogLevel.INFO, "Crawling process finished.", _configuration.ConfigurationName);
            }
        }

        public void RunCrawler()
        {
            var productRegex = _configuration.ValidatorType == CrawlerConfigurationMethods.ValidatorType.REGEX
                ? new Regex(_configuration.Validator, RegexOptions.Compiled | RegexOptions.IgnoreCase) : null;
            var urlQueue = new Queue<string>();
            var urlsToSkip = new List<string>();
            urlQueue.Enqueue(_configuration.StartingAddress);

            while (urlQueue.TryDequeue(out var nextUrl) && IsRunning)
            {
                if (!urlsToSkip.Contains(nextUrl))
                {
                    _webDriver.Navigate().GoToUrl(nextUrl);
                    urlsToSkip.Add(nextUrl);

                    switch (_configuration.ValidatorType)
                    {
                        case CrawlerConfigurationMethods.ValidatorType.REGEX:
                            {
                                var pageNodes = _webDriver.FindElements(By.XPath("//a"));
                                foreach (var node in pageNodes)
                                {
                                    try
                                    {
                                        var newUrl = node.GetAttribute("href");
                                        if (newUrl != null)
                                        {
                                            if (newUrl.Contains(_configuration.DomainText))
                                            {
                                                if (newUrl[0] == '/')
                                                {
                                                    newUrl = _configuration.PageAddress + newUrl;
                                                }

                                                if (productRegex != null && productRegex.IsMatch(newUrl))
                                                {
                                                    if (_storedUrls.Count <= ItemsLimit || ItemsLimit == 0)
                                                    {
                                                        _storedUrls.Add(newUrl);
                                                        urlsToSkip.Add(newUrl);
                                                    }
                                                    else
                                                    {
                                                        urlQueue.Clear();
                                                        break;
                                                    }
                                                }

                                                if (!urlsToSkip.Contains(newUrl))
                                                {
                                                    Logger.Log(Logger.LogLevel.INFO, $"Algorithm found: {newUrl}", _configuration.ConfigurationName);
                                                    urlQueue.Enqueue(newUrl);
                                                }
                                            }
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                                break;
                            }
                        case CrawlerConfigurationMethods.ValidatorType.XPATH:
                            {
                                var productNodes = _webDriver.FindElements(By.XPath(_configuration.Validator));
                                foreach (var node in productNodes)
                                {
                                    var newUrl = node.GetAttribute("href");
                                    if (newUrl != null)
                                    {
                                        if (newUrl.Contains(_configuration.DomainText))
                                        {
                                            if (newUrl[0] == '/')
                                            {
                                                newUrl = _configuration.PageAddress + newUrl;
                                            }

                                            if (_storedUrls.Count <= ItemsLimit || ItemsLimit == 0)
                                            {
                                                _storedUrls.Add(newUrl);
                                                urlsToSkip.Add(newUrl);
                                            }
                                            else
                                            {
                                                urlQueue.Clear();
                                                break;
                                            }
                                        }
                                    }
                                }

                                var otherNode = _webDriver.FindElements(By.XPath("//a"));
                                foreach (var node in otherNode)
                                {
                                    var newUrl = node.GetAttribute("href");
                                    if (newUrl != null)
                                    {
                                        if (newUrl.Contains(_configuration.DomainText))
                                        {
                                            if (newUrl[0] == '/')
                                            {
                                                newUrl = _configuration.PageAddress + newUrl;
                                            }

                                            if (!urlsToSkip.Contains(newUrl))
                                            {
                                                Logger.Log(Logger.LogLevel.INFO, $"Algorithm found: {newUrl}", _configuration.ConfigurationName);
                                                urlQueue.Enqueue(newUrl);
                                            }
                                        }
                                    }
                                }

                                break;
                            }
                        case CrawlerConfigurationMethods.ValidatorType.CSS_SELECTOR:
                            {
                                var productNodes = _webDriver.FindElements(By.CssSelector(_configuration.Validator));
                                foreach (var node in productNodes)
                                {
                                    var newUrl = node.GetCssValue("href");
                                    if (newUrl != null)
                                    {
                                        if (newUrl.Contains(_configuration.DomainText))
                                        {
                                            if (newUrl[0] == '/')
                                            {
                                                newUrl = _configuration.PageAddress + newUrl;
                                            }

                                            if (_storedUrls.Count <= ItemsLimit || ItemsLimit == 0)
                                            {
                                                _storedUrls.Add(newUrl);
                                                urlsToSkip.Add(newUrl);
                                            }
                                            else
                                            {
                                                urlQueue.Clear();
                                                break;
                                            }
                                        }
                                    }
                                }

                                var otherNode = _webDriver.FindElements(By.XPath("//a"));
                                foreach (var node in otherNode)
                                {
                                    var newUrl = node.GetAttribute("href");
                                    if (newUrl != null)
                                    {
                                        if (newUrl.Contains(_configuration.DomainText))
                                        {
                                            if (newUrl[0] == '/')
                                            {
                                                newUrl = _configuration.PageAddress + newUrl;
                                            }

                                            if (!urlsToSkip.Contains(newUrl))
                                            {
                                                Logger.Log(Logger.LogLevel.INFO, $"Algorithm found: {newUrl}", _configuration.ConfigurationName);
                                                urlQueue.Enqueue(newUrl);
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                    }

                    Thread.Sleep(_delay);
                }
            }
        }

        public void RunScraper()
        {
            var match = _xpathAttributeRegex.Match(_configuration.NameXPath);
            var nameAttribute = match.Success ? match.Groups[1].Value : string.Empty;
            match = _xpathAttributeRegex.Match(_configuration.CurrentPriceXPath);
            var currentPriceAttribute = match.Success ? match.Groups[1].Value : string.Empty;
            match = _xpathAttributeRegex.Match(_configuration.PreviousPriceXPath);
            var oldPriceAttribute = match.Success ? match.Groups[1].Value : string.Empty;
            match = _xpathAttributeRegex.Match(_configuration.SkuXPath);
            var skuAttribute = match.Success ? match.Groups[1].Value : string.Empty;

            foreach (var url in _storedUrls)
            {
                HtmlDocument? document = null;
                try
                {
                    using var client = new HttpClient();
                    client.BaseAddress = new Uri(url);
                    var response = client.GetByteArrayAsync(url).Result;

                    if (response != null)
                    {
                        document = new HtmlDocument();
                        document.LoadHtml(Encoding.Default.GetString(response));
                    }
                }
                catch (Exception e)
                {
                    Logger.Log(Logger.LogLevel.ERROR, $"Exception occured while parsing:{url}", _configuration.ConfigurationName, e);
                }

                try
                {
                    if (document != null)
                    {
                        string? productName = null;
                        string? productSku = null;
                        decimal productCurrentPrice = 0;
                        decimal productOldPrice = 0;

                        var nameNode = document.DocumentNode.SelectSingleNode(_configuration.NameXPath);
                        if (nameNode != null)
                        {
                            productName = string.IsNullOrEmpty(nameAttribute) ?
                                nameNode.InnerText.Trim() : nameNode.GetAttributeValue(nameAttribute, string.Empty).Trim();
                        }

                        var skuNode = document.DocumentNode.SelectSingleNode(_configuration.SkuXPath);
                        if (skuNode != null)
                        {
                            productSku = string.IsNullOrEmpty(skuAttribute) ?
                                skuNode.InnerText.Trim() : skuNode.GetAttributeValue(skuAttribute, string.Empty).Trim();
                        }

                        var currentPriceNode = document.DocumentNode.SelectSingleNode(_configuration.CurrentPriceXPath);
                        if (currentPriceNode != null)
                        {
                            match = _priceRegex.Match(string.IsNullOrEmpty(currentPriceAttribute) ?
                                currentPriceNode.InnerText.Trim() : currentPriceNode.GetAttributeValue(currentPriceAttribute, string.Empty).Trim());
                            if (match.Success)
                            {
                                if (decimal.TryParse(match.Value.Replace(",", "."), out var value))
                                {
                                    productCurrentPrice = value;
                                }
                            }
                        }

                        var oldPriceNode = document.DocumentNode.SelectSingleNode(_configuration.PreviousPriceXPath);
                        if (oldPriceNode != null)
                        {
                            match = _priceRegex.Match(string.IsNullOrEmpty(oldPriceAttribute) ?
                                oldPriceNode.InnerText.Trim() : oldPriceNode.GetAttributeValue(oldPriceAttribute, string.Empty).Trim());
                            if (match.Success)
                            {
                                if (decimal.TryParse(match.Value.Replace(",", "."), out var value))
                                {
                                    productOldPrice = value;
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(productSku) && productCurrentPrice > 0)
                        {
                            DataAccess.SaveProduct(_configuration.SaveFolderName,
                                new Product(productName, url, productSku, productCurrentPrice, productOldPrice));
                        }
                    }
                }
                catch (Exception e)
                {
                    Logger.Log(Logger.LogLevel.ERROR, $"Exception occured while extracting data from:{url}", _configuration.ConfigurationName, e);
                }
            }
        }

        public void RunCURLRequester()
        {
            foreach (var url in _storedUrls)
            {
                JObject? document = null;
                try
                {
                    var requestHeaders = _configuration.RequestHeaders
                        .Split(';')
                        .Select(h => h.Split(':'))
                        .Where(h => h.Length == 2)
                        .ToDictionary(k => k[0], v => v[1]);

                    var httpContent = new FormUrlEncodedContent(requestHeaders);
                    using var client = new HttpClient();
                    client.BaseAddress = new Uri(url);
                    var response = client.PostAsync(url, httpContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        document = JObject.Parse(Encoding.Default.GetString(response.Content.ReadAsByteArrayAsync().Result));
                    }
                }
                catch (Exception e)
                {
                    Logger.Log(Logger.LogLevel.ERROR, $"Exception occured while parsing:{url}", _configuration.ConfigurationName, e);
                }

                try
                {
                    if (document != null)
                    {
                        string? productName = null;
                        string? productSku = null;
                        decimal productCurrentPrice = 0;
                        decimal productOldPrice = 0;

                        var nameToken = document.SelectToken(_configuration.NameJSONPath);
                        if (nameToken != null)
                        {
                            productName = nameToken.Value<string>()?.Trim();
                        }

                        var skuToken = document.SelectToken(_configuration.SkuJSONPath);
                        if (skuToken != null)
                        {
                            productSku = skuToken.Value<string>()?.Trim();
                        }

                        var currentPriceToken = document.SelectToken(_configuration.CurrentJSONPath);
                        if (currentPriceToken != null)
                        {
                            var match = _priceRegex.Match(currentPriceToken.Value<string>() ?? string.Empty);
                            if (match.Success)
                            {
                                if (decimal.TryParse(match.Value.Replace(",", "."), out var value))
                                {
                                    productCurrentPrice = value;
                                }
                            }
                        }

                        var oldPriceNode = document.SelectToken(_configuration.PreviousJSONPath);
                        if (oldPriceNode != null)
                        {
                            var match = _priceRegex.Match(oldPriceNode.Value<string>() ?? string.Empty);
                            if (match.Success)
                            {
                                if (decimal.TryParse(match.Value.Replace(",", "."), out var value))
                                {
                                    productOldPrice = value;
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(productSku) && productCurrentPrice > 0)
                        {
                            DataAccess.SaveProduct(_configuration.SaveFolderName,
                                new Product(productName, url, productSku, productCurrentPrice, productOldPrice));
                        }
                    }
                }
                catch (Exception e)
                {
                    Logger.Log(Logger.LogLevel.ERROR, $"Exception occured while extracting data from:{url}", _configuration.ConfigurationName, e);
                }
            }
        }

        public void AbortCurrentAction()
        {
            Logger.Log(Logger.LogLevel.INFO, "ACTION ABORTED", "ALGORITHM");
            IsRunning = false;
        }
    }
}
