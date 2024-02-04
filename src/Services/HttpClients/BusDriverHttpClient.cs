using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using SmartLocate.Desktop.Admin.Models;
using SmartLocate.Desktop.Admin.Models.BusDrivers;

namespace SmartLocate.Desktop.Admin.Services.HttpClients;

public class BusDriverHttpClient(HttpClient httpClient)
{
    public Task<BusDriverResponse> GetAsync(Guid id)
    {
        return httpClient.GetFromJsonAsync<BusDriverResponse>($"/bus-drivers/{id}");
    }
    
    public Task<ResultSet<BusDriverResponse>> GetAsync(int page = 1, int pageSize = 10, string searchQuery = "", string orderBy = "Name", bool orderByDescending = false)
    {
        var baseUrl = new StringBuilder($"/bus-drivers?page={page}&pageSize={pageSize}");
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
        return httpClient.GetFromJsonAsync<ResultSet<BusDriverResponse>>(baseUrl.ToString());
    }
    
    public async Task CreateAsync(CreateBusDriverRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/bus-drivers", request);
        response.EnsureSuccessStatusCode();
    }
    
    public async Task UpdateAsync(UpdateBusDriverRequest request)
    {
        var response = await httpClient.PutAsJsonAsync($"/bus-drivers/{request.Id}", request);
        response.EnsureSuccessStatusCode();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var response = await httpClient.DeleteAsync($"/bus-drivers/{id}");
        response.EnsureSuccessStatusCode();
    }
}