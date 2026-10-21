using System;

namespace LK_LABA2_CSHARP
{
    public class Time
    {
        private int seconds;

        private const int SecondsInDay = 86400;
        private const int SecondsInHour = 3600;
        private const int SecondsInMinute = 60;

        public Time()
        {
            Seconds = 0;
        }

        public Time(int seconds)
        {
            Seconds = seconds;
        }

        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("\tВремя не может быть отрицательным :(");
                    seconds = 0;
                }
                else
                {
                    seconds = value % SecondsInDay;
                }
            }
        }

        public override string ToString()
        {
            int hours = seconds / SecondsInHour;
            int minutes = seconds % SecondsInHour / SecondsInMinute;
            int secs = seconds % SecondsInMinute;

            return $"{hours}:{minutes:D2}:{secs:D2}";
        }
    }
}
