using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Diosk.Model;

namespace Diosk
{
    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        Seat payingSeat = null;
        public PaymentWindow(Seat orderInfo)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            payingSeat = new Seat();
            payingSeat.id = orderInfo.id;
            payingSeat.lstOrderFood = orderInfo.lstOrderFood;
            setSeat();
        }

        private void setSeat()
        {
            int total = 0;

            tableId.Text = payingSeat.id.ToString() + "번 테이블";

            if (payingSeat.lstOrderFood != null)
            {
                foreach (Food items in payingSeat.lstOrderFood)
                {
                    foodOrderList.Text += items.Name + " X " + items.Count.ToString() + "\n";
                    total += items.Price;
                }
            }

            totalPrice.Text = "총 금액: " + total.ToString() + "￦";
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("결제를 취소하시겠습니까?", "취소", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Order order = new Order(payingSeat.id);
                order.Show();
                this.Close();
            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("결제하시겠습니까?", "결제 확인", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                TotalData totalData = App.totalData;
                Chatting chatting = App.chatting;

                foreach (Food food in payingSeat.lstOrderFood)
                {
                    setMenuList(totalData, food);
                    setCategoryList(totalData, food);
                    setTotalMoney(totalData, food);
                }

                string sendingMoney = "@2104#총액 " + totalData.paymentMoney.ToString() + "원";

                chatting.Send(sendingMoney);

                totalData.paymentMoney = 0;

                MainWindow main = new MainWindow();
                App.seatDataSource.lstSeatData[payingSeat.id - 1].lstOrderFood.Clear();
                main.Refresh();

                this.Close();
                main.Show();
            }
        }

        public void setTotalMoney(TotalData totalData, Food food)
        {
            totalData.AllMoney += food.Price;
            totalData.paymentMoney += food.Price;
        }

        public void setMenuList(TotalData totalData, Food food)
        {
            if (totalData.MenuList.Find(item => item.Name == food.Name) != null)
            {
                totalData.MenuList.Find(item => item.Name == food.Name).Count += food.Count;
                totalData.MenuList.Find(item => item.Name == food.Name).Price += food.Price;
            }
            else
            {
                totalData.MenuList.Add(food);
            }
            Console.WriteLine("menu count " + totalData.MenuList.Find(item => item.Name == food.Name).Count);
            Console.WriteLine("menu count " + totalData.MenuList.Find(item => item.Name == food.Name).Price);
        }

        public void setCategoryList(TotalData totalData, Food food)
        {
            if (totalData.CategoryList.Find(item => item.Category == food.Category) != null)
            {
                totalData.CategoryList.Find(item => item.Category == food.Category).Count += food.Count;
                totalData.CategoryList.Find(item => item.Category == food.Category).Price += food.Price;
            }
            else
            {
                totalData.CategoryList.Add(food);
            }
        }

        private void PaymentChange_Click(object sender, RoutedEventArgs e)
        {
            if (payment.IsChecked.Value)
                payment.Content = "카드";
            else
                payment.Content = "현금";
        }
    }
}
