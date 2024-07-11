using Newtonsoft.Json;
using Shop.Entities;
using Shop.Repository;

namespace Shop.Mock
{
    public class MockService : IItemModelRepository
    {
        public async Task<ItemModel> GetItemAsync(int itemId)
        {
            var items = await GetItemsAsync();

            return items.FirstOrDefault(element => element.Id == itemId);
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(CancellationToken cancellationToken = default)
        {
            var json = "[\r\n    {\r\n       \"id\":1,\r\n       \"name\":\"Product 1\",\r\n       \"price\":29.99,\r\n       \"image\":\"/product1.png\"\r\n    },\r\n    {\r\n       \"id\":2,\r\n       \"name\":\"Product 2\",\r\n       \"price\":39.99,\r\n       \"image\":\"/product2.png\"\r\n    },\r\n    {\r\n       \"id\":3,\r\n       \"name\":\"Product 3\",\r\n       \"price\":49.99,\r\n       \"image\":\"/product3.png\"\r\n    },\r\n    {\r\n       \"id\":4,\r\n       \"name\":\"Product 4\",\r\n       \"price\":20.99,\r\n       \"image\":\"/product4.png\"\r\n    },\r\n    {\r\n       \"id\":5,\r\n       \"name\":\"Product 5\",\r\n       \"price\":60.99,\r\n       \"image\":\"/product5.png\"\r\n    },\r\n    {\r\n       \"id\":6,\r\n       \"name\":\"Product 6\",\r\n       \"price\":1119.99,\r\n       \"image\":\"/product6.png\"\r\n    }\r\n ]";
            return JsonConvert.DeserializeObject<IEnumerable<ItemModel>>(json);
        }
    }
}
