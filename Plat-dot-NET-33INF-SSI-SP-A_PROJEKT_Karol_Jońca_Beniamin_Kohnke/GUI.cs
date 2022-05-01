using Crawler;

namespace CrawlerGUI
{
    public partial class GUI : Form
    {
        private readonly Algorithm _algorithm = new();

        public GUI()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(UrlTextBox.Text) && !_algorithm.IsRunning)
            {
                _algorithm.Url = UrlTextBox.Text;
                _algorithm.StartingUrl = StartingPageTextBox.Text;
                _algorithm.Regex = ValidatorTextBox.Text;
                _algorithm.Domain = DomainTextBox.Text;

                new Thread(() => _algorithm.Run()).Start();
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            _algorithm.AbortCurrentAction();
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            if(Logger.TryGetLog(out var log) && log != null)
            {
                LogBox.Items.Add(log);
            }
        }

        private void SaveConfigButton_Click(object sender, EventArgs e)
        {
            var config = new CrawlerConfiguration
            {
                SaveFolderName = FolderNameBox.Text,
                ConfigurationName = ConfigNameBox.Text,
                PageAddress = UrlTextBox.Text,
                DomainText = DomainTextBox.Text,
                StartingAddress = StartingPageTextBox.Text,
                Validator = ValidatorTextBox.Text,
                ValidatorType = GetValidatorType(ValidatorTextBox.Text),
                ExtractionMethod = GetExtractionMethod(ExtractionMethodBox.Text),
                NameXPath = NameXPathBox.Text,
                CurrentPriceXPath = CurrentPriceXPathBox.Text,
                PreviousPriceXPath = PreviousPriceXPathBox.Text,
                SkuXPath = SkuXPathBox.Text,
                NameJSONPath = NameJPathBox.Text,
                CurrentJSONPath = CurrentPriceJPathBox.Text,
                PreviousJSONPath = PreviousPriceJPathBox.Text,
                SkuJSONPath = SkuJPathBox.Text,
                RequestHeaders = HeadersBox.Text,
                RequestData = DataBox.Text,
                RequesMethod = GetRequesMethod(CURLMethodBox.Text),
            };

            _algorithm.SaveConfiguration(config);
        }

        private void LoadConfigButton_Click(object sender, EventArgs e)
        {
            _algorithm.LoadConfiguration(ConfigNameBox.Text);
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
                "CURL" => ExtractionMethod.CURL,
                "SCRAPPER" => ExtractionMethod.SCRAPPER,
                "ONLY_URL" => ExtractionMethod.ONLY_URL,
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
    }
}