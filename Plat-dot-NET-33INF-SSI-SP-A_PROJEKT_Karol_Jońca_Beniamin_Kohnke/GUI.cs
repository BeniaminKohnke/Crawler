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
                _algorithm.Regex = UrlRegexTextBox.Text;
                _algorithm.Domain = DomainTextBox.Text;

                new Thread(() => _algorithm.CrawlPage()).Start();
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
    }
}