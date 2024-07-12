using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Shop.View
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public Item()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register(nameof(Image), typeof(ImageSource), typeof(Item), new PropertyMetadata(null));
        public ImageSource Image
        {
            get => (ImageSource)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }


        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(Item), new PropertyMetadata(null));
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty TitleFontSizeProperty =
            DependencyProperty.Register(nameof(TitleFontSize), typeof(int), typeof(Item), new PropertyMetadata(null));
        public int TitleFontSize
        {
            get => (int)GetValue(TitleFontSizeProperty);
            set => SetValue(TitleFontSizeProperty, value);
        }


        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register(nameof(Price), typeof(double), typeof(Item), new PropertyMetadata(null));
        public double Price
        {
            get => (double)GetValue(PriceProperty);
            set => SetValue(PriceProperty, value);
        }

        public static readonly DependencyProperty PriceFontSizeProperty =
            DependencyProperty.Register(nameof(PriceFontSize), typeof(int), typeof(Item), new PropertyMetadata(null));
        public int PriceFontSize
        {
            get => (int)GetValue(PriceFontSizeProperty);
            set => SetValue(PriceFontSizeProperty, value);
        }

        public static readonly RoutedEvent BuyEvent =
            EventManager.RegisterRoutedEvent(nameof(Buy), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Item));

        public event RoutedEventHandler Buy
        {
            add { AddHandler(BuyEvent, value); }
            remove{ RemoveHandler(BuyEvent, value); }
        }

        private void RaiseBuyEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(Item.BuyEvent);
            RaiseEvent(args);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseBuyEvent();
        }
    }
}
