using SmartLocate.Desktop.Admin.Enums;

namespace SmartLocate.Desktop.Admin.Models.Buses;

public record BusResponse
{
    public BusResponse()
    {
        
    }
    
    public BusResponse(Guid id, string vehicleNumber, string vehicleModel, VehicleStatus status)
    {
        Id = id;
        VehicleNumber = vehicleNumber;
        VehicleModel = vehicleModel;
        Status = status;
    }
    
    public Guid Id { get; init; }
    
    public string VehicleNumber { get; init; }
    
    public string VehicleModel { get; init; }
    
    public VehicleStatus Status { get; init; }
}