using Shop.Entities;

namespace Shop.Repository
{
    public interface ISortRepository
    {
        Task CreateAsync(SortModel sort, CancellationToken cancellationToken = default);
        Task UpdateAsync(SortModel sort,CancellationToken cancellationToken = default);
        Task<SortModel> GetAsync(CancellationToken cancellationToken = default);
    }
}
