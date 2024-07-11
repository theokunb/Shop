using Shop.Repository;

namespace Shop.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketModelRepository _basketRepository;
        private readonly IItemModelRepository _itemRepository;

        public BasketService(IBasketModelRepository basketRepository, IItemModelRepository itemRepository)
        {
            _basketRepository = basketRepository;
            _itemRepository = itemRepository;
        }

        public async Task<int> CalculateItemsCountAsync(CancellationToken cancellationToken = default)
        {
            var sum = 0;
            var items = await _basketRepository.GetAllAsync();
            var counts = items.Select(element => element.Count);

            foreach (var item in counts)
            {
                sum += item;
            }

            return sum;
        }

        public async Task<double> CalculateTotalPriceAsync(CancellationToken cancellationToken = default)
        {
            var itemsInBasket = await _basketRepository.GetAllAsync();
            var sum = 0.0;

            foreach(var element in itemsInBasket)
            {
                var item = await _itemRepository.GetItemAsync(element.ItemId);

                if (item == null)
                    continue;

                sum += element.Count * item.Price;
            }

            return sum;
        }
    }
}
