using Shop.Entities;
using Shop.Repository;
using Shop.Services;
using System.Collections.ObjectModel;

namespace Shop.ViewModel
{
    public class BasketViewModel : NavViewModel
    {
        private readonly IBasketModelRepository _basketRepository;
        private readonly IBasketService _basketService;
        private int _count = 0;
        private double _totalPrice = 0;

        public BasketViewModel(IBasketModelRepository basketRepository, IBasketService basketService)
        {
            _basketRepository = basketRepository;
            _basketService = basketService;

            BasketModels = new ObservableCollection<BasketModel>();
        }

        public ObservableCollection<BasketModel> BasketModels { get; }

        public string Header => $"В корзине {_count} товаров стоимостью {_totalPrice}";

        public async override void OnEnable()
        {
            BasketModels.Clear();

            var items = await _basketRepository.GetAllAsync();

            foreach(var item in items)
            {
                BasketModels.Add(item);
            }

            await FillHeader();
        }

        private async Task FillHeader()
        {
            _count = await _basketService.CalculateItemsCountAsync();
            _totalPrice = await _basketService.CalculateTotalPriceAsync();

            OnPropertyChanged(nameof(Header));
        }
    }
}
