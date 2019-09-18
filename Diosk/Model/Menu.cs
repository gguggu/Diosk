using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diosk.Model
{
    public class Menu
    {
        private bool isLoaded = false;

        public List<Food> menuList = null;

        public void Load()
        {
            if (isLoaded) return;

            menuList = new List<Food>
            {
                new Food{ Name="아이스아메리카노", Price=1000, Count=1, Payment="card" },
                new Food{ Name="초코우유", Price=5000, Count=1, Payment="money" }
            };

            isLoaded = true;
        }

        //public List<Food> MenuList 
    }
}
