using Shop.Core;
using Shop.Services;
using System.Windows.Input;

namespace Shop.ViewModel
{
    public class ShopViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        public ShopViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CommandBasketView = new RelayCommand(param => OnBasketView());
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
        public ICommand CommandBasketView { get; }

        public void OnBasketView()
        {
            NavigationService.NavigateTo<BasketViewModel>();
        }
    }
}
