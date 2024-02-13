using System.Drawing;
using SmartLocate.Desktop.Admin.Controls.Leaflet;

namespace SmartLocate.Desktop.Admin.Models;

public record Point(float Latitude, float Longitude)
{
    public string Name { get; set; } = $"[{Latitude},{Longitude}]";

    public static implicit operator LatLng (Point point)
    {
        return new LatLng(point.Latitude, point.Longitude);
    }
    
    public static implicit operator PointF (Point point)
    {
        return new PointF(point.Latitude, point.Longitude);
    }
    
    public static implicit operator Point (LatLng latLng)
    {
        return new Point(latLng.Lat, latLng.Lng);
    }
    
    public static implicit operator Point (PointF pointF)
    {
        return new Point(pointF.X, pointF.Y);
    }
    
    public static bool operator ==(LatLng left, Point right)
    {
        return right == left;
    }
    
    public static bool operator ==(Point left, LatLng right)
    {
        if (left is null)
        {
            return right is null;
        }
        if (right is null)
        {
            return false;
        }
        return Math.Abs(left.Latitude - right.Lat) < 0.00001 && Math.Abs(left.Longitude - right.Lng) < 0.00001;
    }

    public static bool operator !=(LatLng left, Point right)
    {
        return right != left;
    }

    public static bool operator !=(Point left, LatLng right)
    {
        if (left is null)
        {
            return right is not null;
        }
        if (right is null)
        {
            return true;
        }
        return Math.Abs(left.Latitude - right.Lat) > 0.00001 || Math.Abs(left.Longitude - right.Lng) > 0.00001; 
    }
    
    public override string ToString()
    {
        return $"[{Latitude},{Longitude}]";
    }
}