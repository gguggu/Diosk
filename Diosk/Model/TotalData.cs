using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;

namespace Diosk.Model
{
    public class TotalData
    {
        public double AllMoney { get; set; }
        public string AllMoneyString { get; set; }
        public List<Data> DataList = new List<Data>();
        public List<Data> CategoryList = new List<Data>();

        public void LoadMoney()
        {
            foreach(Data data in DataList)
            {
                AllMoney += data.Price;
            }
        }
    }
}
