using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace QuickGraphAvalonia.ViewModels;

public partial class WebViewModel : ViewModelBase
{
    [RelayCommand]
    private void ShowPrintUserInterface(NativeWebView webView)
    {
        webView?.ShowPrintUI();
    }
}