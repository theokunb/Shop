using Shop.Entities;
using Shop.Repository;
using SQLite;

namespace Shop.Services
{
    public class BasketModelRepository : IBasketModelRepository
    {
        private readonly SQLiteAsyncConnection _connection;

        public BasketModelRepository(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<BasketModel>().Wait();
        }

        public async Task<BasketModel> CreateAsync(int id, CancellationToken cancellationToken = default)
        {
            var basket = await _connection.Table<BasketModel>().Where(element => element.ItemId == id).FirstOrDefaultAsync();

            if(basket == null)
            {
                basket = new BasketModel()
                {
                    ItemId = id,
                    Count = 1
                };

                await _connection.InsertAsync(basket);
            }
            else
            {
                basket.Count += 1;
                await _connection.UpdateAsync(basket);
            }
            
            return basket;
        }

        public async Task<BasketModel> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var basket = await _connection.Table<BasketModel>().Where(element => element.Id == id).FirstOrDefaultAsync();

            if (basket == null)
            {
                return null;
            }

            basket.Count -= 1;

            if (basket.Count == 0)
            {
                await _connection.DeleteAsync(basket);
                return null;
            }
            else
            {
                await _connection.UpdateAsync(basket);
            }

            return basket;
        }

        public async Task<IEnumerable<BasketModel>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _connection.Table<BasketModel>().ToListAsync();

        public Task<BasketModel> GetByItemIdAsync(int id, CancellationToken cancellationToken = default) =>
            _connection.Table<BasketModel>().Where(element => element.ItemId == id).FirstOrDefaultAsync();
    }
}
