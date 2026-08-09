using Avalonia;
using System;
using System.Threading.Tasks;
using Avalonia.Threading;

namespace QuickGraphAvalonia;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException += (_, e) =>
        {
            Console.WriteLine(e.ExceptionObject);
        };
        TaskScheduler.UnobservedTaskException += (_, e) =>
        {
            Console.WriteLine(e.Exception);
        };

        Dispatcher.UIThread.UnhandledException += (_, e) =>
        {
            Console.WriteLine(e.Exception);
            e.Handled = true; // optionally keep the app alive after logging
        };

        try
        {
            BuildAvaloniaApp().
                StartWithClassicDesktopLifetime(args);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
    

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
#if DEBUG
            .WithDeveloperTools()
#endif
            .WithInterFont()
            .LogToTrace();
}