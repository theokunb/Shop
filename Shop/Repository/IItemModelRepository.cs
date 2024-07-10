using Shop.Entities;

namespace Shop.Repository
{
    public interface IItemModelRepository
    {
        Task<IEnumerable<ItemModel>> GetItemsAsync(CancellationToken cancellationToken = default);
    }
}
