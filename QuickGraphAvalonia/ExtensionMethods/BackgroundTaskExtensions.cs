using System.Threading;
using Avalonia.Controls.ApplicationLifetimes;
using QuickGraphAvalonia.Interfaces;

namespace QuickGraphAvalonia.ExtensionMethods;

public static class BackgroundTaskExtensions
{
    public static void Attach(this IBackgroundTask task, IApplicationLifetime lifetime)
    {
        switch (lifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                desktop.Startup += async (_, _) => await task.StartAsync(CancellationToken.None);
                desktop.Exit += async (_, _) => await task.StopAsync(CancellationToken.None);
                break;
            
            case ISingleViewApplicationLifetime singleView when singleView.MainView is { } view:
                view.AttachedToVisualTree += async (_, _) => await task.StartAsync(CancellationToken.None);
                view.DetachedFromVisualTree += async (_, _) => await task.StopAsync(CancellationToken.None);
                break;
        }
    }
}