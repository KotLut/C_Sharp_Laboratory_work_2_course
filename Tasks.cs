using System;

namespace LABA1_LK_CP
{
    public class Lab1
    {
        // Task 1.1-9
        public double fraction(double x)
        {
            return Math.Abs(x % 1);
        }

        public int charToNum(char x)
        {
            return x - 48;
        }

        public bool is2Digits(int x)
        {
            x = Math.Abs(x);

            return x >= 10 && x <= 99;
        }

        public bool isInRange(int a, int b, int num)
        {
            int min;
            int max;

            if (a > b)
            {
                max = a;
                min = b;
            }
            else
            {
                max = b;
                min = a;
            }

            return num >= min && num <= max;
        }
        
        public bool isEqual(int a, int b, int c)
        {
            return a == b && b == c;
        }

        // Task 2.1-9
        public int abs(int x)
        {
            if (x < 0)
            {
                x *= -1;
            }

            return x;
        }

        public bool is35(int x)
        {
            if ((x % 3 == 0) && (x % 5 == 0))
            {
                return false;
            }

            if ((x % 3 == 0) || (x % 5 == 0))
            {
                return true;
            }

            return false;
        }

        public int max3(int x, int y, int z)
        {
            if (z < x)
            {
                z = x;
            }

            if (z < y)
            {
                z = y;
            }

            return z;
        }

        public int sum2(int x, int y)
        {
            int sum = x + y;

            if (sum >= 10 && sum <= 19)
            {
                sum = 20;
            }

            return sum;
        }

        public string day(int x)
        {
            string result;

            switch (x)
            {
                case 1:
                    result = "понедельник";
                    break;

                case 2:
                    result = "вторник";
                    break;

                case 3:
                    result = "среда";
                    break;

                case 4:
                    result = "четверг";
                    break;

                case 5:
                    result = "пятница";
                    break;

                case 6:
                    result = "суббота";
                    break;

                case 7:
                    result = "воскресенье";
                    break;

                default:
                    result = "это не день недели";
                    break;
            }

            return result;
        }

        // Task 3.1-9
        public string listNums(int x)
        {
            string result = "";

            for (int i = 0; i <= x; i++)
            {
                result += i + " ";
            }

            return result.Trim();
        }

        public string chet(int x)
        {
            string result = "";

            for (int i = 0; i <= x; i += 2)
            {
                result += i + " ";
            }

            return result.Trim();
        }

        public int numLen(long x)
        {
            
            x = Math.Abs(x);
            int k = 0;

            if (x == 0)
            {
                return 1;
            }

            while (x > 0)
            {
                k += 1;
                x /= 10;
            }

            return k;
        }

        public void square(int x)
        {
            Console.Write("\t");
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write("*");
                }

                Console.Write("\n\t");
            }
        }

        public void rightTriangle(int x)
        {
            Console.Write("\t");
            for (int i = 1; i <= x; i++)
            {
                for (int j = 0; j < x - i; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }

                Console.Write("\n\t");
            }
        }

        // Task 4.1-9
        public int findFirst(int[] arr, int x)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                {
                    return i;
                }
            }

            return -1;
        }

        public int maxAbs(int[] arr)
        {
            int max = 0;
            int result = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) > max)
                {
                    max = Math.Abs(arr[i]);
                    result = arr[i];
                }
            }

            return result;
        }

        public int[] add(int[] arr, int[] ins, int pos)
        {
            int[] result = new int[arr.Length + ins.Length];

            for (int i = 0; i < pos; i++)
            {
                result[i] = arr[i];
            }

            for (int i = 0; i < ins.Length; i++)
            {
                result[pos + i] = ins[i];
            }

            for (int i = pos; i < arr.Length; i++)
            {
                result[ins.Length + i] = arr[i];
            }

            return result;
        }

        public int[] reverseBack(int[] arr)
        {
            int[] result = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = arr[arr.Length - 1 - i];
            }

            return result;
        }

        public int[] findAll(int[] arr, int x)
        {
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                {
                    count++;
                }
            }

            int[] result = new int[count];
            int index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                {
                    result[index] = i;
                    index++;
                }
            }

            return result;
        }

    }
}