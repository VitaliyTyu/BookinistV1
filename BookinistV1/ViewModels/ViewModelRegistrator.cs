using Microsoft.Extensions.DependencyInjection;

namespace BookinistV1.ViewModels
{
    //регестрирует ViewModels в DI контейнере
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            ;
    }
}
