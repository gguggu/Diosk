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
                    total += items.Price * items.Count;
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
                MainWindow main = new MainWindow();

                /*
                 * 통계쪽으로 결제된 음식 정보 보내는 구간 ( 추후에 작성할 예정.. )
                 */

                App.seatDataSource.lstSeatData[payingSeat.id - 1].lstOrderFood.Clear();
                main.Refresh();

                this.Close();
                main.Show();
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
