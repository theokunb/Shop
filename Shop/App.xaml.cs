using Microsoft.Extensions.DependencyInjection;
using Shop.Services;
using Shop.View;
using Shop.ViewModel;
using System.Windows;

namespace Shop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            services.AddScoped(provider => new ShopView
            {
                DataContext = provider.GetRequiredService<ShopViewModel>()
            });

            services.AddScoped(provider => new BasketView
            {
                DataContext = provider.GetRequiredService<BasketViewModel>()
            });

            services.AddScoped<MainViewModel>();
            services.AddScoped<ShopViewModel>();
            services.AddScoped<BasketViewModel>();
            services.AddScoped<INavigationService, NavigationService>();

            services.AddScoped<Func<Type, BaseViewModel>>(provider => viewmodelType => (BaseViewModel)provider.GetRequiredService(viewmodelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
