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
        public double paymentMoney { get; set; }
        public List<Food> MenuList = new List<Food>();
        public List<Food> CategoryList = new List<Food>();
    }
}
