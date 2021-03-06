using BookinistV1.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookinistV1.Services
{
    //Регистрирует сервисы в DI контейнере
    static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<ISalesService, SalesService>()
            .AddTransient<IUserDialog, UserDialogService>()
            ;
    }
}
