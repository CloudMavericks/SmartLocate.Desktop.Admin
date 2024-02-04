namespace SmartLocate.Desktop.Admin.Models.BusRoutes;

public record BusRouteResponse(Guid Id, int RouteNumber, Point StartLocation, List<Point> RoutePoints);