using Crawler.CrawlerFiles;

namespace Crawler
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
                new Thread(() => _algorithm.CrawlPage(UrlTextBox.Text, DomainTextBox.Text, UrlRegexTextBox.Text)).Start();
            }
        }

        private void UrlLabel_Click(object sender, EventArgs e)
        {

        }

        private void UrlTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void XPathTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            _algorithm.AbortCurrentAction();
        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }
    }
}