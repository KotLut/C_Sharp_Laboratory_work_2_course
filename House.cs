using System;

namespace LK_LABA2_CSHARP
{
    public class House
    {
        private int floors;

        //public House()
        //{
        //    Floors = 1;
        //}

        public House(int floors)
        {
            if (floors < 1)
            {
                Console.WriteLine("\tЭтажей должно быть минимум 1 :(");
                this.floors = 1;
            }
            else
            {
                this.floors = floors;
            }
        }

        public int Floors
        {
            get
            {
                return floors;
            }
            //set
            //{
            //    if (value < 1)
            //    {
            //        Console.WriteLine("\tЭтажей должно быть минимум 1 :(");
            //        floors = 1;
            //    }
            //    else
            //    {
            //        floors = value;
            //    }
            //}
            set
            {
                throw new InvalidOperationException("Количество этажей нельзя изменить после создания");
            }
        }

        public override string ToString()
        {
            string ending;

            if (floors % 10 == 1 && floors % 100 != 11)
            {
                ending = "этажом";
            }
            else
            {
                ending = "этажами";
            }

            return $"дом с {floors} {ending}";
        }
    }
}