using Diosk.Model;
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
        int resultPrice = 0;

        Diosk.Model.Menu menu = new Diosk.Model.Menu();
        public Order()
        {
            InitializeComponent();

            this.Loaded += load_Menu;
        }

        private void load_Menu(object sender, RoutedEventArgs e)
        {
            menu.Load();

            lvFood.ItemsSource = menu.All;

            totalPrice.Text = resultPrice.ToString("전체 금액 : " + resultPrice);
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

            if (lvFood.SelectedItem != null)
            {
                orderlist.Items.Add(new Food() { Name = food.Name, Count = food.Count, Price = food.Price });

                resultPrice += food.Price;

                totalPrice.Text = resultPrice.ToString("전체 금액 : " + resultPrice);
            }   
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
            lvFood.ItemsSource = menu.Smoothie;
        }

        private void Ade_Click(object sender, RoutedEventArgs e)
        {
            lvFood.ItemsSource = menu.Ade;
        }

        private void Tea_Click(object sender, RoutedEventArgs e)
        {

        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            lvFood.ItemsSource = menu.All;
        }

        private void AllCancel_Click(object sender, RoutedEventArgs e)
        {
            orderlist.Items.Clear();

            resultPrice = 0;
            totalPrice.Text = resultPrice.ToString("전체 금액 : " + resultPrice);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Food order = (orderlist.SelectedItem as Food);

            if(orderlist.SelectedItem != null)
            {
                orderlist.Items.Remove(order);

                resultPrice -= order.Price;
                totalPrice.Text = resultPrice.ToString("전체 금액 : " + resultPrice);
            }            
        }

        private void Orderlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            Food order = (orderlist.SelectedItem as Food);

            if(orderlist.SelectedItem != null)
            {
                order.Count++;

                resultPrice += order.Price;
                totalPrice.Text = resultPrice.ToString("전체 금액 : " + resultPrice);
            }
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            Food order = (orderlist.SelectedItem as Food);

            if (orderlist.SelectedItem != null)
            {
                order.Count--;

                resultPrice -= order.Price;
                totalPrice.Text = resultPrice.ToString("전체 금액 : " + resultPrice);
            }
        }
    }
}
