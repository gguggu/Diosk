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
using LiveCharts;
using LiveCharts.Wpf;
using Diosk.Model;

namespace Diosk
{
    /// <summary>
    /// Statistic.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Statistic : UserControl
    {
        public TotalData totalData = App.totalData;

        public Statistic()
        {
            InitializeComponent();
            setMoney();
            setChart();
        }

        public void setChart()
        {
            PieChart[] pies = new PieChart[] { MenuCountPie, MenuMoneyPie, CategoryCountPie, CategoryMoneyPie };

            Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            addMenuMoneySlice(labelPoint);
            addMenuCountSlice(labelPoint);
            addCategoryMoneySlice(labelPoint);
            addCategoryCountSlice(labelPoint);
        }

        public void addMenuMoneySlice(Func<ChartPoint, string> labelPoint)
        {
            foreach (var data in totalData.MenuList)
            {
                MenuMoneyPie.Series.Add(new PieSeries
                {
                    Title = data.Name,
                    Values = new ChartValues<double> { data.Price },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }
        }

        public void addMenuCountSlice(Func<ChartPoint, string> labelPoint)
        {
            foreach (var data in totalData.MenuList)
            {
                MenuCountPie.Series.Add(new PieSeries
                {
                    Title = data.Name,
                    Values = new ChartValues<double> { data.Count },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
                Console.WriteLine("menu count: " + data.Name + data.Count);
                Console.WriteLine("menu price: " + data.Name + data.Price);
            }
        }
        public void addCategoryMoneySlice(Func<ChartPoint, string> labelPoint)
        {
            foreach (var data in totalData.CategoryList)
            {
                CategoryMoneyPie.Series.Add(new PieSeries
                {
                    Title = data.Category.ToString(),
                    Values = new ChartValues<double> { data.Price },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }
        }

        public void addCategoryCountSlice(Func<ChartPoint, string> labelPoint)
        {
            foreach (var data in totalData.CategoryList)
            {
                CategoryCountPie.Series.Add(new PieSeries
                {
                    Title = data.Category.ToString(),
                    Values = new ChartValues<double> { data.Count },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }
        }

        public void setMoney()
        {
            money.Text = "Total: " + totalData.AllMoney.ToString() + "원";
        }

        private void SendTotalMoney(object sender, RoutedEventArgs e)
        {
            Chatting chatting = App.chatting;

            if (chatting.isLogin)
            {
                string message = "@2104#하루총액 " + totalData.AllMoney.ToString() + "원";
                chatting.Send(message);
            } else
            {
                MessageBox.Show("로그인부터 하세용");
            }
           
        }
    }
}