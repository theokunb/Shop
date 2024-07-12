using Shop.Core;
using Shop.Services;
using System.Windows.Input;

namespace Shop.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateHomeCommand = new RelayCommand(param => OnHome());
            NavigateBasketCommand = new RelayCommand(param => OnBasket());

            NavigationService.NavigateTo<ShopViewModel>();
        }

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }
        public ICommand NavigateHomeCommand { get; set; }
        public ICommand NavigateBasketCommand { get; set; }

        private void OnHome()
        {
            NavigationService.NavigateTo<ShopViewModel>();
        }

        private void OnBasket()
        {
            NavigationService.NavigateTo<BasketViewModel>();
        }
    }
}
