﻿namespace SmartLocate.Desktop.Admin.Models.AdminUsers;

public class UpdateAdminUserRequest
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Password { get; set; }

    public bool IsSuperAdmin { get; set; }
}