using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using Avalonia;
using Avalonia.Controls;
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
    private ServiceProvider? _services;
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        
        if (ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime)
            return;
        
        /*var trayIcons = new TrayIcons
        {
            new TrayIcon
            {
                Icon = new WindowIcon("avares://QuickGraphAvalonia/Assets/avalonia-logo.ico"),
                ToolTipText = "Quick Graph",
                Menu = new NativeMenu
                {
                    new NativeMenuItem("Show")//, (_, _) =>
                    //{
                    //return Locator.Commands.ShowMain.Execute(null);
                    //})
                    ,
                    new NativeMenuItemSeparator(),
                    new NativeMenuItem("Exit")//, (_, _) =>
                    //{
                    //return Locator.Commands.Exit.Execute(null);
                    //})
                }
            }
        };

        TrayIcon.SetIcons(this, trayIcons);
        */
    }
    
    public override void OnFrameworkInitializationCompleted()
    {
        //var culture = new CultureInfo("ar-SA");
        //var culture = new CultureInfo("de-DE")
        var culture = new CultureInfo("fr-FR");
        
        // see fix for Rider
        // https://github.com/AvaloniaUI/avalonia-docs/issues/1076
        Translations.Resources.Culture = culture;
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;
        
        _services = ConfigureServices();

        var vm = _services.GetRequiredService<MainViewModel>();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            desktop.Startup += (sender, args) =>
            {
                Debug.WriteLine("App started");
            };
            desktop.Exit += (sender, args) =>
            {
                Debug.WriteLine("App exited");

                _services.Dispose();
            };
            desktop.ShutdownRequested += (object? sender, ShutdownRequestedEventArgs args) =>
            {
                Debug.WriteLine("App shutdown requested");
                var windows = desktop.Windows;
                args.Cancel = false;
            };
            
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
    
    /// <summary>
    /// reates a ServiceProvider containing services from the provided IServiceCollection
    /// </summary>
    /// <returns></returns>
    private ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        
        services.AddCommonServices();
        
        return services.BuildServiceProvider();
    }
}