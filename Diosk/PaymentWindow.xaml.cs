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
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        public PaymentWindow()
        {
            InitializeComponent();
        }
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
    }
}
