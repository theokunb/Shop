using Shop.Entities;

namespace Shop.Repository
{
    public interface IBasketModelRepository
    {
        Task<IEnumerable<BasketModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<BasketModel> CreateAsync(int id, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<BasketModel> GetByItemIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
