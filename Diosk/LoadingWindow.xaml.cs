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
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : UserControl
    {
        DispatcherTimer timer = new DispatcherTimer();
        public LoadingWindow()
        {
            this.Loaded += LoadingWindow_Loaded;
        }
        private void LoadingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            loadingStart();
        }
        public void loadingStart()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 1); // TimeSpan(Hour, Minute, Second);
            timer.Tick += new EventHandler(timer_Tick);
            
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            fadeOutAnimation(loading);
            timer.Stop();
        }
        private void loadingClose()
        {
            Window.GetWindow(this).Close();
        }
        private void fadeOutAnimation(UIElement target)
        {
            DoubleAnimation anim = new DoubleAnimation();
            double animRunningTime = 1.5f;
            anim.From = 1.0;
            anim.To = 0.0;
            anim.Duration = new Duration(TimeSpan.FromSeconds(animRunningTime));

            target.BeginAnimation(OpacityProperty, anim);
        }
    }
}

