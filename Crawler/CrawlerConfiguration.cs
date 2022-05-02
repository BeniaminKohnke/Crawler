namespace Crawler
{

    public class CrawlerConfigurationMethods
    {
        public enum ValidatorType
        {
            NONE,
            REGEX,
            CSS_SELECTOR,
            XPATH
        }

        public enum ExtractionMethod
        {
            NONE,
            CURL,
            SCRAPPER,
            ONLY_URL
        }

        public enum RequesMethod
        { 
            NONE,
            GET,
            POST
        }

        public static ValidatorType GetValidatorType(string text)
        {
            return text switch
            {
                "REGEX" => ValidatorType.REGEX,
                "CSS_SELECTOR" => ValidatorType.CSS_SELECTOR,
                "XPATH" => ValidatorType.XPATH,
                _ => ValidatorType.NONE,
            };
        }

        public static ExtractionMethod GetExtractionMethod(string text)
        {
            return text switch
            {
                "CLIENT URL REQUEST" => ExtractionMethod.CURL,
                "DATA SCRAPER" => ExtractionMethod.SCRAPPER,
                "ONLY CRAWLER" => ExtractionMethod.ONLY_URL,
                _ => ExtractionMethod.NONE,
            };
        }

        public static RequesMethod GetRequesMethod(string text)
        {
            return text switch
            {
                "GET" => RequesMethod.GET,
                "POST" => RequesMethod.POST,
                _ => RequesMethod.NONE,
            };
        }

        public static string GetValidatorName(ValidatorType type)
        {
            return type switch
            {
                ValidatorType.REGEX => "REGEX",
                ValidatorType.CSS_SELECTOR => "CSS_SELECTOR",
                ValidatorType.XPATH => "XPATH",
                _ => string.Empty,
            };
        }

        public static string GetExtractionMethodName(ExtractionMethod method)
        {
            return method switch
            {
                ExtractionMethod.CURL => "CLIENT URL REQUEST",
                ExtractionMethod.SCRAPPER => "DATA SCRAPER",
                ExtractionMethod.ONLY_URL => "ONLY CRAWLER",
                _ => string.Empty,
            };
        }
        public static string GetRequesMethodName(RequesMethod method)
        {
            return method switch
            {
                RequesMethod.GET => "GET",
                RequesMethod.POST => "POST",
                _ => string.Empty,
            };
        }
    }

    public class CrawlerConfiguration
    {
        public string SaveFolderName { get; set; } = string.Empty;
        public string ConfigurationName { get; set; } = string.Empty;

        public string PageAddress { get; set; } = string.Empty;
        public string DomainText { get; set; } = string.Empty;
        public string StartingAddress { get; set; } = string.Empty;
        public string Validator { get; set; } = string.Empty;

        public CrawlerConfigurationMethods.ValidatorType ValidatorType { get; set; } = CrawlerConfigurationMethods.ValidatorType.NONE;
        public CrawlerConfigurationMethods.ExtractionMethod ExtractionMethod { get; set; } = CrawlerConfigurationMethods.ExtractionMethod.NONE;

        public string NameXPath { get; set; } = string.Empty;
        public string CurrentPriceXPath { get; set; } = string.Empty;
        public string PreviousPriceXPath { get; set; } = string.Empty;
        public string SkuXPath { get; set; } = string.Empty;

        public string NameJSONPath { get; set; } = string.Empty;
        public string CurrentJSONPath { get; set; } = string.Empty;
        public string PreviousJSONPath { get; set; } = string.Empty;
        public string SkuJSONPath { get; set; } = string.Empty;
        public string RequestHeaders { get; set; } = string.Empty;
        public string RequestData { get; set; } = string.Empty;

        public CrawlerConfigurationMethods.RequesMethod RequesMethod { get; set; } = CrawlerConfigurationMethods.RequesMethod.NONE;
    }
}
