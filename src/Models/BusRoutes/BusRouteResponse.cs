namespace SmartLocate.Desktop.Admin.Models.BusRoutes;

public record BusRouteResponse(Guid Id, int RouteNumber, string RouteName, Point StartLocation, List<Point> RoutePoints);