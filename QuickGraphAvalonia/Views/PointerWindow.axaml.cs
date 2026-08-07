using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace QuickGraphAvalonia.Views;

public partial class PointerWindow : Window
{
    public PointerWindow()
    {
        InitializeComponent();
    }
    
    private void PointerPressedHandler (object sender, PointerPressedEventArgs args)
    {
        var point = args.GetCurrentPoint(sender as Control);
        var x = point.Position.X;
        var y = point.Position.Y;
        var msg = $"Pointer press at {x}, {y} relative to sender.";
        if (point.Properties.IsLeftButtonPressed)
        {
            msg += " Left button pressed.";
        }
        if (point.Properties.IsRightButtonPressed)
        {
            msg += " Right button pressed.";
        }
        
        Results.Text = msg ;
    }

    private void PointerEnteredHandler(object? sender, PointerEventArgs e)
    {
       Results.Text = "Pointer entered.";
    }

    private void PointerExitedHandler(object? sender, PointerEventArgs e)
    {
        Results.Text = "Pointer exited.";
    }

    private void PointerMovedHandler(object? sender, PointerEventArgs e)
    {
        var point = e.GetCurrentPoint(sender as Control);
        var x = point.Position.X;
        var y = point.Position.Y;
        var msg = $"Pointer moved at {x}, {y} relative to sender.";
        
        Results.Text = msg ;
    }
}