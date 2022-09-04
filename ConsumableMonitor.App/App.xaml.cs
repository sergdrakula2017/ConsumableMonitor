using System.Net.Http;
using System.Windows;
using ConsumableMonitor.App.ViewModels;
using ConsumableMonitor.App.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace ConsumableMonitor.App;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        IHost? host = Host.CreateDefaultBuilder(e.Args)
            .ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddTransient(provider =>
                {
                    HttpClient client = new();
                    client.BaseAddress = new("http://172.17.20.75:5240/");
                    return client;
                });
            })
            .ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddSingleton<ServerConnectionCheckerViewModel>();
                serviceCollection.AddTransient<AddNewConsumableViewModel>();
                serviceCollection.AddTransient<AddNewEquipmentViewModel>();
                serviceCollection.AddTransient<AddNewConsumableModelViewModel>();
                serviceCollection.AddSingleton<MainWindowViewModel>();
            })
            .ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddTransient<AddNewEquipmentView>();
                serviceCollection.AddTransient<AddNewConsumableView>();//
                serviceCollection.AddTransient<AddNewConsumableModelView>();
                serviceCollection.AddSingleton<MainWindowView>();
                serviceCollection.AddSingleton<ServerConnectionCheckerView>();
            }).UseDefaultServiceProvider(options =>
            {
#if DEBUG
                options.ValidateScopes = true;
#else
                options.ValidateScopes = false;
#endif
            })
            .Build();
        Ioc.Default.ConfigureServices(host.Services);
        await host.StartAsync().ConfigureAwait(true);
    }
}