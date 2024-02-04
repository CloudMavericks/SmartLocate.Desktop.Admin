using System.Drawing;

namespace SmartLocate.Desktop.Admin.Controls.Leaflet.Events;

public class ResizeEvent : Event
{
    public PointF OldSize { get; set; }
    public PointF NewSize { get; set; }
}