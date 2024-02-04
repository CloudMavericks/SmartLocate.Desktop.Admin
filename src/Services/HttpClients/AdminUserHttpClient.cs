using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using SmartLocate.Desktop.Admin.Models;
using SmartLocate.Desktop.Admin.Models.AdminUsers;

namespace SmartLocate.Desktop.Admin.Services.HttpClients;

public class AdminUserHttpClient(HttpClient httpClient)
{
    public Task<AdminUserResponse> GetAsync(Guid id)
    {
        return httpClient.GetFromJsonAsync<AdminUserResponse>($"/admin-users/{id}");
    }
    
    public Task<ResultSet<AdminUserResponse>> GetAsync(int page = 1, int pageSize = 10, string searchQuery = "", string orderBy = "Name", bool orderByDescending = false)
    {
        var baseUrl = new StringBuilder($"/admin-users?page={page}&pageSize={pageSize}");
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            baseUrl.Append($"&searchQuery={searchQuery}");
        }
        if (!string.IsNullOrWhiteSpace(orderBy))
        {
            baseUrl.Append($"&orderBy={orderBy}");
        }
        if (orderByDescending)
        {
            baseUrl.Append($"&orderByDescending={true}");
        }
        return httpClient.GetFromJsonAsync<ResultSet<AdminUserResponse>>(baseUrl.ToString());
    }
    
    public async Task CreateAsync(CreateAdminUserRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/admin-users", request);
        response.EnsureSuccessStatusCode();
    }
    
    public async Task UpdateAsync(UpdateAdminUserRequest request)
    {
        var response = await httpClient.PutAsJsonAsync($"/admin-users/{request.Id}", request);
        response.EnsureSuccessStatusCode();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var response = await httpClient.DeleteAsync($"/admin-users/{id}");
        response.EnsureSuccessStatusCode();
    }
}