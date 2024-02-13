using System.Net.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using SmartLocate.Desktop.Admin.Services;
using SmartLocate.Desktop.Admin.Services.HttpClients;

namespace SmartLocate.Desktop.Admin.Extensions;

internal static class DependencyInjection
{
    internal static IServiceProvider Initialize()
    {
        var services = new ServiceCollection();
        services.AddTransient<LoginWindow>();
        services.AddTransient<MainWindow>();
        services.AddWpfBlazorWebView();
        services.AddAuthorizationCore();
        services.AddBlazorWebViewDeveloperTools();
        services.AddHttpClient("SmartLocateAPI", client =>
        {
            client.BaseAddress = new Uri(App.BaseAddress);
        });
        services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("SmartLocateAPI"));
        services.AddTransient<AuthenticationStateProvider, ApplicationAuthStateProvider>();
        services.AddTransient<ApplicationAuthStateProvider>();
        services.AddSingleton<LocalStorageService>();
        services.AddMudServices();
        services.AddSingleton<AppThemeService>();
        services.RegisterHttpClients();
        return services.BuildServiceProvider();
    }

    private static void RegisterHttpClients(this IServiceCollection services)
    {
        services.AddTransient<AdminUserHttpClient>();
        services.AddTransient<BusHttpClient>();
        services.AddTransient<BusDriverHttpClient>();
        services.AddTransient<BusRouteHttpClient>();
        services.AddTransient<StudentHttpClient>();
    }
}