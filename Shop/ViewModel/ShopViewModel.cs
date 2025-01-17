﻿using Shop.Core;
using Shop.Entities;
using Shop.Repository;
using Shop.Services;
using Shop.View;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Shop.ViewModel
{
    public class ShopViewModel : NavViewModel
    {
        private readonly IBasketModelRepository _basketModelRepository;
        private readonly MeasureService _measureService;
        private double _itemWidth;
        private double _itemHeight;
        private Thickness _itemMargin;
        private int _itemsCount;

        public ShopViewModel(IBasketModelRepository basketModelRepository,
            MeasureService measureService)
        {
            _basketModelRepository = basketModelRepository;

            CommandBuy = new RelayCommand(param => OnBuy(param));
            CommandSizeChanged = new RelayCommand(param => OnSizeChanged(param));
            CommandLoaded = new RelayCommand(param => OnLoaded(param));
            Items = new ObservableCollection<ItemModel>();
            ItemWidth = 400;
            ItemHeight = 120;
            ItemMargin = new Thickness(0);
            _measureService = measureService;

            ItemsCountChanged += OnItemsCountChanged;
        }

        ~ShopViewModel()
        {
            ItemsCountChanged -= OnItemsCountChanged;
        }

        private event Action ItemsCountChanged;

        public double ItemWidth
        {
            get => _itemWidth;
            set
            {
                _itemWidth = value;
                OnPropertyChanged(nameof(ItemWidth));
            }
        }
        public double ItemHeight
        {
            get => _itemHeight;
            set
            {
                _itemHeight = value;
                OnPropertyChanged(nameof(ItemHeight));
            }
        }
        public Thickness ItemMargin
        {
            get => _itemMargin;
            set
            {
                _itemMargin = value;
                OnPropertyChanged(nameof(ItemMargin));
            }
        }
        public int ItemsCount
        {
            get => _itemsCount;
            set
            {
                if(_itemsCount == value)
                    return;

                _itemsCount = value;
                ItemsCountChanged?.Invoke();
            }
        }
        public ICommand CommandBuy { get; }
        public ICommand CommandSizeChanged { get; }
        public ICommand CommandLoaded { get; }
        public ObservableCollection<ItemModel> Items { get; set; }


        private void OnBuy(object param)
        {
            var item = param as ItemModel;

            if (item == null)
                return;

            _basketModelRepository.CreateAsync(item.Id);
        }

        private void OnSizeChanged(object param)
        {
            var view = param as ShopView;

            if (view == null)
                return;

            ItemsCount = _measureService.Measure(view.ActualHeight, view.ActualWidth, ItemHeight, ItemWidth, DirectionMode.Vertical, ItemMargin);
        }

        private void OnLoaded(object param)
        {
            OnSizeChanged(param);
        }

        private async void OnItemsCountChanged() =>
            await _measureService.FillItemsAsync(Items, ItemsCount);
    }
}
