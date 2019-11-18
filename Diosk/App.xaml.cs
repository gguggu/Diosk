using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Diosk.Model;

namespace Diosk
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static SeatDataSource seatDataSource = new SeatDataSource();

        public static Diosk.Model.Menu menu = new Diosk.Model.Menu();

        public static TotalData totalData = new TotalData();

        public App()
        {
            App.seatDataSource.dataLoad();
        }
    }
}
