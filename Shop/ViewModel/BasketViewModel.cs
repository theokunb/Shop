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
        private readonly BasketDtoModelFactory _basketDtoModelFactory;
        private int _count = 0;
        private double _totalPrice = 0;

        public BasketViewModel(IBasketModelRepository basketRepository,
            IBasketService basketService,
            BasketDtoModelFactory basketDtoModelFactory)
        {
            _basketRepository = basketRepository;
            _basketService = basketService;
            _basketDtoModelFactory = basketDtoModelFactory;

            BasketModels = new ObservableCollection<BasketDtoModel>();
        }

        public ObservableCollection<BasketDtoModel> BasketModels { get; }
        public string Header => $"В корзине {_count} товаров стоимостью {_totalPrice}";


        public async override void OnEnable()
        {
            BasketModels.Clear();

            var items = await _basketRepository.GetAllAsync();

            foreach(var item in items)
            {
                var dto = await _basketDtoModelFactory.CreateAsync(item.ItemId);
                BasketModels.Add(dto);
            }

            await FillHeaderAsync();
        }

        private async Task FillHeaderAsync(CancellationToken cancellationToken = default)
        {
            _count = await _basketService.CalculateItemsCountAsync(cancellationToken);
            _totalPrice = await _basketService.CalculateTotalPriceAsync(cancellationToken);

            OnPropertyChanged(nameof(Header));
        }
    }
}
