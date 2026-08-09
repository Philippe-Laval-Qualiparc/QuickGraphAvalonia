using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace QuickGraphAvalonia.Views;

public partial class DragDropWindow : Window
{
    public DragDropWindow()
    {
        InitializeComponent();
        
        DragDrop.AddDragOverHandler(DropZone, OnDragOver);
        DragDrop.AddDropHandler(DropZone, OnDrop);
        DragDrop.AddDragEnterHandler(DropZone, OnDragEnter);
        DragDrop.AddDragLeaveHandler(DropZone, OnDragLeave);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnDragEnter(object? sender, DragEventArgs e)
    {
        DropZone.Background = Brushes.LightBlue;
    }

    /// <summary>
    /// The pointer leaves the target element while dragging.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnDragLeave(object? sender, DragEventArgs e)
    {
        DropZone.Background = new SolidColorBrush(Color.Parse("#F5F5F5"));
    }

    /// <summary>
    /// The pointer moves over the target element while dragging. Fires continuously.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnDragOver(object? sender, DragEventArgs e)
    {
        e.DragEffects = e.DataTransfer.Formats.Contains(DataFormat.Text)
                        || e.DataTransfer.Formats.Contains(DataFormat.File)
            ? DragDropEffects.Copy
            : DragDropEffects.None;
    }

    /// <summary>
    /// The user releases the pointer over the target element
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnDrop(object? sender, DragEventArgs e)
    {
        DropZone.Background = new SolidColorBrush(Color.Parse("#F5F5F5"));

        if (e.DataTransfer.Formats.Contains(DataFormat.Text))
        {
            StatusText.Text = $"Dropped text: {e.DataTransfer.TryGetText()}";
        }
        else if (e.DataTransfer.Formats.Contains(DataFormat.File))
        {
            var files = e.DataTransfer.TryGetFiles();
            if (files != null)
            {
                StatusText.Text = $"Dropped {files.Count()} file(s)";
            }
        }
    }
}