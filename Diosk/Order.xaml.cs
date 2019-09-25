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
using System.Windows.Shapes;

namespace Diosk
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        Diosk.Model.Menu menu = new Diosk.Model.Menu();
        public Order()
        {
            InitializeComponent();

            this.Loaded += load_Menu;
        }

        private void load_Menu(object sender, RoutedEventArgs e)
        {
            menu.Load();

            lvFood.ItemsSource = menu.Coffee;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Now;

            time.Text = dateTime.ToString("최근 주문 시간 : " + "h시 mm분 ss초");
        }




        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            // as is 시험
            Diosk.Model.Food food = (lvFood.SelectedItem as Diosk.Model.Food);

            // List<FO

            //String name = food.Name;
            //int price = food.Price;
            //int count = food.count;

            //items.Add(new Food { Name = name, Price = price, count = count });
            //orderlist.ItemsSource = items;
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            Diosk.Model.Food food = (lvFood.SelectedItem as Diosk.Model.Food);
            food.Count--;   
        }

        private void Coffee_Click(object sender, RoutedEventArgs e)
        {
            lvFood.ItemsSource = menu.Coffee;
        }

        private void Latte_Click(object sender, RoutedEventArgs e)
        {
            lvFood.ItemsSource = menu.Latte;
        }

        private void Smoothie_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
