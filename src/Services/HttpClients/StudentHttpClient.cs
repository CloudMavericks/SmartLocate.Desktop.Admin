using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using SmartLocate.Desktop.Admin.Models;
using SmartLocate.Desktop.Admin.Models.Students;

namespace SmartLocate.Desktop.Admin.Services.HttpClients;

public class StudentHttpClient(HttpClient httpClient)
{
    public Task<StudentResponse> GetAsync(Guid id)
    {
        return httpClient.GetFromJsonAsync<StudentResponse>($"/students/{id}");
    }
    
    public Task<ResultSet<StudentResponse>> GetAsync(int page = 1, int pageSize = 10, string searchQuery = "", string orderBy = "Name", bool orderByDescending = false)
    {
        var baseUrl = new StringBuilder($"/students?page={page}&pageSize={pageSize}");
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
        return httpClient.GetFromJsonAsync<ResultSet<StudentResponse>>(baseUrl.ToString());
    }
    
    public async Task CreateAsync(CreateStudentRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/students", request);
        response.EnsureSuccessStatusCode();
    }
    
    public async Task UpdateAsync(UpdateStudentRequest request)
    {
        var response = await httpClient.PutAsJsonAsync($"/students/{request.Id}", request);
        response.EnsureSuccessStatusCode();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var response = await httpClient.DeleteAsync($"/students/{id}");
        response.EnsureSuccessStatusCode();
    }
}