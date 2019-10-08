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

        public List<Food> Coffee = null;
        public List<Food> Latte = null;

        public void Load()
        {
            if (isLoaded) return;

            Coffee = new List<Food>()
            {
                new Food() {Name = "아메리카노", Price=3000, ImagePath="Assets/Coffee/menu01_img1.png", Count = 0},
                new Food() {Name = "카페라떼", Price=3000, ImagePath="Assets/Coffee/menu01_img2.png", Count = 0},
                new Food() {Name = "카푸치노", Price=4000, ImagePath="Assets/Coffee/menu01_img2.png", Count = 0},
                new Food() {Name = "카라멜마끼아또", Price=4000, ImagePath="Assets/Coffee/menu01_img4.png", Count = 0},
                new Food() {Name = "카페모카", Price=4500, ImagePath="Assets/Coffee/menu01_img6.png", Count = 0},
            };

            Latte = new List<Food>()
            {
                new Food() {Name = "초코라떼", Price=3000, ImagePath="Assets/Latte/menu02_img1.png", Count = 0},
                new Food() {Name = "녹차라떼", Price=3000, ImagePath="Assets/Latte/menu02_img2.png", Count = 0},
                new Food() {Name = "오곡라떼", Price=3500, ImagePath="Assets/Latte/menu02_img3.png", Count = 0},
                new Food() {Name = "민트크림초코", Price=4000, ImagePath="Assets/Latte/menu02_img4.png", Count = 0},
                new Food() {Name = "고구마라떼", Price=3000, ImagePath="Assets/Latte/menu02_img5.png", Count = 0},
                new Food() {Name = "홍차라떼", Price=3000, ImagePath="Assets/Latte/menu02_img6.png", Count = 0},
                new Food() {Name = "폭탄초코", Price=3000, ImagePath="Assets/Latte/menu02_img7.png", Count = 0},
                new Food() {Name = "딸기라떼", Price=3000, ImagePath="Assets/Latte/menu08_img01.png", Count = 0},
                new Food() {Name = "토피넛라떼", Price=3000, ImagePath="Assets/Latte/menu08_img02.png", Count = 0}
            };

            isLoaded = true;
        }

        //public List<Food> MenuList 
    }
}
