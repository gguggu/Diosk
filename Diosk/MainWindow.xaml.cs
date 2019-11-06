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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Diosk
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        Diosk.Model.Menu menu = new Diosk.Model.Menu();
        public string navName = "통계";
        public MainWindow()
        {
            InitializeComponent();
            setSeat();
            timeLoading();

            this.Loaded += MainWindow_Loaded;
        }

        public void Refresh()
        {
            setSeat();
            lstOrder.Items.Refresh();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            menu.Load();
        }

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
           
            if(navi.Visibility == Visibility.Collapsed)
            {
                navi.Visibility = Visibility.Visible;
                MainGrid.Visibility = Visibility.Collapsed;
                navName = "메인";
                navBox.Text = navName;
            } else if(navi.Visibility == Visibility.Visible)
            {
                navi.Visibility = Visibility.Collapsed;
                MainGrid.Visibility = Visibility.Visible;
                navName = "통계";
                navBox.Text = navName;
            }
        }

        private Seat seat = new Seat();

        private void setSeat()
        {
            lstOrder.Items.Clear();
            foreach (Seat items in App.seatDataSource.lstSeatData)
            {
                SeatControl seatCtrl = new SeatControl();

                seatCtrl.id.Text = (items.id + 1).ToString();

                if (items.lstOrderFood != null)
                {
                    foreach (Food foodList in items.lstOrderFood)
                    {
                        seatCtrl.foodOrderList.Text += foodList.Name + " X " + foodList.Count.ToString() + "\n";
                    }
                    lstOrder.Items.Add(seatCtrl);
                }
            }
        }

        private void timeLoading()
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Tick += timer_Tick;
            t.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string currentTime = now.ToString("yyyy년 MM월 dd일 HH:mm:ss");

            timer.Text = "현재시간: " + currentTime;
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            Window orderPage = null;

            var seatControl = (sender as ListViewItem).Content as SeatControl;
            int id = int.Parse(seatControl.id.Text);

            orderPage = new Order(id);

            Window.GetWindow(this).Close();
            orderPage.Show();
        }
    }
}