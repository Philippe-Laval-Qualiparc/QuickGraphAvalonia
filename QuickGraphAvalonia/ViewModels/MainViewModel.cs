using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuickGraphAvalonia.Views;

namespace QuickGraphAvalonia.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] public partial string Greeting { get; set; } = "Welcome to Avalonia!";

    [ObservableProperty] public partial bool IsLightTheme { get; set; } = true;
    [ObservableProperty] public partial bool IsDarkTheme { get; set; } = false;
    [ObservableProperty] public partial bool ShowToolbar { get; set; } = false;
    [ObservableProperty] public partial bool ShowStatusBar { get; set; } = true;


    [RelayCommand]
    private void ShowWebView()
    {
        Debug.WriteLine("ShowWebViewCommand");
        WebWindow webWindow = new WebWindow
        {
            DataContext = new WebViewModel()
        };
        webWindow.Show();
    }
    
    [RelayCommand]
    private void ShowPointer()
    {
        Debug.WriteLine("ShowPointerCommand");
        PointerWindow pointerWindow = new PointerWindow
        {
            DataContext = new PointerViewModel()
        };
        pointerWindow.Show();
    }
    
    [RelayCommand]
    private void Open()
    {
        Debug.WriteLine("OpenCommand");
        DrawingWindow drawingWindow = new DrawingWindow
        {
            DataContext = new DrawingViewModel()
        };
        drawingWindow.Show();
    }

    [RelayCommand]
    private void Exit()
    {
        Debug.WriteLine("ExitCommand");
        System.Environment.Exit(0);
    }
}