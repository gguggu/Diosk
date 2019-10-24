﻿using Diosk.Model;
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

        int resultPrice = 0;

        int price = 0;

        Diosk.Model.Menu menu = new Diosk.Model.Menu();
        public Order(int id)
        {
            InitializeComponent();
            seatIdSetting(id);
            setAlreayOrderList();
            //MainWindow+= seatCtrl_OrderEvent;
            this.Loaded += load_Menu;
        }

        private void setAlreayOrderList()
        {
            int seatIdx = orderInfo.id - 1;

            if (App.seatDataSource.lstSeatData[seatIdx] != null)
            {
                foreach (Food food in App.seatDataSource.lstSeatData[seatIdx].lstOrderFood)
                {
                    orderlist.Items.Add(new Food() { Name = food.Name, Count = food.Count, Price = food.Price });
                    resultPrice += food.Count * food.Price;
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
            menu.Load();
            lvFood.ItemsSource = menu.All;

            totalPrice.Text = "전체 금액 : " + resultPrice.ToString() + "원";

            // 메인 테이블 표시
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Now;

            time.Text = dateTime.ToString("최근 주문 시간 : " + "h시 mm분 ss초");

            Window payment = new PaymentWindow();
            int seatIdx = orderInfo.id - 1;

            foreach (Food food in orderlist.Items)
            {
                orderInfo.lstOrderFood.Add(food);
            }

            App.seatDataSource.lstSeatData[seatIdx].lstOrderFood.Clear();

            payment.Show();
            this.Close();
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

        private void All_Click(object sender, RoutedEventArgs e)
        {
            lvFood.ItemsSource = menu.All;
        }

        private void AllCancel_Click(object sender, RoutedEventArgs e)
        {
            orderlist.Items.Clear();

            resultPrice = 0;
            totalPrice.Text = "전체 금액 : " + resultPrice.ToString() + "원";

            // 메인 테이블 표시
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Food order = (orderlist.SelectedItem as Food);

            if (orderlist.SelectedItem != null)
            {
                orderlist.Items.Remove(order);

                resultPrice -= order.Price;
                totalPrice.Text = "전체 금액 : " + resultPrice.ToString() + "원";

                // 메인 테이블 표시
            }
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            Food order = (orderlist.SelectedItem as Food);

            if (orderlist.SelectedItem != null)
            {
                if (order.Price == 3000 * order.Count)
                    price = 3000;

                else if (order.Price == 3500 * order.Count)
                    price = 3500;

                else if (order.Price == 4000 * order.Count)
                    price = 4000;

                else if (order.Price == 4500 * order.Count)
                    price = 4500;

                order.Count++;
                order.Price += price;

                orderlist.Items.Remove(order);
                orderlist.Items.Add(order);

                resultPrice += price;
                totalPrice.Text = "전체 금액 : " + resultPrice.ToString() + "원";

                // 메인 테이블 표시
            }
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            Food order = (orderlist.SelectedItem as Food);

            if (orderlist.SelectedItem != null)
            {
                if (order.Price == 3000 * order.Count)
                    price = 3000;

                else if (order.Price == 3500 * order.Count)
                    price = 3500;

                else if (order.Price == 4000 * order.Count)
                    price = 4000;

                else if (order.Price == 4500 * order.Count)
                    price = 4500;

                order.Count--;
                order.Price -= price;

                if (order.Count == 0)
                {
                    orderlist.Items.Remove(order);
                }
                else
                {
                    orderlist.Items.Remove(order);
                    orderlist.Items.Add(order);
                }

                resultPrice -= price;
                totalPrice.Text = "전체 금액 : " + resultPrice.ToString() + "원";

                // 메인 테이블 표시
            }
        }

        private void Mainpage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow statis = new MainWindow();

            int seatIdx = orderInfo.id - 1;

            App.seatDataSource.lstSeatData[seatIdx].lstOrderFood.Clear();

            foreach (Food food in orderlist.Items)
            {
                orderInfo.lstOrderFood.Add(food);
            }
            //MessageBox.Show(orderInfo.lstOrderFood.Count.ToString());

            for (int i = 0; i < orderInfo.lstOrderFood.Count; i++)
            {
                App.seatDataSource.lstSeatData[seatIdx].lstOrderFood.Add(orderInfo.lstOrderFood[i]);
            }

            statis.Refresh();

            this.Close();
            statis.Show();
        }

        private void LvFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Food food = (lvFood.SelectedItem as Food);

            if (lvFood.SelectedItem != null)
            {
                imagetest.Source = new BitmapImage(new Uri(food.ImagePath, UriKind.RelativeOrAbsolute));

                Food orderitem = new Food() { Name = food.Name, Count = food.Count, Price = food.Price };

                List<string> orderitemlist = new List<string>();

                orderlist.Items.Add(orderitem);

                orderitemlist.Add(orderitem.Name);

                /*
                for (int i = 0; i < orderitemlist.Count; i++)
                {
                    if(i >= 1)
                    {
                        if (!orderitemlist[i].Equals(orderitem.Name))
                        {
                            orderitem.Count += 1;

                        }
                        else if (orderitemlist[i].Equals(orderitem.Name))
                        {
                            //orderlist.Items.Remove(orderlist.Items[i]);
                            //orderlist.Items.Add(orderitem);
                        }
                    }
                }
                */

                resultPrice += food.Price;

                totalPrice.Text = "전체 금액 : " + resultPrice.ToString() + "원";

                // 메인 테이블 표시
            }

        }


    }

}