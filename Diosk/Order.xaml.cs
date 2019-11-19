using Diosk.Common;
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
        Seat orderInfo = new Seat();

        DateTime dateTime;

        int resultPrice = 0;

        int price = 0;

        int seatIdx = 0;

        public Order(int id)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            seatIdSetting(id);
            setAlreayOrderList();
            this.Loaded += load_Menu;
            
        }

        private void setAlreayOrderList()
        {
            seatIdx = orderInfo.id - 1;

            if (App.seatDataSource.lstSeatData[seatIdx] != null)
            {
                foreach (string timer in App.seatDataSource.lstSeatData[seatIdx].lstOrderTime)
                {
                    time.Text = timer;
                }
                foreach (Food food in App.seatDataSource.lstSeatData[seatIdx].lstOrderFood)
                {
                    orderlist.Items.Add(new Food() { Name = food.Name, Count = food.Count, Price = food.Price });
                    resultPrice += food.Price;
                }
            }
        }

        private void seatIdSetting(int id)
        {
            orderInfo.id = id;
            seatNumber.Text = id.ToString() + "번 테이블";
        }

        private void load_Menu(object sender, RoutedEventArgs e)
        {
            lvFood.ItemsSource = App.menu.All;

            totalPrice.Text = "전체 금액 : " + resultPrice.ToString() + "원";
        }
        private void updateOrderList()
        {
            seatIdx = orderInfo.id - 1;

            App.seatDataSource.lstSeatData[seatIdx].lstOrderFood.Clear();
            App.seatDataSource.lstSeatData[seatIdx].lstOrderTime.Add(time.Text);

            foreach (Food food in orderlist.Items)
            {
                orderInfo.lstOrderFood.Add(food);
            }

            for (int i = 0; i < orderInfo.lstOrderFood.Count; i++)
            {
                App.seatDataSource.lstSeatData[seatIdx].lstOrderFood.Add(orderInfo.lstOrderFood[i]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            updateOrderList();

            if (orderInfo.lstOrderFood.Count() > 0)
            {
                Window payment = null;
                
                orderInfo.lstOrderFood.Clear();

                foreach (Food food in orderlist.Items)
                {
                    orderInfo.lstOrderFood.Add(food);
                }

                payment = new PaymentWindow(orderInfo);
                payment.Show();
                this.Close();
            }
            else
                MessageBox.Show("결제할 음료가 없습니다.","오류");
        }

        private void categoryClick(object sender, RoutedEventArgs e)
        {
            Button btnCategory = sender as Button;
            string category = btnCategory.Content.ToString().ToUpper();
            bool isAll = false;

            List<Food> lstAllFood = category.Equals("ALL") ? App.menu.All : null;
            List<Food> lstInsert = new List<Food>();

            if (!(lstAllFood == null))
                isAll = true;

            if (!isAll)
            {
                foreach (Enum item in Enum.GetValues(typeof(eCategory)))
                {
                    if (item.ToString().Equals(category))
                        lstAllFood = App.menu.All.FindAll(x => x.Category.Equals(item));
                }
            }

            foreach (Food item in lstAllFood)
                lstInsert.Add(item);

            lvFood.ItemsSource = lstInsert;
        }

        private void AllCancel_Click(object sender, RoutedEventArgs e)
        {
            if (orderlist.Items.IsEmpty)
            {
                MessageBox.Show("취소할 음료가 없습니다.", "오류");
            }
            else
            {
                orderlist.Items.Clear();

                resultPrice = 0;
                setResult(resultPrice);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Food order = (orderlist.SelectedItem as Food);

            if (orderlist.SelectedItem != null)
            {
                orderlist.Items.Remove(order);

                resultPrice -= order.Price;
                setResult(resultPrice);
            }
        }

        private void price_Check(Food order)
        {
            if (order.Price == 3000 * order.Count)
                price = 3000;

            else if (order.Price == 3500 * order.Count)
                price = 3500;

            else if (order.Price == 4000 * order.Count)
                price = 4000;

            else if (order.Price == 4500 * order.Count)
                price = 4500;
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            Food order = (orderlist.SelectedItem as Food);

            if (orderlist.SelectedItem != null)
            {
                price_Check(order);

                order.Count++;
                order.Price += price;

                orderlist.Items.Refresh();

                resultPrice += price;
                setResult(resultPrice);
            }
        }

        private void setResult(int resultPrice)
        {
            dateTime = DateTime.Now;
            totalPrice.Text = "전체 금액 : " + resultPrice.ToString() + "원";
            time.Text = dateTime.ToString("최근 주문 시간 : " + "HH시 mm분 ss초");
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            Food order = (orderlist.SelectedItem as Food);

            if (orderlist.SelectedItem != null)
            {
                price_Check(order);

                order.Count--;
                order.Price -= price;

                if (order.Count == 0)
                {
                    orderlist.Items.Remove(order);
                }
                else
                {
                    orderlist.Items.Refresh();
                }

                resultPrice -= price;
                setResult(resultPrice);
            }
        }

        private void Mainpage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow statis = new MainWindow();

            updateOrderList();
            statis.Refresh();

            this.Close();
            statis.Show();
        }
        
        private void LvFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvFood.SelectedIndex == -1)
            {
                return;
            }

            Food food = (lvFood.SelectedItem as Food);

            if (lvFood.SelectedItem != null)
            {
                foodImage.Source = new BitmapImage(new Uri(food.ImagePath, UriKind.RelativeOrAbsolute));

                bool isExistFood = false;

                foreach (Food item in orderlist.Items)
                {
                    if (item.Name == food.Name)
                    {
                        item.Count++;
                        item.Price += food.Price;
                        isExistFood = true;
                    }
                }

                if (isExistFood == false)
                {
                    Food orderitem = new Food() { Name = food.Name, Count = food.Count, Price = food.Price, Category = food.Category };
                    orderlist.Items.Add(orderitem);
                }

                orderlist.Items.Refresh();

                resultPrice += food.Price;
                setResult(resultPrice);

                lvFood.SelectedIndex = -1;
            }
        }
    }
}