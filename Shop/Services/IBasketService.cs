namespace Shop.Services
{
    public interface IBasketService
    {
        Task<int> CalculateItemsCountAsync();
        Task<double> CalculateTotalPriceAsync();
    }
}
