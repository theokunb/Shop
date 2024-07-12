using Shop.Core;
using Shop.Entities;
using Shop.Repository;
using Shop.Services;
using Shop.Services.Sort;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Shop.ViewModel
{
    public class BasketViewModel : NavViewModel
    {
        private readonly IBasketModelRepository _basketRepository;
        private readonly IBasketService _basketService;
        private readonly ISortVisitor _sortVisitor;
        private readonly BasketDtoModelFactory _basketDtoModelFactory;
        private int _count = 0;
        private double _totalPrice = 0;

        public BasketViewModel(IBasketModelRepository basketRepository,
            IBasketService basketService,
            BasketDtoModelFactory basketDtoModelFactory,
            ISortVisitor sortVisitor)
        {
            _basketRepository = basketRepository;
            _basketService = basketService;
            _basketDtoModelFactory = basketDtoModelFactory;

            BasketModels = new ObservableCollection<BasketDtoModel>();
            Sorts = new ObservableCollection<Sort>()
            {
                new SortByTitle("по названию"),
                new SortByPrice("по цене")
            };

            CommandRemove = new RelayCommand(param => OnRemove(param));
            CommandSort = new RelayCommand(param => OnSort(param));
            _sortVisitor = sortVisitor;
        }

        public ObservableCollection<BasketDtoModel> BasketModels { get; }
        public ObservableCollection<Sort> Sorts { get; }
        public string Header => $"В корзине {_count} товаров стоимостью {_totalPrice.ToString("F")}";
        public ICommand CommandRemove { get; }
        public ICommand CommandSort { get; }


        public async override void OnEnable()
        {
            BasketModels.Clear();

            var items = await _basketRepository.GetAllAsync();

            foreach(var item in items)
            {
                var dto = await _basketDtoModelFactory.CreateAsync(item.ItemId);
                BasketModels.Add(dto);
            }

            await FillHeaderAsync();
        }

        private async Task FillHeaderAsync(CancellationToken cancellationToken = default)
        {
            _count = await _basketService.CalculateItemsCountAsync(cancellationToken);
            _totalPrice = await _basketService.CalculateTotalPriceAsync(cancellationToken);

            OnPropertyChanged(nameof(Header));
        }

        private async void OnRemove(object param)
        {
            var dto = param as BasketDtoModel;

            if (dto == null)
                return;
            
            await _basketRepository.DeleteAsync(dto.BasketId);
            BasketModels.Delete(dto);

            await FillHeaderAsync();
        }

        private void OnSort(object param)
        {
            var sort = param as Sort;

            if(sort == null)
                return;

            _sortVisitor.Collection = BasketModels;
            sort.Accept(_sortVisitor);
        }
    }
}
