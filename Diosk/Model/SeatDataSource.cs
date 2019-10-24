using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diosk.Model
{
    public class SeatDataSource
    {
        public List<Seat> lstSeatData = null;

        private const int TABLE_MAX_COUNT = 6;

        public void dataLoad()
        {
            if (lstSeatData == null)
            {
                lstSeatData = new List<Seat>();
            }
            for (int i = 0; i < TABLE_MAX_COUNT; i++)
            {
                Seat seat = new Seat();
                seat.id = i;
                lstSeatData.Add(seat);
            }
        }
    }
}