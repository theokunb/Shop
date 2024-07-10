using Shop.Core;
using Shop.Services;
using System.Windows.Input;

namespace Shop.ViewModel
{
    public class BasketViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        public BasketViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CommandHomeView = new RelayCommand(param => OnHomeView());
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
        public ICommand CommandHomeView { get; }

        public void OnHomeView()
        {
            NavigationService.NavigateTo<ShopViewModel>();
        }
    }
}
