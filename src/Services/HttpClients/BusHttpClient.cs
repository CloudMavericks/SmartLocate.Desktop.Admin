using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using SmartLocate.Desktop.Admin.Models;
using SmartLocate.Desktop.Admin.Models.Buses;

namespace SmartLocate.Desktop.Admin.Services.HttpClients;

public class BusHttpClient(HttpClient httpClient)
{
    public Task<BusResponse> GetAsync(Guid id)
    {
        return httpClient.GetFromJsonAsync<BusResponse>($"/buses/{id}");
    }
    
    public Task<ResultSet<BusResponse>> GetAsync(int page = 1, int pageSize = 10, string searchQuery = "", string orderBy = "VehicleModel", bool orderByDescending = false)
    {
        var baseUrl = new StringBuilder($"/buses?page={page}&pageSize={pageSize}");
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
        return httpClient.GetFromJsonAsync<ResultSet<BusResponse>>(baseUrl.ToString());
    }
    
    public async Task CreateAsync(CreateBusRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/buses", request);
        response.EnsureSuccessStatusCode();
    }
    
    public async Task UpdateAsync(UpdateBusRequest request)
    {
        var response = await httpClient.PutAsJsonAsync($"/buses/{request.Id}", request);
        response.EnsureSuccessStatusCode();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var response = await httpClient.DeleteAsync($"/buses/{id}");
        response.EnsureSuccessStatusCode();
    }
}