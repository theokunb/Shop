using Shop.Entities;
using Shop.Repository;
using SQLite;

namespace Shop.Services
{
    public class SortRepository : ISortRepository
    {
        private readonly SQLiteAsyncConnection _connection;

        public SortRepository(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<SortModel>().Wait();
        }

        public async Task CreateAsync(SortModel sort, CancellationToken cancellationToken = default) =>
            await _connection.InsertAsync(sort);


        public async Task<SortModel> GetAsync(CancellationToken cancellationToken = default) =>
             await _connection.Table<SortModel>().FirstOrDefaultAsync();

        public async Task UpdateAsync(SortModel sort, CancellationToken cancellationToken = default) =>
            await _connection.UpdateAsync(sort);
    }
}
