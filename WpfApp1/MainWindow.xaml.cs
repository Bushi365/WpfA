using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace WpfApp1
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Game> Games { get; set; }
        public ObservableCollection<Game> CartItems { get; set; }
        private int cartItemCount;
        public int CartItemCount
        {
            get { return cartItemCount; }
            set
            {
                cartItemCount = value;
                OnPropertyChanged("CartItemCount");
            }
        }
        private double cartTotal;
        public double CartTotal
        {
            get { return cartTotal; }
            set
            {
                cartTotal = value;
                OnPropertyChanged("CartTotal");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Games = new ObservableCollection<Game>
    {
        new Game { Name = "Приключение виртуального мира", Price = 49.99 },
        new Game { Name = "Стратегия мирового завоевания", Price = 29.99 },
        new Game { Name = "Гонки по галактике", Price = 39.99 }
    };
            CartItems = new ObservableCollection<Game>();
            DataContext = this;

            // Create UI elements for each game
            foreach (var game in Games)
            {
                var gamePanel = new StackPanel();
           
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            var game = (sender as Button).Tag as Game;
            CartItems.Add(game);
            CartItemCount = CartItems.Count;
            CartTotal += game.Price;
        }

        private void ConfirmPurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show($"Вы действительно хотите купить товары на сумму {CartTotal}?", "Подтверждение покупки", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Покупка завершена!");
                CartItems.Clear();
                CartItemCount = 0;
                CartTotal = 0; 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class Game
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }
       

        private void CartIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           Window2 window2 = new Window2();
            window2.Show();
            this.Hide();
        }
    }
}




