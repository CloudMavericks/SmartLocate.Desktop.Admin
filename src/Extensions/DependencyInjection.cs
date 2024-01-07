using System.Net.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using SmartLocate.Desktop.Admin.Services;

namespace SmartLocate.Desktop.Admin.Extensions;

internal static class DependencyInjection
{
    internal static IServiceProvider Initialize()
    {
        var services = new ServiceCollection();
        services.AddSingleton<LoginWindow>();
        services.AddSingleton<MainWindow>();
        services.AddWpfBlazorWebView();
        services.AddAuthorizationCore();
        services.AddBlazorWebViewDeveloperTools();
        services.AddHttpClient("SmartLocateAPI", client =>
        {
            client.BaseAddress = new Uri(App.BaseAddress);
        });
        services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("SmartLocateAPI"));
        services.AddTransient<AuthenticationStateProvider, VelocityAuthenticationStateProvider>();
        services.AddTransient<VelocityAuthenticationStateProvider>();
        services.AddSingleton<LocalStorageService>();
        services.AddMudServices();
        services.AddSingleton<AppThemeService>();
        services.RegisterHttpClients();
        return services.BuildServiceProvider();
    }

    private static void RegisterHttpClients(this IServiceCollection services)
    {
    }
}