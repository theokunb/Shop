using Shop.Entities;
using Shop.Repository;

namespace Shop.Services
{
    public class BasketDtoModelFactory
    {
        private readonly IItemModelRepository _itemRepository;
        private readonly IBasketModelRepository _basketRepository;

        public BasketDtoModelFactory(IItemModelRepository itemRepository, IBasketModelRepository basketRepository)
        {
            _itemRepository = itemRepository;
            _basketRepository = basketRepository;
        }

        public async Task<BasketDtoModel> CreateAsync(int itemId, CancellationToken cancellationToken = default)
        {
            var itemModel = await _itemRepository.GetItemAsync(itemId, cancellationToken);
            var basketModel = await _basketRepository.GetByItemIdAsync(itemId, cancellationToken);

            return new BasketDtoModel
            {
                Name = itemModel.Name,
                Price = itemModel.Price,
                Image = itemModel.Image,
                Count = basketModel.Count,
            };
        }
    }
}
