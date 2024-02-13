using System.ComponentModel;
using System.Windows;
using Microsoft.AspNetCore.Components.WebView.Wpf;
using Microsoft.Extensions.DependencyInjection;
using SmartLocate.Desktop.Admin.Services;

namespace SmartLocate.Desktop.Admin;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var webView = new BlazorWebView
        {
            HostPage = @"wwwroot\index.html"
        };
        webView.Services = App.ServiceProvider;
        webView.RootComponents.Add(new RootComponent
        {
            ComponentType = typeof(Main),
            Selector = "#app"
        });
        Content = webView;
    }
    
    private void MainWindow_OnClosing(object sender, CancelEventArgs e)
    {
        var localStorageService = App.ServiceProvider.GetRequiredService<LocalStorageService>();
        if (localStorageService.GetItem<string>("close_mode") != "logout")
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit Velocity", MessageBoxButton.YesNo) ==
                MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}