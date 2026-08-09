using Microsoft.Extensions.DependencyInjection;
using QuickGraphAvalonia.Interfaces;
using QuickGraphAvalonia.Services;
using QuickGraphAvalonia.ViewModels;

namespace QuickGraphAvalonia.ExtensionMethods;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddSingleton<IRepository, Repository>();
        collection.AddTransient<IBusinessService, BusinessService>();
        collection.AddTransient<MainViewModel>();
    }
}