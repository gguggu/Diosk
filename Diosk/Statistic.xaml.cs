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
        public TotalData totalData = new TotalData();
        public string PointName { get; set; }

        public Statistic()
        {
            InitializeComponent();
            totalData.AddSlice();
            setChart();
            gettingPractice();
        }

        public void gettingPractice()
        {
            totalData.LoadMoney();
            moneyBox.Text = "Total: " + totalData.allMoney.ToString() + "원";
        }

        public void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (PieChart)chartpoint.ChartView;

            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }


        public void setChart()
        {
            PieChart[] pies = new PieChart[] { MenuCountPie, MenuMoneyPie, CategoryCountPie, CategoryMoneyPie };

            Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            foreach(var pie in pies)
            {
                if(pie == MenuCountPie)
                {
                    addMenuCountSeries(pie, labelPoint);
                } else if(pie == MenuMoneyPie)
                {
                    addMenuMoneySeries(pie, labelPoint);
                } else if(pie == CategoryCountPie)
                {
                    addCategoryCountSeries(pie, labelPoint);
                } else if(pie == CategoryMoneyPie)
                {
                    addCategoryMoneySeries(pie, labelPoint);
                }
            }
        }

        public void addMenuCountSeries(PieChart pie, Func<ChartPoint, string> labelPoint)
        {
            foreach (var slice in totalData.MenuCountSlice)
            {
                pie.Series.Add(new PieSeries
                {
                    Title = slice.Key,
                    Values = new ChartValues<double> { slice.Value },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }
        }

        public void addMenuMoneySeries(PieChart pie, Func<ChartPoint, string> labelPoint)
        {
            foreach (var slice in totalData.MenuMoneySlice)
            {
                pie.Series.Add(new PieSeries
                {
                    Title = slice.Key,
                    Values = new ChartValues<double> { slice.Value },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }
        }

        public void addCategoryCountSeries(PieChart pie, Func<ChartPoint, string> labelPoint)
        {
            foreach (var slice in totalData.CategoryCountSlice)
            {
                pie.Series.Add(new PieSeries
                {
                    Title = slice.Key,
                    Values = new ChartValues<double> { slice.Value },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }
        }

        public void addCategoryMoneySeries(PieChart pie, Func<ChartPoint, string> labelPoint)
        {
            foreach (var slice in totalData.CategoryMoneySlice)
            {
                pie.Series.Add(new PieSeries
                {
                    Title = slice.Key,
                    Values = new ChartValues<double> { slice.Value },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }
        }
    }
}
