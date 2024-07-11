using Shop.Entities;

namespace Shop.Repository
{
    public interface IItemModelRepository
    {
        Task<ItemModel> GetItemAsync(int itemId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ItemModel>> GetItemsAsync(CancellationToken cancellationToken = default);
    }
}
