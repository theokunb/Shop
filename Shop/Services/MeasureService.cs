using Shop.Entities;
using Shop.Repository;
using System.Collections.ObjectModel;
using System.Windows;

namespace Shop.Services
{
    public class MeasureService
    {
        private readonly IItemModelRepository _itemsRepository;

        public MeasureService(IItemModelRepository modelRepository)
        {
            _itemsRepository = modelRepository;
        }

        private int Measure(double totalSize, double elementSize, double marginSize)
        {
            return (int)(totalSize / (elementSize + marginSize));
        }

        public int Measure(double windowHeight,
            double windowWidth,
            double itemHeight,
            double itemWidth,
            DirectionMode directionMode,
            Thickness margin)
        {
            switch (directionMode)
            {
                case DirectionMode.Horizontal:
                    return Measure(windowWidth, itemWidth, margin.Left + margin.Right);
                case DirectionMode.Vertical:
                    return Measure(windowHeight, itemHeight, margin.Top + margin.Bottom);
                default:
                    return Measure(windowWidth, itemWidth, margin.Left + margin.Right) * Measure(windowHeight, itemHeight, margin.Top + margin.Bottom);
            }
        }

        public async Task FillItemsAsync(ObservableCollection<ItemModel> items, int count, CancellationToken cancellationToken = default)
        {
            var extraCount = items.Count() - count;

            if(extraCount > 0)
            {
                //надо убавить

                for(int i=0; i < extraCount; i++)
                {
                    items.RemoveAt(items.Count() - 1);
                }
            }
            else if(extraCount < 0)
            {
                //надо прибавить
                var allItems = await _itemsRepository.GetItemsAsync(cancellationToken);
                var needItems = allItems.Skip(items.Count()).Take(Math.Abs(extraCount));

                foreach(var item in needItems)
                {
                    items.Add(item);
                }
            }
        }
    }

    public enum DirectionMode
    {
        Horizontal,
        Vertical,
        FillAndExpand
    }
}
