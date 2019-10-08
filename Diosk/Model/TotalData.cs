using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diosk.Model
{
    public class TotalData
    {
        bool isLoaded = false;
        public int allMoney;

        public void LoadData()
        {
            if (isLoaded) return;
            allMoney = 890001;
            isLoaded = true;
        }
    }
}
