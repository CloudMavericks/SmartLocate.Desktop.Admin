using MudBlazor;

namespace SmartLocate.Desktop.Admin.Shared;

public static class AppTheme
{
    public static readonly MudTheme Default = new MudTheme()
    {
        Palette = new PaletteLight()
        {
            Primary = "#6750A4",
            PrimaryLighten = "#EADDFF",
            PrimaryDarken = "#21005D",
            Secondary = "#625B71",
            SecondaryLighten = "#E8DEF8",
            SecondaryDarken = "#1D192B"
        },
        PaletteDark = new PaletteDark()
        {
            Primary = "#D0BCFF",
            PrimaryLighten = "#4F378B",
            PrimaryDarken ="#EADDFF",
        },
        LayoutProperties = new LayoutProperties()
        {
            DefaultBorderRadius = "24px",
        },
    };
}