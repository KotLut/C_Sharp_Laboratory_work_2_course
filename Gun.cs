using System;

namespace LK_LABA2_CSHARP
{
    public class Gun
    {
        private const int DefaultBullets = 5;

        private int bullets;

        public Gun()
        {
            Bullets = DefaultBullets;
        }

        public Gun(int bullets)
        {
            Bullets = bullets;
        }

        public int Bullets
        {
            get
            {
                return bullets;
            }
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine("\tКоличество патронов не может быть отрицательным :(");
                    bullets = 0;
                }
                else
                {
                    bullets = value;
                }
            }
        }

        public void Shoot()
        {
            if (bullets > 0)
            {
                Console.WriteLine("Бах!");
                bullets--;
            }
            else
            {
                Console.WriteLine("Клац!");
            }
        }

        public override string ToString()
        {
            return $"Пистолет, патронов: {bullets}";
        }
    }
}