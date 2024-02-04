using SmartLocate.Desktop.Admin.Controls.Leaflet;

namespace SmartLocate.Desktop.Admin.Models.Students;

public class CreateStudentRequest
{
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Address { get; set; }
    
    public Point DefaultPickupDropOffLocation { get; set; }
    
    public Guid DefaultBusRouteId { get; set; }
}