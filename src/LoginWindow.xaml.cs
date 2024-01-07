using System.Windows;
using Microsoft.AspNetCore.Components.WebView.Wpf;

namespace SmartLocate.Desktop.Admin;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
        var webView = new BlazorWebView
        {
            HostPage = @"wwwroot\login.html",
            HorizontalAlignment = HorizontalAlignment.Stretch,
            HorizontalContentAlignment = HorizontalAlignment.Stretch
        };
        webView.Services = App.ServiceProvider;
        webView.RootComponents.Add(new RootComponent
        {
            ComponentType = typeof(Login),
            Selector = "#login"
        });
        Content = webView;
    }
}