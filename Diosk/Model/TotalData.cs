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

        private Dictionary<string, double> menuCountSlice = new Dictionary<string, double>();

        public Dictionary<string, double> MenuCountSlice {
            get { return menuCountSlice; }
            set { menuCountSlice = value; }
        }

        private Dictionary<string, double> menuMoneySlice = new Dictionary<string, double>();
        public Dictionary<string, double> MenuMoneySlice
        {
            get { return menuMoneySlice; }
            set { menuMoneySlice = value; }
        }

        private Dictionary<string, double> categoryCountSlice = new Dictionary<string, double>();
        public Dictionary<string, double> CategoryCountSlice
        {
            get { return categoryCountSlice; }
            set { categoryCountSlice = value; }
        }

        private Dictionary<string, double> categoryMoneySlice = new Dictionary<string, double>();
        public Dictionary<string, double> CategoryMoneySlice
        {
            get { return categoryMoneySlice; }
            set { categoryMoneySlice = value; }
        }

        public void AddSlice()
        {
            try {
                addMenuCount();
                addMenuMoney();
                addCategoryCount();
                addCategoryMoney();
            } catch(NullReferenceException e) {
                System.Console.WriteLine(e.ToString());
            }
        }

        public void addMenuCount()
        {
            MenuCountSlice.Add("바나나우유", 32d);
            MenuCountSlice.Add("딸기우유", 15d);
            MenuCountSlice.Add("오렌지 스무디", 18d);
            MenuCountSlice.Add("파워에이드", 25d);
        }

        public void addMenuMoney()
        {
            MenuMoneySlice.Add("바나나맛 수박 아이스크림", 10000d);
            MenuMoneySlice.Add("수박맛 딸기 아이스크림", 24000d);
        }

        public void addCategoryCount()
        {
            CategoryCountSlice.Add("라떼", 10d);
            CategoryCountSlice.Add("커피", 22d);
        }

        public void addCategoryMoney()
        {
            CategoryMoneySlice.Add("라떼", 520000);
            CategoryMoneySlice.Add("커피", 650000);
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
