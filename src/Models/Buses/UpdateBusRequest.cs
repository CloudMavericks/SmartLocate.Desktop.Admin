using System.ComponentModel.DataAnnotations;
using SmartLocate.Desktop.Admin.Enums;

namespace SmartLocate.Desktop.Admin.Models.Buses;

public class UpdateBusRequest
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Vehicle number is required", AllowEmptyStrings = false)]
    public string VehicleNumber { get; set; }
    
    [Required(ErrorMessage = "Vehicle model is required", AllowEmptyStrings = false)]
    public string VehicleModel { get; set; }
    
    [Required(ErrorMessage = "Vehicle status is required", AllowEmptyStrings = false)]
    public VehicleStatus Status { get; set; }
}