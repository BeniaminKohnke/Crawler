using Crawler;

namespace CrawlerGUI
{
    public partial class GUI : Form
    {
        private readonly Algorithm _algorithm = new();

        public GUI()
        {
            InitializeComponent();
            ExistingConfigsBox.Items.AddRange(DataAccess.GetConfigurations());
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
                ValidatorType = CrawlerConfigurationMethods.GetValidatorType(ValidatorTypeBox.Text),
                ExtractionMethod = CrawlerConfigurationMethods.GetExtractionMethod(ExtractionMethodBox.Text),
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
                RequesMethod = CrawlerConfigurationMethods.GetRequesMethod(CURLMethodBox.Text),
            };

            _algorithm.SaveConfiguration(config);
        }

        private void LoadConfigButton_Click(object sender, EventArgs e)
        {
            var config = _algorithm.LoadConfiguration(ExistingConfigsBox.Text);
            if(config != null)
            {
                FolderNameBox.Text = config.SaveFolderName;
                ConfigNameBox.Text = config.ConfigurationName;
                UrlTextBox.Text = config.PageAddress;
                DomainTextBox.Text = config.DomainText;
                StartingPageTextBox.Text = config.StartingAddress;
                ValidatorTextBox.Text = config.Validator;
                ValidatorTypeBox.Text = CrawlerConfigurationMethods.GetValidatorName(config.ValidatorType);
                ExtractionMethodBox.Text = CrawlerConfigurationMethods.GetExtractionMethodName(config.ExtractionMethod);
                NameXPathBox.Text = config.NameXPath;
                CurrentPriceXPathBox.Text = config.CurrentPriceXPath;
                PreviousPriceXPathBox.Text = config.PreviousPriceXPath;
                SkuXPathBox.Text = config.SkuXPath;
                NameJPathBox.Text = config.NameJSONPath;
                CurrentPriceJPathBox.Text = config.CurrentJSONPath;
                PreviousPriceJPathBox.Text = config.PreviousJSONPath;
                SkuJPathBox.Text = config.SkuJSONPath;
                HeadersBox.Text = config.RequestHeaders;
                DataBox.Text = config.RequestData;
                CURLMethodBox.Text = CrawlerConfigurationMethods.GetRequesMethodName(config.RequesMethod);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ExistingConfigsBox.Items.Clear();
            ExistingConfigsBox.Items.AddRange(DataAccess.GetConfigurations());
        }
    }
}