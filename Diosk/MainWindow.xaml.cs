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

            this.Loaded += MainWindow_Loaded;
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
                navName = "메인";
                navBox.Text = navName;
            } else if(navi.Visibility == Visibility.Visible)
            {
                navi.Visibility = Visibility.Collapsed;
                navName = "통계";
                navBox.Text = navName;
            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            Window orderPage = new Order();
            orderPage.Show();
        }
    }
}
