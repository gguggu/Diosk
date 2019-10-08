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
using System.Windows.Threading;

namespace Diosk
{
    public class OrderEventArgs : EventArgs
    {
        public int id;
    }
    /// <summary>
    /// Interaction logic for TableControl.xaml
    /// </summary>
    public partial class TableControl : UserControl
    {
        public delegate void CompleteHandler(object sender, OrderEventArgs args);

        public event CompleteHandler OnComplete;

        public TableControl()
        {
            InitializeComponent();
            timeLoading();
        }
        private void timeLoading()
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Tick += new EventHandler(timer_Tick);
            t.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string currentTime = now.ToString("hh:mm:ss");
            timer.Text = "현재시간: " + currentTime;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            OrderEventArgs args = new OrderEventArgs();
            Button btn = sender as Button;
            args.id = int.Parse((string)btn.Content);

            if (OnComplete != null)
            {
                OnComplete(this, args);
            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            Window orderPage = new Order();
            orderPage.Show();
        }
    }
}
