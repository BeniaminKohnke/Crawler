namespace Crawler
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

    public class CrawlerConfiguration
    {
        public string SaveFolderName { get; set; } = string.Empty;
        public string ConfigurationName { get; set; } = string.Empty;

        public string PageAddress { get; set; } = string.Empty;
        public string DomainText { get; set; } = string.Empty;
        public string StartingAddress { get; set; } = string.Empty;
        public string Validator { get; set; } = string.Empty;

        public ValidatorType ValidatorType { get; set; } = ValidatorType.NONE;
        public ExtractionMethod ExtractionMethod { get; set; } = ExtractionMethod.NONE;

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

        public RequesMethod RequesMethod { get; set; } = RequesMethod.NONE;
    }
}
