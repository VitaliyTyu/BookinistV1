using BookinistV1.Data;
using BookinistV1.Services;
using BookinistV1.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace BookinistV1
{
    public partial class App : Application
    {
        public static bool IsDesignTime { get; private set; } = true;

        //создание хоста, используя Singleton
        private static IHost __Host;

        public static IHost Host => __Host 
            ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Host.Services;

        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddDatabase(host.Configuration.GetSection("Database"))
            .AddServices()
            .AddViewModels()
            ;


        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignTime = false;

            var host = Host;

            //если сделаем с await, бд инициализируется после открытия окна приложения
            using (var scope = Services.CreateScope())
                scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync().Wait();
            //используя Wait() можно получить deadock, чтебы его избежать нужно у асинхронных методо вызывать .ConfigureAwait(false)

            base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
    }
}
