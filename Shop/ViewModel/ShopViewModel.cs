using Shop.Core;
using Shop.Entities;
using Shop.Mock;
using Shop.Repository;
using Shop.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Shop.ViewModel
{
    public class ShopViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private readonly IMockService _mockService;

        public ShopViewModel(INavigationService navigationService, IMockService mockService)
        {
            _navigationService = navigationService;
            _mockService = mockService;

            CommandBasketView = new RelayCommand(param => OnBasketView());
            Items = new ObservableCollection<ItemModel>();

            var items = _mockService.GetItems();

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        public ObservableCollection<ItemModel> Items { get; set; }

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
