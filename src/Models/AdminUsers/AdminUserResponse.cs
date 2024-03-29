﻿namespace SmartLocate.Desktop.Admin.Models.AdminUsers;

public record AdminUserResponse(Guid Id, string Name, string Email, string PhoneNumber, bool IsSuperAdmin)
{
    public override string ToString()
    {
        return $"{Name} <{Email}>" + (IsSuperAdmin ? " [Super Admin]" : "");
    }
}