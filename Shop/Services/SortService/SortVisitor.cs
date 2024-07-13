using Shop.Entities;
using System.Collections.ObjectModel;

namespace Shop.Services.SortService
{
    public class SortVisitor : ISortVisitor
    {
        public ObservableCollection<BasketDtoModel> Collection { get ; set ; }

        public void Visit(SortByTitle sort)
        {
            for(int i = 0; i < Collection.Count; i++)
            {
                int max = 0;

                for (int j = 0; j < Collection.Count - i; j++)
                {
                    if (Collection[max].Name.CompareTo(Collection[j].Name) < 0)
                    {
                        max = j;
                    }
                }

                Collection.Move(max, Collection.Count - 1 - i);
            }
        }

        public void Visit(SortByPrice sort)
        {
            for (int i = 0; i < Collection.Count; i++)
            {
                int max = 0;
                for (int j = 0; j < Collection.Count - i; j++)
                {
                    if (Collection[max].Price < Collection[j].Price)
                    {
                        max = j;
                    }
                }

                Collection.Move(max, Collection.Count - 1 - i);
            }

        }
    }
}
