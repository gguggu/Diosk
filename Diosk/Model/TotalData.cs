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
        bool isLoaded = false;
        public int allMoney;

        private Dictionary<string, double> slice = new Dictionary<string, double>();
        public Dictionary<string, double> Slice
        {
            get { return slice; }
            set { slice = value; }
        }

        public void AddSlice()
        {
            try {
                Slice.Add("바나나우유", 32d);
                Slice.Add("딸기우유", 15d);
                Slice.Add("오렌지 스무디", 18d);
                Slice.Add("파워에이드", 25d);
            } catch(NullReferenceException e) {
                System.Console.WriteLine(e.ToString());
            }
        }

        public void LoadMoney()
        {
            if (isLoaded) return;

            allMoney = 890001;
            isLoaded = true;
            //return allMoney;
        }
    }
}
