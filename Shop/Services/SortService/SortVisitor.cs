using Shop.Entities;
using System.Collections.ObjectModel;

namespace Shop.Services.SortService
{
    public class SortVisitor : ISortVisitor
    {
        public ObservableCollection<BasketDtoModel> Collection { get ; set ; }

        public void Visit(SortByTitle sort)
        {
            var sorted = Collection.OrderBy(element => element.Name).ToList();

            Move(sorted);
        }

        public void Visit(SortByPrice sort)
        {
            var sorted = Collection.OrderBy(element => element.Price).ToList();

            Move(sorted);
        }

        private void Move(IList<BasketDtoModel> sorted)
        {
            for (int i = 0; i < sorted.Count(); i++)
            {
                var current = Collection[i];
                var sortedId = sorted.IndexOf(current);
                Collection.Move(i, sortedId);
            }
        }
    }
}
