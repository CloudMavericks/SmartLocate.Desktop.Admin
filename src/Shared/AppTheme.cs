using MudBlazor;

namespace SmartLocate.Desktop.Admin.Shared;

public static class AppTheme
{
    public static readonly MudTheme Default = new()
    {
        Palette = new PaletteLight()
        {
            Primary = "#6750A4",
            PrimaryDarken = "#21005D",
            PrimaryLighten = "#EADDFF",
            Black = "#222222",
            Background = "#000000",
            BackgroundGrey = "#232323",
            Surface = "#272727",
            DrawerBackground = "#2f2f2f",
            DrawerText = "rgba(255,255,255, 0.50)",
            DrawerIcon = "rgba(255,255,255, 0.50)",
            AppbarBackground = "#6750A4",
            AppbarText = "rgba(255,255,255, 0.70)",
            TextPrimary = "rgba(255,255,255, 0.50)",
            TextSecondary = "rgba(255,255,255, 0.70)",
            ActionDefault = "#adadad",
            ActionDisabled = "rgba(255,255,255, 0.26)",
            ActionDisabledBackground = "rgba(255,255,255, 0.12)",
            Divider = "rgba(255,255,255, 0.12)",
            DividerLight = "rgba(255,255,255, 0.06)",
            TableLines = "rgba(255,255,255, 0.12)",
            LinesDefault = "rgba(255,255,255, 0.12)",
            LinesInputs = "rgba(255,255,255, 0.3)",
            TextDisabled = "rgba(255,255,255, 0.2)",
            Tertiary = "#2f2f2f"
        },
        LayoutProperties = new LayoutProperties()
        {
            DefaultBorderRadius = "24px",
        },
    };
}