using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using SmartLocate.Desktop.Admin.Constants;

namespace SmartLocate.Desktop.Admin.Services;

public class VelocityAuthenticationStateProvider(HttpClient httpClient, LocalStorageService localStorageService)
    : AuthenticationStateProvider
{
    public void MarkUserAsAuthenticated(string userName)
    {
        var authenticatedUser = new ClaimsPrincipal(
            new ClaimsIdentity(new[]
            {
                    new Claim(SmartLocateClaimTypes.AdminName, userName)
            }, "apiauth", SmartLocateClaimTypes.AdminName, SmartLocateClaimTypes.Type));

        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

        NotifyAuthenticationStateChanged(authState);
    }

    public void MarkUserAsLoggedOut()
    {
        var anonymousUser =
            new ClaimsPrincipal(new ClaimsIdentity(null, null, SmartLocateClaimTypes.AdminName,
                SmartLocateClaimTypes.Type));
        var authState = Task.FromResult(new AuthenticationState(anonymousUser));

        NotifyAuthenticationStateChanged(authState);
    }

    public async Task<ClaimsPrincipal> GetAuthenticationStateProviderUserAsync()
    {
        var state = await GetAuthenticationStateAsync();
        var authenticationStateProviderUser = state.User;
        return authenticationStateProviderUser;
    }

    public ClaimsPrincipal AuthenticationStateUser { get; set; }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var savedToken = localStorageService.GetItem<string>("token");
        if (string.IsNullOrWhiteSpace(savedToken))
        {
            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(null, null,
                SmartLocateClaimTypes.AdminName, SmartLocateClaimTypes.Type))));
        }
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
        var state = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(
            GetClaimsFromJwt(savedToken).ToList(), "jwt", SmartLocateClaimTypes.AdminName,
            SmartLocateClaimTypes.Type)));
        AuthenticationStateUser = state.User;
        return Task.FromResult(state);
    }

    private static List<Claim> GetClaimsFromJwt(string jwt)
    {
        var claims = new List<Claim>();
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        if (keyValuePairs == null) 
            return claims;

        claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value?.ToString() ?? "")));
        return claims;
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}