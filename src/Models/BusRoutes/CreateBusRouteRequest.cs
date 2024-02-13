namespace SmartLocate.Desktop.Admin.Models.BusRoutes;

public class CreateBusRouteRequest
{
    public int RouteNumber { get; set; }
    
    public string RouteName { get; set; }
    
    public Point StartLocation { get; set; }
    
    public List<Point> RoutePoints { get; set; } = [];
}