﻿using Shop.Entities;
using Shop.Repository;
using SQLite;

namespace Shop.Services
{
    public class ItemModelRepository : IItemModelRepository
    {
        private readonly SQLiteAsyncConnection _connection;

        public ItemModelRepository(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<ItemModel>().Wait();
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(CancellationToken cancellationToken = default) => 
            await _connection.Table<ItemModel>().ToListAsync();
    }
}