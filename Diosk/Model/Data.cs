using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diosk.Common;

namespace Diosk.Model
{
    public class Data
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Count { get; set; }
        public eCategory Category { get; set; }
    }
}
