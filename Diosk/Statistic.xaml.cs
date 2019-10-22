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
        public Statistic()
        {
            InitializeComponent();
            totalData.LoadMoney();
            totalData.AddSlice();
            this.DataContext = totalData;
            setChart();
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
                    AddSeries(pie, labelPoint, totalData.MenuCountSlice);
                } else if(pie == MenuMoneyPie)
                {
                    AddSeries(pie, labelPoint, totalData.MenuMoneySlice);
                } else if(pie == CategoryCountPie)
                {
                    AddSeries(pie, labelPoint, totalData.CategoryCountSlice);
                } else if(pie == CategoryMoneyPie)
                {
                    AddSeries(pie, labelPoint, totalData.CategoryMoneySlice);
                }
            }
        }

        public void AddSeries(PieChart pie, Func<ChartPoint, string> labelPoint, Dictionary<string, double> pieDictionary)
        {
            foreach (var slice in pieDictionary)
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
