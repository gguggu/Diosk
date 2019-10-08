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
        //public Func<ChartPoint, string> PointLabel { get; set; }
        public string PointName { get; set; }

        public Statistic()
        {
            InitializeComponent();
            totalData.AddSlice();
            setMenuChart();
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

        public void setMenuChart()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            MenuPie.Series = new SeriesCollection();
            foreach (var se in totalData.Slice)
            {
                MenuPie.Series.Add(new PieSeries
                {
                    Title = se.Key,
                    Values = new ChartValues<double> { se.Value },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }
        }
    }
}
