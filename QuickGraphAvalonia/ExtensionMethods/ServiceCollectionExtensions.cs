using Microsoft.Extensions.DependencyInjection;
using QuickGraphAvalonia.Interfaces;
using QuickGraphAvalonia.Services;
using QuickGraphAvalonia.ViewModels;
using QuickGraphAvalonia.Views;

namespace QuickGraphAvalonia.ExtensionMethods;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainWindow>();
        collection.AddSingleton<MainViewModel>();
        
        collection.AddSingleton<IRepository, Repository>();
        collection.AddTransient<IBusinessService, BusinessService>();
        
      //  collection.AddLogging(builder => builder.AddDebug());
    }
}