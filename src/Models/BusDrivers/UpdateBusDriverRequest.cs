namespace SmartLocate.Desktop.Admin.Models.BusDrivers;

public class UpdateBusDriverRequest
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string PhoneNumber { get; set; }
}