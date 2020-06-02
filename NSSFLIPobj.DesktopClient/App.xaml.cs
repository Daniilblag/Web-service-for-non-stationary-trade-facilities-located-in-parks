using Microsoft.Extensions.DependencyInjection;
using NSSFLIPobj.ApplicationServices.GetDistrictListUseCase;
using NSSFLIPobj.ApplicationServices.Ports.Cache;
using NSSFLIPobj.ApplicationServices.Repositories;
using NSSFLIPobj.DesktopClient.InfrastructureServices.ViewModels;
using NSSFLIPobj.DomainObjects;
using NSSFLIPobj.DomainObjects.Ports;
using NSSFLIPobj.InfrastructureServices.Cache;
using NSSFLIPobj.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NSSFLIPobj.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<nssflipobj>, DomainObjectsMemoryCache<nssflipobj>>();
            services.AddSingleton<NetworkNSSFLIPobjRepository>(
                x => new NetworkNSSFLIPobjRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<nssflipobj>>())
            );
            services.AddSingleton<CachedReadOnlyNSSFLIPobjRepository>(
                x => new CachedReadOnlyNSSFLIPobjRepository(
                    x.GetRequiredService<NetworkNSSFLIPobjRepository>(), 
                    x.GetRequiredService<IDomainObjectsCache<nssflipobj>>()
                )
            );
            services.AddSingleton<IReadOnlyNSSFLIPobjRepository>(x => x.GetRequiredService<CachedReadOnlyNSSFLIPobjRepository>());
            services.AddSingleton<IGetNSSFLIPobjListUseCase, GetNSSFLIPobjListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
