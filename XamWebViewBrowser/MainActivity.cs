using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XamWebViewBrowser
{
    using Android.Webkit;

    [Activity(Label = "XamWebViewBrowser", MainLauncher = true, Icon = "@drawable/icon", HardwareAccelerated = true)]
    public class MainActivity : Activity
    {
        private EditText editText;

        private WebView webView;

        private WebChromeClient webChromeClient;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.Main);

            var goButton = this.FindViewById<Button>(Resource.Id.goButton);

            this.editText = this.FindViewById<EditText>(Resource.Id.urlText);

            this.webChromeClient = new WebChromeClient();
            this.webView = this.FindViewById<WebView>(Resource.Id.webView);
            this.webView.Settings.JavaScriptEnabled = true;
            this.webView.SetWebChromeClient(this.webChromeClient);

            goButton.Click += delegate
                {
                    this.webView.LoadUrl(this.editText.Text);
                };
        }
    }
}

