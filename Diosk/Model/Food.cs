using Diosk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diosk.Model
{
    public class Food
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public eCategory Category { get; set; }
        public int Count { get; set; }
        public string Payment { get; set; }
    }
}
