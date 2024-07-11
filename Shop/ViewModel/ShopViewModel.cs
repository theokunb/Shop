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
        private readonly IMockService _mockService;
        private readonly IBasketModelRepository _basketModelRepository;

        public ShopViewModel(IMockService mockService, IBasketModelRepository basketModelRepository)
        {
            _mockService = mockService;
            _basketModelRepository = basketModelRepository;

            CommandBuy = new RelayCommand(param => OnBuy(param));
            Items = new ObservableCollection<ItemModel>();

            var items = _mockService.GetItems();

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        public ObservableCollection<ItemModel> Items { get; set; }

        public ICommand CommandBuy { get; }


        private void OnBuy(object param)
        {
            var item = param as ItemModel;

            if (item == null)
                return;

            _basketModelRepository.CreateAsync(item.Id);
        }
    }
}
