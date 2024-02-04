using System.Drawing;

namespace SmartLocate.Desktop.Admin.Controls.Leaflet;

public class LatLng : IEquatable<LatLng>
{
    public float Lat { get; set; }

    public float Lng { get; set; }

    public float Alt { get; set; }

    private PointF ToPointF() => new(Lat, Lng);

    public LatLng() { }

    public LatLng(PointF position) : this(position.X, position.Y) { }

    public LatLng(float lat, float lng)
    {
        Lat = lat;
        Lng = lng;
    }

    public LatLng(float lat, float lng, float alt) : this(lat, lng)
    {
        Alt = alt;
    }
    
    public override string ToString() => $"LatLng({Lat}, {Lng})";

    public bool Equals(LatLng other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Lat.Equals(other.Lat) && Lng.Equals(other.Lng) && Alt.Equals(other.Alt);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((LatLng)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Lat, Lng, Alt);
    }

    public static bool operator ==(LatLng left, LatLng right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(LatLng left, LatLng right)
    {
        return !Equals(left, right);
    }
    
    public static implicit operator PointF(LatLng latLng) => latLng.ToPointF();
}