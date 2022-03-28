namespace Crawler
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
            this.StartButton = new System.Windows.Forms.Button();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.UrlRegexTextBox = new System.Windows.Forms.TextBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.DomainTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(76, 96);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(76, 38);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(504, 23);
            this.UrlTextBox.TabIndex = 2;
            this.UrlTextBox.Text = "https://store.epicgames.com/pl/browse?sortBy=releaseDate&sortDir=DESC&count=40";
            this.UrlTextBox.TextChanged += new System.EventHandler(this.UrlTextBox_TextChanged);
            // 
            // UrlRegexTextBox
            // 
            this.UrlRegexTextBox.Location = new System.Drawing.Point(76, 67);
            this.UrlRegexTextBox.Name = "UrlRegexTextBox";
            this.UrlRegexTextBox.Size = new System.Drawing.Size(504, 23);
            this.UrlRegexTextBox.TabIndex = 3;
            this.UrlRegexTextBox.Text = "^https://store.epicgames.com/pl/p/\\S+$";
            this.UrlRegexTextBox.TextChanged += new System.EventHandler(this.XPathTextBox_TextChanged);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(157, 96);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 4;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // DomainTextBox
            // 
            this.DomainTextBox.Location = new System.Drawing.Point(586, 38);
            this.DomainTextBox.Name = "DomainTextBox";
            this.DomainTextBox.Size = new System.Drawing.Size(48, 23);
            this.DomainTextBox.TabIndex = 5;
            this.DomainTextBox.Text = "/pl/";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DomainTextBox);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.UrlRegexTextBox);
            this.Controls.Add(this.UrlTextBox);
            this.Controls.Add(this.StartButton);
            this.Name = "GUI";
            this.Text = "Crawler";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StartButton;
        private TextBox UrlTextBox;
        private TextBox UrlRegexTextBox;
        private Button StopButton;
        private TextBox DomainTextBox;
    }
}