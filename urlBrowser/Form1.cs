using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace urlBrowser
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser browser;
        private string urlsFilePath = "C:\\browsertemp\\urls.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);

            browser = new ChromiumWebBrowser();
            browser.Dock = DockStyle.Fill;
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
            Controls.Add(browser);
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            browser.GetBrowser().MainFrame.GetSourceAsync().ContinueWith(task =>
            {
                var htmlContent = task.Result;

                var urls = ExtractResourceUrls(htmlContent);
                SaveUrlsToFile(urls);
            });
        }

        private string[] ExtractResourceUrls(string htmlContent)
        {
            var regexPattern = @"(http[s]?://(?:[a-zA-Z]|[0-9]|[$-_@.&+]|[!*\\(\\),]|(?:%[0-9a-fA-F][0-9a-fA-F]))+)";

            var matches = System.Text.RegularExpressions.Regex.Matches(htmlContent, regexPattern);

            var urls = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                urls[i] = matches[i].Groups[1].Value;
            }

            return urls;
        }

        private void SaveUrlsToFile(string[] urls)
        {
            using (var writer = new StreamWriter(urlsFilePath))
            {
                foreach (var url in urls)
                {
                    writer.WriteLine(url);
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;

            if (!string.IsNullOrEmpty(url))
            {
                browser.Load(url);
            }
        }
    }
}