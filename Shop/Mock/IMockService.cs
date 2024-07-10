using Shop.Entities;

namespace Shop.Mock
{
    public interface IMockService
    {
        IEnumerable<ItemModel> GetItems();
    }
}
