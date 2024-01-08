using System.ComponentModel;
using System.Windows;
using Microsoft.AspNetCore.Components.WebView.Wpf;

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
        if(MessageBox.Show("Are you sure you want to exit?", "Exit Velocity", MessageBoxButton.YesNo) == MessageBoxResult.No)
        {
            e.Cancel = true;
        }
        else
        {
            Application.Current.Shutdown();
        }
    }
}