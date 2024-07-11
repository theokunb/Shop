using Shop.Entities;

namespace Shop.Repository
{
    public interface IItemModelRepository
    {
        Task<ItemModel> GetItemAsync(int itemId);
        Task<IEnumerable<ItemModel>> GetItemsAsync(CancellationToken cancellationToken = default);
    }
}
