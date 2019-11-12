using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diosk.Model
{
    public class Menu
    {
        public bool isLoaded = false;

        public List<Food> All = null;
        public List<Food> Coffee = null;
        public List<Food> Latte = null;
        public List<Food> Smoothie = null;
        public List<Food> Ade = null;

        public void Load()
        {
            if (isLoaded) return;

            All = new List<Food>()
            {
                new Food() {Name = "아메리카노", Price=3000, ImagePath="Assets/Coffee/menu01_img1.png", Count = 1},
                new Food() {Name = "카페라떼", Price=3000, ImagePath="Assets/Coffee/menu01_img2.png", Count = 1},
                new Food() {Name = "카푸치노", Price=4000, ImagePath="Assets/Coffee/menu01_img3.png", Count = 1},
                new Food() {Name = "카라멜마끼아또", Price=4000, ImagePath="Assets/Coffee/menu01_img4.png", Count = 1},
                new Food() {Name = "카페모카", Price=4500, ImagePath="Assets/Coffee/menu01_img6.png", Count = 1},

                new Food() {Name = "초코라떼", Price=3000, ImagePath="Assets/Latte/menu02_img1.png", Count = 1},
                new Food() {Name = "녹차라떼", Price=3000, ImagePath="Assets/Latte/menu02_img2.png", Count = 1},
                new Food() {Name = "오곡라떼", Price=3500, ImagePath="Assets/Latte/menu02_img3.png", Count = 1},
                new Food() {Name = "민트크림초코", Price=4000, ImagePath="Assets/Latte/menu02_img4.png", Count = 1},
                new Food() {Name = "고구마라떼", Price=3000, ImagePath="Assets/Latte/menu02_img5.png", Count = 1},
                new Food() {Name = "홍차라떼", Price=3000, ImagePath="Assets/Latte/menu02_img6.png", Count = 1},
                new Food() {Name = "폭탄초코", Price=3000, ImagePath="Assets/Latte/menu02_img7.png", Count = 1},
                new Food() {Name = "딸기라떼", Price=3000, ImagePath="Assets/Latte/menu08_img01.png", Count = 1},
                new Food() {Name = "토피넛라떼", Price=3000, ImagePath="Assets/Latte/menu08_img02.png", Count = 1},

                new Food() {Name = "플레인요거트", Price=3500, ImagePath="Assets/Smoothie/menu03_img1.png", Count = 1},
                new Food() {Name = "딸기요거트", Price=4000, ImagePath="Assets/Smoothie/menu03_img2.png", Count = 1},
                new Food() {Name = "녹차프라페", Price=4000, ImagePath="Assets/Smoothie/menu03_img3.png", Count = 1},
                new Food() {Name = "폭탄프라페", Price=4500, ImagePath="Assets/Smoothie/menu03_img4.png", Count = 1},
                new Food() {Name = "쿠키프라페", Price=4500, ImagePath="Assets/Smoothie/menu03_img5.png", Count = 1},
                new Food() {Name = "민트프라페", Price=3000, ImagePath="Assets/Smoothie/menu03_img6.png", Count = 1},
                new Food() {Name = "딸기스무디", Price=3500, ImagePath="Assets/Smoothie/menu08_img10.png", Count = 1},
                new Food() {Name = "망고스무디", Price=3500, ImagePath="Assets/Smoothie/menu03_img7.png", Count = 1},
                new Food() {Name = "망고요거트", Price=3500, ImagePath="Assets/Smoothie/menu03_img8.png", Count = 1},
                new Food() {Name = "모카프라페", Price=4000, ImagePath="Assets/Smoothie/menu08_img03.png", Count = 1},

                new Food() {Name = "레몬에이드", Price=3500, ImagePath="Assets/Ade/menu04_img1.png", Count = 1},
                new Food() {Name = "블루레몬에이드", Price=4500, ImagePath="Assets/Ade/menu04_img2.png", Count = 1},
                new Food() {Name = "자몽에이드", Price=3500, ImagePath="Assets/Ade/menu04_img3.png", Count = 1},
                new Food() {Name = "유자에이드", Price=3500, ImagePath="Assets/Ade/menu04_img4.png", Count = 1},
                new Food() {Name = "체리콕", Price=4500, ImagePath="Assets/Ade/menu04_img5.png", Count = 1},
                new Food() {Name = "라임에이드", Price=4500, ImagePath="Assets/Ade/menu04_img6.png", Count = 1},
                new Food() {Name = "폭탄에이드", Price=4000, ImagePath="Assets/Ade/menu04_img7.png", Count = 1},
                new Food() {Name = "청포도에이드", Price=3500, ImagePath="Assets/Ade/menu04_img10.png", Count = 1},
                new Food() {Name = "깔라만시에이드", Price=3500, ImagePath="Assets/Ade/menu08_img12.png", Count = 1},
            };

            Coffee = new List<Food>()
            {
                new Food() {Name = "아메리카노", Price=3000, ImagePath="Assets/Coffee/menu01_img1.png", Count = 1},
                new Food() {Name = "카페라떼", Price=3000, ImagePath="Assets/Coffee/menu01_img2.png", Count = 1},
                new Food() {Name = "카푸치노", Price=4000, ImagePath="Assets/Coffee/menu01_img2.png", Count = 1},
                new Food() {Name = "카라멜마끼아또", Price=4000, ImagePath="Assets/Coffee/menu01_img4.png", Count = 1},
                new Food() {Name = "카페모카", Price=4500, ImagePath="Assets/Coffee/menu01_img6.png", Count = 1},
            };

            Latte = new List<Food>()
            {
                new Food() {Name = "초코라떼", Price=3000, ImagePath="Assets/Latte/menu02_img1.png", Count = 1},
                new Food() {Name = "녹차라떼", Price=3000, ImagePath="Assets/Latte/menu02_img2.png", Count = 1},
                new Food() {Name = "오곡라떼", Price=3500, ImagePath="Assets/Latte/menu02_img3.png", Count = 1},
                new Food() {Name = "민트크림초코", Price=4000, ImagePath="Assets/Latte/menu02_img4.png", Count = 1},
                new Food() {Name = "고구마라떼", Price=3000, ImagePath="Assets/Latte/menu02_img5.png", Count = 1},
                new Food() {Name = "홍차라떼", Price=3000, ImagePath="Assets/Latte/menu02_img6.png", Count = 1},
                new Food() {Name = "폭탄초코", Price=3000, ImagePath="Assets/Latte/menu02_img7.png", Count = 1},
                new Food() {Name = "딸기라떼", Price=3000, ImagePath="Assets/Latte/menu08_img01.png", Count = 1},
                new Food() {Name = "토피넛라떼", Price=3000, ImagePath="Assets/Latte/menu08_img02.png", Count = 1}
            };

            Smoothie = new List<Food>()
            {
                new Food() {Name = "플레인요거트", Price=3500, ImagePath="Assets/Smoothie/menu03_img1.png", Count = 1},
                new Food() {Name = "딸기요거트", Price=4000, ImagePath="Assets/Smoothie/menu03_img2.png", Count = 1},
                new Food() {Name = "녹차프라페", Price=4000, ImagePath="Assets/Smoothie/menu03_img3.png", Count = 1},
                new Food() {Name = "폭탄프라페", Price=4500, ImagePath="Assets/Smoothie/menu03_img4.png", Count = 1},
                new Food() {Name = "쿠키프라페", Price=4500, ImagePath="Assets/Smoothie/menu03_img5.png", Count = 1},
                new Food() {Name = "민트프라페", Price=3000, ImagePath="Assets/Smoothie/menu03_img6.png", Count = 1},
                new Food() {Name = "딸기스무디", Price=3500, ImagePath="Assets/Smoothie/menu08_img10.png", Count = 1},
                new Food() {Name = "망고스무디", Price=3500, ImagePath="Assets/Smoothie/menu03_img7.png", Count = 1},
                new Food() {Name = "망고요거트", Price=3500, ImagePath="Assets/Smoothie/menu03_img8.png", Count = 1},
                new Food() {Name = "모카프라페", Price=4000, ImagePath="Assets/Smoothie/menu08_img03.png", Count = 1},
            };

            Ade = new List<Food>()
            {
                new Food() {Name = "레몬에이드", Price=3500, ImagePath="Assets/Ade/menu04_img1.png", Count = 1},
                new Food() {Name = "블루레몬에이드", Price=4500, ImagePath="Assets/Ade/menu04_img2.png", Count = 1},
                new Food() {Name = "자몽에이드", Price=3500, ImagePath="Assets/Ade/menu04_img3.png", Count = 1},
                new Food() {Name = "유자에이드", Price=3500, ImagePath="Assets/Ade/menu04_img4.png", Count = 1},
                new Food() {Name = "체리콕", Price=4500, ImagePath="Assets/Ade/menu04_img5.png", Count = 1},
                new Food() {Name = "라임에이드", Price=4500, ImagePath="Assets/Ade/menu04_img6.png", Count = 1},
                new Food() {Name = "폭탄에이드", Price=4000, ImagePath="Assets/Ade/menu04_img7.png", Count = 1},
                new Food() {Name = "청포도에이드", Price=3500, ImagePath="Assets/Ade/menu04_img10.png", Count = 1},
                new Food() {Name = "깔라만시에이드", Price=3500, ImagePath="Assets/Ade/menu08_img12.png", Count = 1},
            };
            isLoaded = true;
        }

        //public List<Food> MenuList 
    }
}
