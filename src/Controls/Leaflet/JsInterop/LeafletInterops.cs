using System.Collections.Concurrent;
using System.Drawing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace SmartLocate.Desktop.Admin.Controls.Leaflet.JsInterop;

public static class LeafletInterops
{

    private static ConcurrentDictionary<string, (IDisposable, string, Layer)> LayerReferences { get; } = new();

    private const string BaseObjectContainer = "window.leaflet";

    public static ValueTask Create(IJSRuntime jsRuntime, Map map) =>
        jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.create", map, DotNetObjectReference.Create(map));

    private static DotNetObjectReference<T> CreateLayerReference<T>(string mapId, T layer) where T : Layer
    {
        var result = DotNetObjectReference.Create(layer);
        LayerReferences.TryAdd(layer.Id, (result, mapId, layer));
        return result;
    }

    private static void DisposeLayerReference(string layerId)
    {
        if (LayerReferences.TryRemove(layerId, out var value))
            value.Item1.Dispose();
    }

    public static ValueTask AddLayer(IJSRuntime jsRuntime, string mapId, Layer layer)
    {
        return layer switch
        {
            TileLayer tileLayer => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addTileLayer", mapId, tileLayer, CreateLayerReference(mapId, tileLayer)),
            MbTilesLayer mbTilesLayer => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addMbTilesLayer", mapId, mbTilesLayer, CreateLayerReference(mapId, mbTilesLayer)),
            ShapefileLayer shapefileLayer => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addShapefileLayer", mapId, shapefileLayer, CreateLayerReference(mapId, shapefileLayer)),
            Marker marker => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addMarker", mapId, marker, CreateLayerReference(mapId, marker)),
            Rectangle rectangle => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addRectangle", mapId, rectangle, CreateLayerReference(mapId, rectangle)),
            Circle circle => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addCircle", mapId, circle, CreateLayerReference(mapId, circle)),
            Polygon polygon => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addPolygon", mapId, polygon, CreateLayerReference(mapId, polygon)),
            Polyline polyline => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addPolyline", mapId, polyline, CreateLayerReference(mapId, polyline)),
            ImageLayer image => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addImageLayer", mapId, image, CreateLayerReference(mapId, image)),
            GeoJsonDataLayer geo => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addGeoJsonLayer", mapId, geo, CreateLayerReference(mapId, geo)),
            _ => throw new NotImplementedException($"The layer {typeof(Layer).Name} has not been implemented."),
        };
    }

    public static async ValueTask RemoveLayer(IJSRuntime jsRuntime, string mapId, string layerId)
    {
        await jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.removeLayer", mapId, layerId);
        DisposeLayerReference(layerId);
    }

    public static ValueTask UpdatePopupContent(IJSRuntime jsRuntime, string mapId, Layer layer) =>
        jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.updatePopupContent", mapId, layer.Id, layer.Popup?.Content);

    public static ValueTask UpdateTooltipContent(IJSRuntime jsRuntime, string mapId, Layer layer) =>
        jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.updateTooltipContent", mapId, layer.Id, layer.Tooltip?.Content);

    public static ValueTask UpdateShape(IJSRuntime jsRuntime, string mapId, Layer layer) =>
        layer switch
        {
            Rectangle rectangle => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.updateRectangle", mapId, rectangle),
            Circle circle => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.updateCircle", mapId, circle),
            Polygon polygon => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.updatePolygon", mapId, polygon),
            Polyline polyline => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.updatePolyline", mapId, polyline),
            _ => throw new NotImplementedException($"The layer {typeof(Layer).Name} has not been implemented."),
        };

    public static ValueTask FitBounds(IJSRuntime jsRuntime, string mapId, PointF corner1, PointF corner2, PointF? padding, float? maxZoom) =>
        jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.fitBounds", mapId, corner1, corner2, padding, maxZoom);

    public static ValueTask PanTo(IJSRuntime jsRuntime, string mapId, PointF position, bool animate, float duration, float easeLinearity, bool noMoveStart) =>
        jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.panTo", mapId, position, animate, duration, easeLinearity, noMoveStart);

    public static ValueTask<LatLng> GetCenter(IJSRuntime jsRuntime, string mapId) =>
        jsRuntime.InvokeAsync<LatLng>($"{BaseObjectContainer}.getCenter", mapId);

    public static ValueTask<float> GetZoom(IJSRuntime jsRuntime, string mapId) =>
        jsRuntime.InvokeAsync<float>($"{BaseObjectContainer}.getZoom", mapId);

    public static ValueTask ZoomIn(IJSRuntime jsRuntime, string mapId, MouseEventArgs e) =>
        jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.zoomIn", mapId, e);

    public static ValueTask ZoomOut(IJSRuntime jsRuntime, string mapId, MouseEventArgs e) =>
        jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.zoomOut", mapId, e);
}