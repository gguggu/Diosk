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

            foreach(var pie in pies)
            {
                if (pie == MenuCountPie)
                    addMenuCountSlice(pie, labelPoint);
                else if (pie == MenuMoneyPie)
                    addMenuMoneySlice(pie, labelPoint);
                else if (pie == CategoryCountPie)
                    addCategoryCountSlice(pie, labelPoint);
                else if (pie == CategoryMoneyPie)
                    addCategoryMoneySlice(pie, labelPoint);
            }
        }

        public void addMenuMoneySlice(PieChart pie, Func<ChartPoint, string> labelPoint)
        {
            foreach(var data in totalData.DataList)
            {
                pie.Series.Add(new PieSeries
                {
                    Title = data.Name,
                    Values = new ChartValues<double> { data.Price },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }
        }

        public void addMenuCountSlice(PieChart pie, Func<ChartPoint, string> labelPoint)
        {
            foreach (var data in totalData.DataList)
            {
                pie.Series.Add(new PieSeries
                {
                    Title = data.Name,
                    Values = new ChartValues<double> { data.Count },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }
        }
        public void addCategoryMoneySlice(PieChart pie, Func<ChartPoint, string> labelPoint)
        {
            foreach (var data in totalData.CategoryList)
            {
                pie.Series.Add(new PieSeries
                {
                    Title = data.Category.ToString(),
                    Values = new ChartValues<double> { data.Price },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }
        }

        public void addCategoryCountSlice(PieChart pie, Func<ChartPoint, string> labelPoint)
        {
            foreach (var data in totalData.CategoryList)
            {
                pie.Series.Add(new PieSeries
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
            totalData.LoadMoney();

            money.Text = "Total: " + totalData.AllMoney.ToString() + "원";
        }
    }
}