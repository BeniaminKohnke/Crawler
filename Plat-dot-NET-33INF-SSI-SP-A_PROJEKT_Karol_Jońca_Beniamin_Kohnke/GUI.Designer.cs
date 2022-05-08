namespace CrawlerGUI
{
    partial class GUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LimitBox = new System.Windows.Forms.TextBox();
            this.LimitLabel = new System.Windows.Forms.Label();
            this.LogBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ExtractionMethodBox = new System.Windows.Forms.ComboBox();
            this.MethodLabel = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.SkuXPathBox = new System.Windows.Forms.TextBox();
            this.PreviousPriceXPathBox = new System.Windows.Forms.TextBox();
            this.CurrentPriceXPathBox = new System.Windows.Forms.TextBox();
            this.NameXPathBox = new System.Windows.Forms.TextBox();
            this.SkuXPathLabel = new System.Windows.Forms.Label();
            this.PreviousPriceXPathLabel = new System.Windows.Forms.Label();
            this.CurrentPriceXPathLabel = new System.Windows.Forms.Label();
            this.NameXPathLabel = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.DataBox = new System.Windows.Forms.TextBox();
            this.DataLabel = new System.Windows.Forms.Label();
            this.CURLMethodLabel = new System.Windows.Forms.Label();
            this.CURLMethodBox = new System.Windows.Forms.ComboBox();
            this.HeadersBox = new System.Windows.Forms.TextBox();
            this.HeadersLabel = new System.Windows.Forms.Label();
            this.SkuJPathBox = new System.Windows.Forms.TextBox();
            this.PreviousPriceJPathBox = new System.Windows.Forms.TextBox();
            this.CurrentPriceJPathBox = new System.Windows.Forms.TextBox();
            this.NameJPathBox = new System.Windows.Forms.TextBox();
            this.SkuJPathLabel = new System.Windows.Forms.Label();
            this.PreviousPriceJPathLabel = new System.Windows.Forms.Label();
            this.CurrentPriceJPathLabel = new System.Windows.Forms.Label();
            this.NameJPathLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.ValidatorTypeBox = new System.Windows.Forms.ComboBox();
            this.VerificatorLabel = new System.Windows.Forms.Label();
            this.DomainLabel = new System.Windows.Forms.Label();
            this.StartingAddressLabel = new System.Windows.Forms.Label();
            this.UrlLabel = new System.Windows.Forms.Label();
            this.StartingPageTextBox = new System.Windows.Forms.TextBox();
            this.ValidatorTextBox = new System.Windows.Forms.TextBox();
            this.DomainTextBox = new System.Windows.Forms.TextBox();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ExistingConfigsBox = new System.Windows.Forms.ListBox();
            this.ConfigNameLabel = new System.Windows.Forms.Label();
            this.ConfigNameBox = new System.Windows.Forms.TextBox();
            this.LoadConfigButton = new System.Windows.Forms.Button();
            this.SaveConfigButton = new System.Windows.Forms.Button();
            this.FolderNameBox = new System.Windows.Forms.TextBox();
            this.FolderNameLabel = new System.Windows.Forms.Label();
            this.Update = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(6, 3);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(87, 3);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 4;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-4, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(644, 451);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LimitBox);
            this.tabPage1.Controls.Add(this.LimitLabel);
            this.tabPage1.Controls.Add(this.LogBox);
            this.tabPage1.Controls.Add(this.StartButton);
            this.tabPage1.Controls.Add(this.StopButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(636, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Executor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LimitBox
            // 
            this.LimitBox.Location = new System.Drawing.Point(521, 6);
            this.LimitBox.Name = "LimitBox";
            this.LimitBox.Size = new System.Drawing.Size(100, 23);
            this.LimitBox.TabIndex = 7;
            this.LimitBox.TextChanged += new System.EventHandler(this.LimitBox_TextChanged);
            // 
            // LimitLabel
            // 
            this.LimitLabel.AutoSize = true;
            this.LimitLabel.Location = new System.Drawing.Point(477, 7);
            this.LimitLabel.Name = "LimitLabel";
            this.LimitLabel.Size = new System.Drawing.Size(39, 15);
            this.LimitLabel.TabIndex = 6;
            this.LimitLabel.Text = "LIMIT:";
            // 
            // LogBox
            // 
            this.LogBox.FormattingEnabled = true;
            this.LogBox.ItemHeight = 15;
            this.LogBox.Location = new System.Drawing.Point(12, 38);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(615, 379);
            this.LogBox.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ExtractionMethodBox);
            this.tabPage2.Controls.Add(this.MethodLabel);
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.TypeLabel);
            this.tabPage2.Controls.Add(this.ValidatorTypeBox);
            this.tabPage2.Controls.Add(this.VerificatorLabel);
            this.tabPage2.Controls.Add(this.DomainLabel);
            this.tabPage2.Controls.Add(this.StartingAddressLabel);
            this.tabPage2.Controls.Add(this.UrlLabel);
            this.tabPage2.Controls.Add(this.StartingPageTextBox);
            this.tabPage2.Controls.Add(this.ValidatorTextBox);
            this.tabPage2.Controls.Add(this.DomainTextBox);
            this.tabPage2.Controls.Add(this.UrlTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(636, 423);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ExtractionMethodBox
            // 
            this.ExtractionMethodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ExtractionMethodBox.FormattingEnabled = true;
            this.ExtractionMethodBox.Items.AddRange(new object[] {
            "DATA SCRAPER",
            "CLIENT URL REQUEST",
            "ONLY CRAWLER"});
            this.ExtractionMethodBox.Location = new System.Drawing.Point(12, 162);
            this.ExtractionMethodBox.Name = "ExtractionMethodBox";
            this.ExtractionMethodBox.Size = new System.Drawing.Size(504, 23);
            this.ExtractionMethodBox.TabIndex = 18;
            // 
            // MethodLabel
            // 
            this.MethodLabel.AutoSize = true;
            this.MethodLabel.Location = new System.Drawing.Point(12, 144);
            this.MethodLabel.Name = "MethodLabel";
            this.MethodLabel.Size = new System.Drawing.Size(105, 15);
            this.MethodLabel.TabIndex = 17;
            this.MethodLabel.Text = "Extraction method";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(12, 198);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(609, 219);
            this.tabControl2.TabIndex = 16;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.SkuXPathBox);
            this.tabPage4.Controls.Add(this.PreviousPriceXPathBox);
            this.tabPage4.Controls.Add(this.CurrentPriceXPathBox);
            this.tabPage4.Controls.Add(this.NameXPathBox);
            this.tabPage4.Controls.Add(this.SkuXPathLabel);
            this.tabPage4.Controls.Add(this.PreviousPriceXPathLabel);
            this.tabPage4.Controls.Add(this.CurrentPriceXPathLabel);
            this.tabPage4.Controls.Add(this.NameXPathLabel);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(601, 191);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "Scraper";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // SkuXPathBox
            // 
            this.SkuXPathBox.Location = new System.Drawing.Point(6, 155);
            this.SkuXPathBox.Name = "SkuXPathBox";
            this.SkuXPathBox.Size = new System.Drawing.Size(494, 23);
            this.SkuXPathBox.TabIndex = 7;
            // 
            // PreviousPriceXPathBox
            // 
            this.PreviousPriceXPathBox.Location = new System.Drawing.Point(6, 111);
            this.PreviousPriceXPathBox.Name = "PreviousPriceXPathBox";
            this.PreviousPriceXPathBox.Size = new System.Drawing.Size(494, 23);
            this.PreviousPriceXPathBox.TabIndex = 6;
            // 
            // CurrentPriceXPathBox
            // 
            this.CurrentPriceXPathBox.Location = new System.Drawing.Point(6, 67);
            this.CurrentPriceXPathBox.Name = "CurrentPriceXPathBox";
            this.CurrentPriceXPathBox.Size = new System.Drawing.Size(494, 23);
            this.CurrentPriceXPathBox.TabIndex = 5;
            // 
            // NameXPathBox
            // 
            this.NameXPathBox.Location = new System.Drawing.Point(6, 25);
            this.NameXPathBox.Name = "NameXPathBox";
            this.NameXPathBox.Size = new System.Drawing.Size(494, 23);
            this.NameXPathBox.TabIndex = 4;
            // 
            // SkuXPathLabel
            // 
            this.SkuXPathLabel.AutoSize = true;
            this.SkuXPathLabel.Location = new System.Drawing.Point(6, 137);
            this.SkuXPathLabel.Name = "SkuXPathLabel";
            this.SkuXPathLabel.Size = new System.Drawing.Size(60, 15);
            this.SkuXPathLabel.TabIndex = 3;
            this.SkuXPathLabel.Text = "Sku XPath";
            // 
            // PreviousPriceXPathLabel
            // 
            this.PreviousPriceXPathLabel.AutoSize = true;
            this.PreviousPriceXPathLabel.Location = new System.Drawing.Point(6, 93);
            this.PreviousPriceXPathLabel.Name = "PreviousPriceXPathLabel";
            this.PreviousPriceXPathLabel.Size = new System.Drawing.Size(115, 15);
            this.PreviousPriceXPathLabel.TabIndex = 2;
            this.PreviousPriceXPathLabel.Text = "Previous Price XPath";
            // 
            // CurrentPriceXPathLabel
            // 
            this.CurrentPriceXPathLabel.AutoSize = true;
            this.CurrentPriceXPathLabel.Location = new System.Drawing.Point(6, 51);
            this.CurrentPriceXPathLabel.Name = "CurrentPriceXPathLabel";
            this.CurrentPriceXPathLabel.Size = new System.Drawing.Size(110, 15);
            this.CurrentPriceXPathLabel.TabIndex = 1;
            this.CurrentPriceXPathLabel.Text = "Current Price XPath";
            // 
            // NameXPathLabel
            // 
            this.NameXPathLabel.AutoSize = true;
            this.NameXPathLabel.Location = new System.Drawing.Point(6, 7);
            this.NameXPathLabel.Name = "NameXPathLabel";
            this.NameXPathLabel.Size = new System.Drawing.Size(73, 15);
            this.NameXPathLabel.TabIndex = 0;
            this.NameXPathLabel.Text = "Name XPath";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.DataBox);
            this.tabPage5.Controls.Add(this.DataLabel);
            this.tabPage5.Controls.Add(this.CURLMethodLabel);
            this.tabPage5.Controls.Add(this.CURLMethodBox);
            this.tabPage5.Controls.Add(this.HeadersBox);
            this.tabPage5.Controls.Add(this.HeadersLabel);
            this.tabPage5.Controls.Add(this.SkuJPathBox);
            this.tabPage5.Controls.Add(this.PreviousPriceJPathBox);
            this.tabPage5.Controls.Add(this.CurrentPriceJPathBox);
            this.tabPage5.Controls.Add(this.NameJPathBox);
            this.tabPage5.Controls.Add(this.SkuJPathLabel);
            this.tabPage5.Controls.Add(this.PreviousPriceJPathLabel);
            this.tabPage5.Controls.Add(this.CurrentPriceJPathLabel);
            this.tabPage5.Controls.Add(this.NameJPathLabel);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(601, 191);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "cURL";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // DataBox
            // 
            this.DataBox.Location = new System.Drawing.Point(429, 114);
            this.DataBox.Name = "DataBox";
            this.DataBox.Size = new System.Drawing.Size(166, 23);
            this.DataBox.TabIndex = 19;
            // 
            // DataLabel
            // 
            this.DataLabel.AutoSize = true;
            this.DataLabel.Location = new System.Drawing.Point(429, 96);
            this.DataLabel.Name = "DataLabel";
            this.DataLabel.Size = new System.Drawing.Size(31, 15);
            this.DataLabel.TabIndex = 18;
            this.DataLabel.Text = "Data";
            // 
            // CURLMethodLabel
            // 
            this.CURLMethodLabel.AutoSize = true;
            this.CURLMethodLabel.Location = new System.Drawing.Point(429, 8);
            this.CURLMethodLabel.Name = "CURLMethodLabel";
            this.CURLMethodLabel.Size = new System.Drawing.Size(79, 15);
            this.CURLMethodLabel.TabIndex = 1;
            this.CURLMethodLabel.Text = "cURL method";
            // 
            // CURLMethodBox
            // 
            this.CURLMethodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CURLMethodBox.FormattingEnabled = true;
            this.CURLMethodBox.Items.AddRange(new object[] {
            "GET",
            "POST"});
            this.CURLMethodBox.Location = new System.Drawing.Point(429, 26);
            this.CURLMethodBox.Name = "CURLMethodBox";
            this.CURLMethodBox.Size = new System.Drawing.Size(166, 23);
            this.CURLMethodBox.TabIndex = 0;
            // 
            // HeadersBox
            // 
            this.HeadersBox.Location = new System.Drawing.Point(429, 70);
            this.HeadersBox.Name = "HeadersBox";
            this.HeadersBox.Size = new System.Drawing.Size(166, 23);
            this.HeadersBox.TabIndex = 17;
            // 
            // HeadersLabel
            // 
            this.HeadersLabel.AutoSize = true;
            this.HeadersLabel.Location = new System.Drawing.Point(429, 52);
            this.HeadersLabel.Name = "HeadersLabel";
            this.HeadersLabel.Size = new System.Drawing.Size(50, 15);
            this.HeadersLabel.TabIndex = 16;
            this.HeadersLabel.Text = "Headers";
            // 
            // SkuJPathBox
            // 
            this.SkuJPathBox.Location = new System.Drawing.Point(6, 158);
            this.SkuJPathBox.Name = "SkuJPathBox";
            this.SkuJPathBox.Size = new System.Drawing.Size(417, 23);
            this.SkuJPathBox.TabIndex = 15;
            // 
            // PreviousPriceJPathBox
            // 
            this.PreviousPriceJPathBox.Location = new System.Drawing.Point(6, 114);
            this.PreviousPriceJPathBox.Name = "PreviousPriceJPathBox";
            this.PreviousPriceJPathBox.Size = new System.Drawing.Size(417, 23);
            this.PreviousPriceJPathBox.TabIndex = 14;
            // 
            // CurrentPriceJPathBox
            // 
            this.CurrentPriceJPathBox.Location = new System.Drawing.Point(6, 70);
            this.CurrentPriceJPathBox.Name = "CurrentPriceJPathBox";
            this.CurrentPriceJPathBox.Size = new System.Drawing.Size(417, 23);
            this.CurrentPriceJPathBox.TabIndex = 13;
            // 
            // NameJPathBox
            // 
            this.NameJPathBox.Location = new System.Drawing.Point(6, 28);
            this.NameJPathBox.Name = "NameJPathBox";
            this.NameJPathBox.Size = new System.Drawing.Size(417, 23);
            this.NameJPathBox.TabIndex = 12;
            // 
            // SkuJPathLabel
            // 
            this.SkuJPathLabel.AutoSize = true;
            this.SkuJPathLabel.Location = new System.Drawing.Point(6, 140);
            this.SkuJPathLabel.Name = "SkuJPathLabel";
            this.SkuJPathLabel.Size = new System.Drawing.Size(81, 15);
            this.SkuJPathLabel.TabIndex = 11;
            this.SkuJPathLabel.Text = "Sku JSONPath";
            // 
            // PreviousPriceJPathLabel
            // 
            this.PreviousPriceJPathLabel.AutoSize = true;
            this.PreviousPriceJPathLabel.Location = new System.Drawing.Point(6, 96);
            this.PreviousPriceJPathLabel.Name = "PreviousPriceJPathLabel";
            this.PreviousPriceJPathLabel.Size = new System.Drawing.Size(136, 15);
            this.PreviousPriceJPathLabel.TabIndex = 10;
            this.PreviousPriceJPathLabel.Text = "Previous Price JSONPath";
            // 
            // CurrentPriceJPathLabel
            // 
            this.CurrentPriceJPathLabel.AutoSize = true;
            this.CurrentPriceJPathLabel.Location = new System.Drawing.Point(6, 54);
            this.CurrentPriceJPathLabel.Name = "CurrentPriceJPathLabel";
            this.CurrentPriceJPathLabel.Size = new System.Drawing.Size(131, 15);
            this.CurrentPriceJPathLabel.TabIndex = 9;
            this.CurrentPriceJPathLabel.Text = "Current Price JSONPath";
            // 
            // NameJPathLabel
            // 
            this.NameJPathLabel.AutoSize = true;
            this.NameJPathLabel.Location = new System.Drawing.Point(6, 10);
            this.NameJPathLabel.Name = "NameJPathLabel";
            this.NameJPathLabel.Size = new System.Drawing.Size(94, 15);
            this.NameJPathLabel.TabIndex = 8;
            this.NameJPathLabel.Text = "Name JSONPath";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(521, 100);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(31, 15);
            this.TypeLabel.TabIndex = 15;
            this.TypeLabel.Text = "Type";
            // 
            // ValidatorTypeBox
            // 
            this.ValidatorTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ValidatorTypeBox.FormattingEnabled = true;
            this.ValidatorTypeBox.Items.AddRange(new object[] {
            "REGEX",
            "CSS SELECTOR",
            "XPATH"});
            this.ValidatorTypeBox.Location = new System.Drawing.Point(521, 118);
            this.ValidatorTypeBox.Name = "ValidatorTypeBox";
            this.ValidatorTypeBox.Size = new System.Drawing.Size(100, 23);
            this.ValidatorTypeBox.TabIndex = 14;
            // 
            // VerificatorLabel
            // 
            this.VerificatorLabel.AutoSize = true;
            this.VerificatorLabel.Location = new System.Drawing.Point(12, 100);
            this.VerificatorLabel.Name = "VerificatorLabel";
            this.VerificatorLabel.Size = new System.Drawing.Size(123, 15);
            this.VerificatorLabel.TabIndex = 13;
            this.VerificatorLabel.Text = "Verification parameter";
            // 
            // DomainLabel
            // 
            this.DomainLabel.AutoSize = true;
            this.DomainLabel.Location = new System.Drawing.Point(521, 12);
            this.DomainLabel.Name = "DomainLabel";
            this.DomainLabel.Size = new System.Drawing.Size(49, 15);
            this.DomainLabel.TabIndex = 12;
            this.DomainLabel.Text = "Domain";
            // 
            // StartingAddressLabel
            // 
            this.StartingAddressLabel.AutoSize = true;
            this.StartingAddressLabel.Location = new System.Drawing.Point(12, 56);
            this.StartingAddressLabel.Name = "StartingAddressLabel";
            this.StartingAddressLabel.Size = new System.Drawing.Size(91, 15);
            this.StartingAddressLabel.TabIndex = 11;
            this.StartingAddressLabel.Text = "Starting address";
            // 
            // UrlLabel
            // 
            this.UrlLabel.AutoSize = true;
            this.UrlLabel.Location = new System.Drawing.Point(12, 12);
            this.UrlLabel.Name = "UrlLabel";
            this.UrlLabel.Size = new System.Drawing.Size(49, 15);
            this.UrlLabel.TabIndex = 10;
            this.UrlLabel.Text = "Address";
            // 
            // StartingPageTextBox
            // 
            this.StartingPageTextBox.Location = new System.Drawing.Point(12, 74);
            this.StartingPageTextBox.Name = "StartingPageTextBox";
            this.StartingPageTextBox.Size = new System.Drawing.Size(504, 23);
            this.StartingPageTextBox.TabIndex = 9;
            // 
            // ValidatorTextBox
            // 
            this.ValidatorTextBox.Location = new System.Drawing.Point(12, 118);
            this.ValidatorTextBox.Name = "ValidatorTextBox";
            this.ValidatorTextBox.Size = new System.Drawing.Size(504, 23);
            this.ValidatorTextBox.TabIndex = 7;
            // 
            // DomainTextBox
            // 
            this.DomainTextBox.Location = new System.Drawing.Point(521, 30);
            this.DomainTextBox.Name = "DomainTextBox";
            this.DomainTextBox.Size = new System.Drawing.Size(100, 23);
            this.DomainTextBox.TabIndex = 8;
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(12, 30);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(504, 23);
            this.UrlTextBox.TabIndex = 6;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.RefreshButton);
            this.tabPage3.Controls.Add(this.ExistingConfigsBox);
            this.tabPage3.Controls.Add(this.ConfigNameLabel);
            this.tabPage3.Controls.Add(this.ConfigNameBox);
            this.tabPage3.Controls.Add(this.LoadConfigButton);
            this.tabPage3.Controls.Add(this.SaveConfigButton);
            this.tabPage3.Controls.Add(this.FolderNameBox);
            this.tabPage3.Controls.Add(this.FolderNameLabel);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(636, 423);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Save/Load";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(528, 104);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 7;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ExistingConfigsBox
            // 
            this.ExistingConfigsBox.FormattingEnabled = true;
            this.ExistingConfigsBox.ItemHeight = 15;
            this.ExistingConfigsBox.Location = new System.Drawing.Point(12, 104);
            this.ExistingConfigsBox.Name = "ExistingConfigsBox";
            this.ExistingConfigsBox.Size = new System.Drawing.Size(510, 304);
            this.ExistingConfigsBox.TabIndex = 6;
            // 
            // ConfigNameLabel
            // 
            this.ConfigNameLabel.AutoSize = true;
            this.ConfigNameLabel.Location = new System.Drawing.Point(12, 57);
            this.ConfigNameLabel.Name = "ConfigNameLabel";
            this.ConfigNameLabel.Size = new System.Drawing.Size(114, 15);
            this.ConfigNameLabel.TabIndex = 5;
            this.ConfigNameLabel.Text = "Configuration name";
            // 
            // ConfigNameBox
            // 
            this.ConfigNameBox.Location = new System.Drawing.Point(12, 75);
            this.ConfigNameBox.Name = "ConfigNameBox";
            this.ConfigNameBox.Size = new System.Drawing.Size(510, 23);
            this.ConfigNameBox.TabIndex = 4;
            // 
            // LoadConfigButton
            // 
            this.LoadConfigButton.Location = new System.Drawing.Point(528, 133);
            this.LoadConfigButton.Name = "LoadConfigButton";
            this.LoadConfigButton.Size = new System.Drawing.Size(75, 23);
            this.LoadConfigButton.TabIndex = 3;
            this.LoadConfigButton.Text = "Load";
            this.LoadConfigButton.UseVisualStyleBackColor = true;
            this.LoadConfigButton.Click += new System.EventHandler(this.LoadConfigButton_Click);
            // 
            // SaveConfigButton
            // 
            this.SaveConfigButton.Location = new System.Drawing.Point(528, 31);
            this.SaveConfigButton.Name = "SaveConfigButton";
            this.SaveConfigButton.Size = new System.Drawing.Size(75, 23);
            this.SaveConfigButton.TabIndex = 2;
            this.SaveConfigButton.Text = "Save";
            this.SaveConfigButton.UseVisualStyleBackColor = true;
            this.SaveConfigButton.Click += new System.EventHandler(this.SaveConfigButton_Click);
            // 
            // FolderNameBox
            // 
            this.FolderNameBox.Location = new System.Drawing.Point(12, 31);
            this.FolderNameBox.Name = "FolderNameBox";
            this.FolderNameBox.Size = new System.Drawing.Size(510, 23);
            this.FolderNameBox.TabIndex = 1;
            // 
            // FolderNameLabel
            // 
            this.FolderNameLabel.AutoSize = true;
            this.FolderNameLabel.Location = new System.Drawing.Point(12, 13);
            this.FolderNameLabel.Name = "FolderNameLabel";
            this.FolderNameLabel.Size = new System.Drawing.Size(73, 15);
            this.FolderNameLabel.TabIndex = 0;
            this.FolderNameLabel.Text = "Folder name";
            // 
            // Update
            // 
            this.Update.Enabled = true;
            this.Update.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 445);
            this.Controls.Add(this.tabControl1);
            this.Name = "GUI";
            this.Text = "Crawler";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button StartButton;
        private Button StopButton;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ListBox LogBox;
        private TabPage tabPage2;
        private TextBox ValidatorTextBox;
        private TextBox DomainTextBox;
        private TextBox UrlTextBox;
        private TabPage tabPage3;
        private TextBox StartingPageTextBox;
        private new System.Windows.Forms.Timer Update;
        private Label DomainLabel;
        private Label StartingAddressLabel;
        private Label UrlLabel;
        private ComboBox ValidatorTypeBox;
        private Label VerificatorLabel;
        private TabControl tabControl2;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Label TypeLabel;
        private ComboBox ExtractionMethodBox;
        private Label MethodLabel;
        private TextBox SkuXPathBox;
        private TextBox PreviousPriceXPathBox;
        private TextBox CurrentPriceXPathBox;
        private TextBox NameXPathBox;
        private Label SkuXPathLabel;
        private Label PreviousPriceXPathLabel;
        private Label CurrentPriceXPathLabel;
        private Label NameXPathLabel;
        private TextBox DataBox;
        private Label DataLabel;
        private Label CURLMethodLabel;
        private ComboBox CURLMethodBox;
        private TextBox HeadersBox;
        private Label HeadersLabel;
        private TextBox SkuJPathBox;
        private TextBox PreviousPriceJPathBox;
        private TextBox CurrentPriceJPathBox;
        private TextBox NameJPathBox;
        private Label SkuJPathLabel;
        private Label PreviousPriceJPathLabel;
        private Label CurrentPriceJPathLabel;
        private Label NameJPathLabel;
        private Button LoadConfigButton;
        private Button SaveConfigButton;
        private TextBox FolderNameBox;
        private Label FolderNameLabel;
        private Label ConfigNameLabel;
        private TextBox ConfigNameBox;
        private ListBox ExistingConfigsBox;
        private Button RefreshButton;
        private TextBox LimitBox;
        private Label LimitLabel;
    }
}