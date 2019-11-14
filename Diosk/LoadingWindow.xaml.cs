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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Diosk
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public LoadingWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Loaded += LoadingWindow_Loaded;
        }
        private void LoadingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            App.menu.Load();
            loadingStart();
        }

        private void loadingStart()
        {
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if(App.menu.isLoaded)
            {
                timer.Stop();
                loadingClose();
            }
        }
        private void loadingClose()
        {
            Window main = new MainWindow();
            Window.GetWindow(this).Close();
            main.Show();
        }
    }
}
