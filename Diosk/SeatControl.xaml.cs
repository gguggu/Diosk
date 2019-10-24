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
using Diosk.Model;

namespace Diosk
{
    /// <summary>
    /// Interaction logic for SeatControl.xaml
    /// </summary>
    public partial class SeatControl : UserControl
    {
        public SeatControl()
        {
            InitializeComponent();
        }

        //private void Order_Click(object sender, RoutedEventArgs e)
        //{
        //    Seat seat = new Seat();
        //    SeatControl seatCtrl = sender as SeatControl;
        //    Window orderPage = new Order();

        //    seat.id = seatCtrl.id.Text;

        //    if (OrderEvent != null)
        //    {
        //        OrderEvent(this, seat);
        //    }

        //    orderPage.Show();
        //}
    }
}