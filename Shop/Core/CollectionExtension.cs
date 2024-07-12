using Shop.Entities;
using System.Collections.ObjectModel;

namespace Shop.Core
{
    public static class CollectionExtension
    {
        public static void Delete(this ObservableCollection<BasketDtoModel> collection, BasketDtoModel model)
        {
            var removeItem = collection.Where(element => element.BasketId == model.BasketId).FirstOrDefault();

            if (removeItem == null)
                return;

            removeItem.Count -= 1;

            if (removeItem.Count < 1)
            {
                collection.Remove(removeItem);
                return;
            }

            var index = collection.IndexOf(model);
            collection.RemoveAt(index);
            collection.Insert(index, model);
        }
    }
}
