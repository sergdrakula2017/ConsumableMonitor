using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using ConsumableMonitor.App.ViewModels;
using ConsumableMonitor.App.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace ConsumableMonitor.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IHost? host = Host.CreateDefaultBuilder(e.Args)
            .ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddSingleton<HttpClient>();
            })
            .ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddSingleton<ServerConnectionCheckerViewModel>();
            })
            .ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddSingleton<ServerConnectionCheckerView>();
            })
            .ConfigureServices(ServiceCollection =>
            {
                ServiceCollection.AddScoped<Page1>();
            }).ConfigureServices(ServiceCollection =>
            {
                ServiceCollection.AddSingleton<StartPage>();
            })

            .ConfigureServices(ServiceCollection =>
            {
                ServiceCollection.AddScoped<AddData>();
            }).ConfigureServices(ServiceCollection =>
            {
                ServiceCollection.AddSingleton<AddDataViewModel>();
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
}
