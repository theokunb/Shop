using Shop.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Shop.View
{
    /// <summary>
    /// Логика взаимодействия для ShopView.xaml
    /// </summary>
    public partial class ShopView : UserControl
    {
        public ShopView()
        {
            InitializeComponent();
        }

        private void Item_Buy(object sender, RoutedEventArgs e)
        {
            var item = sender as Item;
            (DataContext as ShopViewModel).CommandBuy.Execute(item?.DataContext);
        }
    }
}
