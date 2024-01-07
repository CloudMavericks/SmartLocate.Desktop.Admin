using MudBlazor;
using SmartLocate.Desktop.Admin.Shared.Components;

namespace SmartLocate.Desktop.Admin.Extensions;

public static class DialogExtensions
{
    public static async Task<bool> ShowDeleteDialog(this IDialogService dialogService, string title, string content,
        string yesText = "Delete", string cancelText = "Cancel", DialogOptions options = null)
    {
        var dialogParameters = new DialogParameters
        {
            { nameof(DeleteDialog.ContentText), content },
            { nameof(DeleteDialog.ButtonText), yesText },
            { nameof(DeleteDialog.CancelText), cancelText }
        };

        options ??= new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };
         
        var dialog = await dialogService.ShowAsync<DeleteDialog>(title, dialogParameters, options);
        var result = await dialog.Result;
        return result.Data != null && (bool)result.Data;
    }
}