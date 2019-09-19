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

namespace Diosk
{
    /// <summary>
    /// Statistic.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Statistic : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public SeriesCollection SeriesCollectionSec { get; set; }
        public string[] LabelsSec { get; set; }
        public Func<double, string> FormatterSec { get; set; }
        public Statistic()
        {
            InitializeComponent();
            setMenuChart();
            setCategoryChart();
        }

        public void setMenuChart()
        {
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "매출액",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "판매량",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            SeriesCollection[1].Values.Add(48d);

            Labels = new[] { "흑당 그린티 라떼", "흑당 밀크티", "흑당 카페라떼", "코코넛 카페라떼" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        public void setCategoryChart()
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
        }

        
    }
}
