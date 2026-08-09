using System.Globalization;
using System.Threading;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Platform;
using Microsoft.Extensions.DependencyInjection;
using QuickGraphAvalonia.ExtensionMethods;
using QuickGraphAvalonia.ViewModels;
using QuickGraphAvalonia.Views;

namespace QuickGraphAvalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    public override void OnFrameworkInitializationCompleted()
    {
        //var culture = new CultureInfo("ar-SA");
        //var culture = new CultureInfo("de-DE")
        var culture = new CultureInfo("fr-FR");
        
        Translations.Resources.Culture = culture;
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;
        
        // Register all the services needed for the application to run
        var collection = new ServiceCollection();
        collection.AddCommonServices();

        // Creates a ServiceProvider containing services from the provided IServiceCollection
        var services = collection.BuildServiceProvider();

        var vm = services.GetRequiredService<MainViewModel>();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            MainWindow mainWindow = new MainWindow
            {
                DataContext = vm
            };
            
            if (culture.TextInfo.IsRightToLeft)
            {
                mainWindow.FlowDirection = FlowDirection.RightToLeft;
            }
            
            desktop.MainWindow = mainWindow;
        }
        // else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        // {
        //     singleViewPlatform.MainView = new MainView
        //     {
        //         DataContext = vm
        //     };
        // }

        base.OnFrameworkInitializationCompleted();
    }
}