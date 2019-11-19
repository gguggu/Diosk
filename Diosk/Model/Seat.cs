using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diosk.Model
{
    public class Seat
    {
        public int id;
        public List<string> lstOrderTime = new List<string>();
        public List<Food> lstOrderFood = new List<Food>();
    }
}