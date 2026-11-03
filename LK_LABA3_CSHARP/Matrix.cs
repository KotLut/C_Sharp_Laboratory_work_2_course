using System;

namespace LK_LABA3_CSHARP
{
    public class Matrix
    {
        private int[,] array;

        public Matrix(int n, int m)
        {
            InputValidator validator = new InputValidator();

            n = CheckSize(n);
            m = CheckSize(m);

            array = new int[n, m];

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"\tВведите элемент [{i + 1}, {j + 1}] >> ");

                    array[i, j] = validator.GetInt();
                }
            }
        }

        public Matrix(int n, Random random)
        {
            n = CheckSize(n);

            array = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = GetEvenNumber(random);
                }
            }
        }

        public Matrix(int n)
        {
            n = CheckSize(n);

            array = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if ((j - i) % 2 == 0)
                    {
                        array[i, j] = i + 1;
                    }
                    else
                    {
                        array[i, j] = n - j;
                    }
                }
            }
        }

        public int Rows
        {
            get
            {
                return array.GetLength(0);
            }
        }

        public int Columns
        {
            get
            {
                return array.GetLength(1);
            }
        }

        private static int CheckSize(int size)
        {
            if (size < 1)
            {
                ScreenUtils.PrintError("\tРазмер матрицы должен быть минимум 1 :(");
                return 1;
            }

            return size;
        }

        private static int GetEvenNumber(Random random)
        {
            int thousands = random.Next(1, 5) * 2;
            int hundreds = random.Next(0, 5) * 2;
            int tens = random.Next(0, 5) * 2;
            int units = random.Next(0, 5) * 2;

            return thousands * 1000 + hundreds * 100 + tens * 10 + units;
        }

        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < Rows; i++)
            {
                result += "\t";

                for (int j = 0; j < Columns; j++)
                {
                    result += $"{array[i, j],7}";
                }

                if (i < Rows - 1)
                {
                    result += "\n";
                }
            }

            return result;
        }
    }
}