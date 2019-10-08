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
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public SeriesCollection SeriesCollectionSec { get; set; }
        public string[] LabelsSec { get; set; }
        public Func<double, string> FormatterSec { get; set; }

        public Func<ChartPoint, string> PointLabel { get; set; }



        public Statistic()
        {
            InitializeComponent();
            setMenuChart();
            //setCategoryChart();
            gettingPractice();
        }

        public void gettingPractice()
        {
            App.totalData.LoadData();
            moneyBox.Text = "총 매출액: " + App.totalData.allMoney.ToString() + "원";
        }

        public void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

        public void setMenuChart()
        {
            PointLabel = chartPoint =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = this;
        }

        /*public void setCategoryChart()
        {
            SeriesCollectionSec = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "매출액",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            SeriesCollectionSec.Add(new ColumnSeries
            {
                Title = "판매량",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            SeriesCollectionSec[1].Values.Add(48d);

            LabelsSec = new[] { "COFFEE", "LATTE", "SMOOTHIE", "ADE" };
            FormatterSec = value => value.ToString("N");

            DataContext = this;
        }*/

        
    }
}
