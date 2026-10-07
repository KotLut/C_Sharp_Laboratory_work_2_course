using System;

namespace LABA1_LK_CP
{
    public class Utils
    {
        public void WaitForContinue()
        {
            Console.Write("\n\tВведите что-нибудь для продолжения >> ");
            Console.ReadLine();
        }

        public int[] GenerateArray(int length)
        {
            int[] array = new int[length];

            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 11);
            }

            return array;
        }

        public void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);

                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
        }
    }

public class InputValidator
    {
        public int GetInt()
        {
            while (true)
            {
                string input = Console.ReadLine();

                try
                {
                    return Convert.ToInt32(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\tНекорректный ввод :(");
                    Console.Write("\tПовторите ввод >> ");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\tСлишком большое число :(");
                    Console.Write("\tПовторите ввод >> ");
                }
            }
        }

        public long GetLong()
        {
            while (true)
            {
                string input = Console.ReadLine();

                try
                {
                    return Convert.ToInt64(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\tНекорректный ввод :(");
                    Console.Write("\tПовторите ввод >> ");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\tСлишком большое число :(");
                    Console.Write("\tПовторите ввод >> ");
                }
            }
        }

        public float GetFloat()
        {
            while (true)
            {
                string input = Console.ReadLine();
                input = input.Replace('.', ',');

                try
                {
                    return Convert.ToSingle(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\tНекорректный ввод :(");
                    Console.Write("\tПовторите ввод >> ");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\tСлишком большое число :(");
                    Console.Write("\tПовторите ввод >> ");
                }
            }
        }

        public double GetDouble()
        {
            while (true)
            {
                string input = Console.ReadLine();
                input = input.Replace('.', ',');

                try
                {
                    return Convert.ToDouble(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\tНекорректный ввод :(");
                    Console.Write("\tПовторите ввод >> ");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\tСлишком большое число :(");
                    Console.Write("\tПовторите ввод >> ");
                }
            }
        }
        public char GetChar()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.Length == 1)
                {
                    return Convert.ToChar(input);
                }

                Console.WriteLine("\tНужно ввести один символ :(");
                Console.Write("\tПовторите ввод >> ");
            }
        }
    }
}