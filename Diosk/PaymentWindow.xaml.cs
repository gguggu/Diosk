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

                foreach (Food food in payingSeat.lstOrderFood)
                {
                    Data data = setData(food);

                    setDataList(totalData, data);
                    setCategoryList(totalData, data);
                }
                MainWindow main = new MainWindow();
                App.seatDataSource.lstSeatData[payingSeat.id - 1].lstOrderFood.Clear();
                App.seatDataSource.lstSeatData[payingSeat.id - 1].lstOrderTime.Clear();
                main.Refresh();

                this.Close();
                main.Show();
            }
        }

        public Data setData(Food food)
        {
            Data data = new Data();

            data.Name = food.Name;
            data.Price = food.Price;
            data.Count = food.Count;
            data.Category = food.Category;

            return data;
        }

        public void setDataList(TotalData totalData, Data data)
        {
            if (totalData.DataList.Find(x => x.Name == data.Name) != null)
            {
                totalData.DataList.Find(x => x.Name == data.Name).Count += data.Count;
                totalData.DataList.Find(x => x.Name == data.Name).Price += data.Price;
            }
            else
            {
                totalData.DataList.Add(data);
            }
        }

        public void setCategoryList(TotalData totalData, Data data)
        {
            if (totalData.CategoryList.Find(x => x.Category == data.Category) != null)
            {
                totalData.CategoryList.Find(x => x.Category == data.Category).Count += data.Count;
                totalData.CategoryList.Find(x => x.Category == data.Category).Price += data.Price;
            }
            else
            {
                totalData.CategoryList.Add(data);
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
