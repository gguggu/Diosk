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
        public int AllMoney { get; set; }
        public string AllMoneyString { get; set; }

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
            CategoryCountSlice.Add("LATTE", 10d);
            CategoryCountSlice.Add("COFFEE", 22d);
            CategoryCountSlice.Add("SMOOTHIE", 30d);
            CategoryCountSlice.Add("ADE", 80d);
        }

        public void addCategoryMoney()
        {
            CategoryMoneySlice.Add("LATTE", 520000d);
            CategoryMoneySlice.Add("COFFEE", 650000d);
            CategoryMoneySlice.Add("SMOOTHIE", 990000d);
            CategoryMoneySlice.Add("ADE", 15030000d);
        }

        public void LoadMoney()
        {
            if (isLoaded) return;

            AllMoney = 890001;
            AllMoneyString = "Total: " + AllMoney.ToString() + "원";

            isLoaded = true;
        }
    }
}
