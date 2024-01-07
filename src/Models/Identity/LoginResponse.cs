namespace SmartLocate.Desktop.Admin.Models.Identity;

public class LoginResponse
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpiresAt { get; set; }
}