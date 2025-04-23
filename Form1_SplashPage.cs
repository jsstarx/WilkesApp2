
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Windows.Forms;

namespace WilkesResourceApp
{
    public class Form1 : Form
    {
        private Panel splashPanel;
        private Button ncworksButton;
        private Button gptButton;

        private Panel webViewPanel;
        private WebView2 webView;
        private Button backButton;

        public Form1()
        {
            InitializeComponent();
            InitializeSplashScreen();
            InitializeWebViewPanel();
        }

        private void InitializeSplashScreen()
        {
            splashPanel = new Panel
            {
                Dock = DockStyle.Fill
            };

            ncworksButton = new Button
            {
                Text = "NCWorks",
                Width = 200,
                Height = 60,
                Top = 100,
                Left = 150
            };
            ncworksButton.Click += (sender, e) => LoadWebPage("https://www.ncworks.gov");

            gptButton = new Button
            {
                Text = "Wilkes Community Resource Guide",
                Width = 300,
                Height = 60,
                Top = 200,
                Left = 100
            };
            gptButton.Click += (sender, e) => LoadWebPage("https://chatgpt.com/g/g-680792c2eb0c8191920e40e93eb5e7de-wilkes-community-resource-assistance-guide");

            splashPanel.Controls.Add(ncworksButton);
            splashPanel.Controls.Add(gptButton);
            this.Controls.Add(splashPanel);
        }

        private void InitializeWebViewPanel()
        {
            webViewPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Visible = false
            };

            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };

            backButton = new Button
            {
                Text = "Back to Menu",
                Dock = DockStyle.Top,
                Height = 40
            };
            backButton.Click += (sender, e) =>
            {
                webViewPanel.Visible = false;
                splashPanel.Visible = true;
            };

            webViewPanel.Controls.Add(webView);
            webViewPanel.Controls.Add(backButton);
            this.Controls.Add(webViewPanel);
        }

        private async void LoadWebPage(string url)
        {
            splashPanel.Visible = false;
            webViewPanel.Visible = true;

            await webView.EnsureCoreWebView2Async(null);
            webView.Source = new Uri(url);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Wilkes Resource App";
            this.ResumeLayout(false);
        }
    }
}
