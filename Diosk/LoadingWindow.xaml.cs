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

        Diosk.Model.Menu menu = new Diosk.Model.Menu();

        public LoadingWindow()
        {
            InitializeComponent();
            this.Loaded += LoadingWindow_Loaded;
        }
        private void LoadingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            alignCenter();
            menu.Load();
            loadingStart();
        }
        private void alignCenter()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;

            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
        private void loadingStart()
        {
            //timer.Interval = new TimeSpan(0, 0, 3); // TimeSpan(Hour, Minute, Second);
            timer.Tick += new EventHandler(timer_Tick);

            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            //fadeOutAnimation(loading);
            //fadeOutAnimation(Window.GetWindow(this));
            if(menu.isLoaded)
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
        /*private void fadeOutAnimation(Window target)
        {
                DoubleAnimation anim = new DoubleAnimation();
                double animRunningTime = 1.5f;
                anim.From = 1.0;
                anim.To = 0.0;
                anim.Duration = new Duration(TimeSpan.FromSeconds(animRunningTime));

                target.BeginAnimation(OpacityProperty, anim);
        }*/
    }
}
