namespace Shop.Services
{
    public interface IBasketService
    {
        Task<int> CalculateItemsCountAsync(CancellationToken cancellationToken = default);
        Task<double> CalculateTotalPriceAsync(CancellationToken cancellationToken = default);
    }
}
