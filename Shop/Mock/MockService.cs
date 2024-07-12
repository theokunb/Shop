using Newtonsoft.Json;
using Shop.Entities;
using Shop.Repository;

namespace Shop.Mock
{
    public class MockService : IItemModelRepository
    {
        public async Task<ItemModel> GetItemAsync(int itemId, CancellationToken cancellationToken = default)
        {
            var items = await GetItemsAsync();

            return items.FirstOrDefault(element => element.Id == itemId);
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(CancellationToken cancellationToken = default)
        {
            var json = "[\r\n    {\r\n       \"id\":1,\r\n       \"name\":\"Product 1\",\r\n       \"price\":29.99,\r\n       \"image\":\"/product1.png\"\r\n    },\r\n    {\r\n       \"id\":2,\r\n       \"name\":\"Product 2\",\r\n       \"price\":39.99,\r\n       \"image\":\"/product2.png\"\r\n    },\r\n    {\r\n       \"id\":3,\r\n       \"name\":\"Product 3\",\r\n       \"price\":49.99,\r\n       \"image\":\"/product3.png\"\r\n    },\r\n    {\r\n       \"id\":4,\r\n       \"name\":\"Product 4\",\r\n       \"price\":20.99,\r\n       \"image\":\"/product4.png\"\r\n    },\r\n    {\r\n       \"id\":5,\r\n       \"name\":\"Product 4\",\r\n       \"price\":60.99,\r\n       \"image\":\"/product5.png\"\r\n    },\r\n    {\r\n       \"id\":6,\r\n       \"name\":\"Product 6\",\r\n       \"price\":1119.99,\r\n       \"image\":\"/product6.png\"\r\n    },\r\n    {\r\n       \"id\":7,\r\n       \"name\":\"Product 7\",\r\n       \"price\":25.99,\r\n       \"image\":\"/product7.png\"\r\n    },\r\n    {\r\n       \"id\":8,\r\n       \"name\":\"Product 8\",\r\n       \"price\":0.99,\r\n       \"image\":\"/product8.png\"\r\n    },\r\n    {\r\n       \"id\":9,\r\n       \"name\":\"Product 9\",\r\n       \"price\":14.50,\r\n       \"image\":\"/product9.png\"\r\n    },\r\n    {\r\n       \"id\":10,\r\n       \"name\":\"Product 10\",\r\n       \"price\":2000.99,\r\n       \"image\":\"/product10.png\"\r\n    },\r\n    {\r\n       \"id\":11,\r\n       \"name\":\"Product 11\",\r\n       \"price\":123.11,\r\n       \"image\":\"/product11.png\"\r\n    },\r\n    {\r\n       \"id\":12,\r\n       \"name\":\"Product 12\",\r\n       \"price\":55.44,\r\n       \"image\":\"/product12.png\"\r\n    },\r\n    {\r\n       \"id\":13,\r\n       \"name\":\"Product 13\",\r\n       \"price\":79.99,\r\n       \"image\":\"/product13.png\"\r\n    },\r\n    {\r\n       \"id\":14,\r\n       \"name\":\"Product 14\",\r\n       \"price\":100.00,\r\n       \"image\":\"/product14.png\"\r\n    },\r\n    {\r\n       \"id\":15,\r\n       \"name\":\"Product 15\",\r\n       \"price\":5.99,\r\n       \"image\":\"/product15.png\"\r\n    },\r\n    {\r\n       \"id\":16,\r\n       \"name\":\"Product 16\",\r\n       \"price\":1999.99,\r\n       \"image\":\"/product16.png\"\r\n    },\r\n    {\r\n       \"id\":17,\r\n       \"name\":\"Product 17\",\r\n       \"price\":55.50,\r\n       \"image\":\"/product17.png\"\r\n    },\r\n    {\r\n       \"id\":18,\r\n       \"name\":\"Product 18\",\r\n       \"price\":20000.99,\r\n       \"image\":\"/product18.png\"\r\n    },\r\n    {\r\n       \"id\":19,\r\n       \"name\":\"Product 19\",\r\n       \"price\":500.00,\r\n       \"image\":\"/product19.png\"\r\n    },\r\n    {\r\n       \"id\":20,\r\n       \"name\":\"Product 20\",\r\n       \"price\":66.66,\r\n       \"image\":\"/product20.png\"\r\n    }\r\n   ]";
            return JsonConvert.DeserializeObject<IEnumerable<ItemModel>>(json);
        }
    }
}
