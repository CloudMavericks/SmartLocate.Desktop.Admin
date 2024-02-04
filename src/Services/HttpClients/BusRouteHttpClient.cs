using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using SmartLocate.Desktop.Admin.Models;
using SmartLocate.Desktop.Admin.Models.BusRoutes;

namespace SmartLocate.Desktop.Admin.Services.HttpClients;

public class BusRouteHttpClient(HttpClient httpClient)
{
    public Task<BusRouteResponse> GetAsync(Guid id)
    {
        return httpClient.GetFromJsonAsync<BusRouteResponse>($"/bus-routes/{id}");
    }
    
    public Task<ResultSet<BusRouteResponse>> GetAsync(int page = 1, int pageSize = 10, string searchQuery = "", string orderBy = "Name", bool orderByDescending = false)
    {
        var baseUrl = new StringBuilder($"/bus-routes?page={page}&pageSize={pageSize}");
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
        return httpClient.GetFromJsonAsync<ResultSet<BusRouteResponse>>(baseUrl.ToString());
    }
    
    public async Task CreateAsync(CreateBusRouteRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/bus-routes", request);
        response.EnsureSuccessStatusCode();
    }
    
    public async Task UpdateAsync(UpdateBusRouteRequest request)
    {
        var response = await httpClient.PutAsJsonAsync($"/bus-routes/{request.Id}", request);
        response.EnsureSuccessStatusCode();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var response = await httpClient.DeleteAsync($"/bus-routes/{id}");
        response.EnsureSuccessStatusCode();
    }
}