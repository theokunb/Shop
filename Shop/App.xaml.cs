using Microsoft.Extensions.DependencyInjection;
using Shop.Mock;
using Shop.Repository;
using Shop.Services;
using Shop.Services.Sort;
using Shop.View;
using Shop.ViewModel;
using System.IO;
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
            services.AddScoped<IItemModelRepository, MockService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<ISortVisitor, SortVisitor>();
            services.AddScoped<BasketDtoModelFactory>();
            services.AddScoped<MeasureService>();
            /*services.AddScoped<IItemModelRepository, ItemModelRepository>(provider =>
            {
                var repository =  new ItemModelRepository(Path.Combine("mydb.db"));
                return repository;
            });*/
            services.AddScoped<IBasketModelRepository, BasketModelRepository>(provider =>
            {
                var repository = new BasketModelRepository(Path.Combine("mydb.db"));
                return repository;
            });

            services.AddScoped<Func<Type, NavViewModel>>(provider => viewmodelType => (NavViewModel)provider.GetRequiredService(viewmodelType));

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
