using Shop.Entities;
using System.Collections.ObjectModel;

namespace Shop.Services.SortService
{
    public interface ISortVisitor
    {
        ObservableCollection<BasketDtoModel> Collection { get; set; }
        void Visit(SortByTitle sort);
        void Visit(SortByPrice sort);
    }
}
