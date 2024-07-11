using Shop.Core;
using Shop.Entities;
using Shop.Mock;
using Shop.Repository;
using Shop.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Shop.ViewModel
{
    public class ShopViewModel : NavViewModel
    {
        private readonly IItemModelRepository _itemRepository;
        private readonly IBasketModelRepository _basketModelRepository;

        public ShopViewModel(IItemModelRepository itemRepository, IBasketModelRepository basketModelRepository)
        {
            _itemRepository = itemRepository;
            _basketModelRepository = basketModelRepository;

            CommandBuy = new RelayCommand(param => OnBuy(param));
            Items = new ObservableCollection<ItemModel>();
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

        public async override void OnEnable()
        {
            Items.Clear();
            var items = await _itemRepository.GetItemsAsync();

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
