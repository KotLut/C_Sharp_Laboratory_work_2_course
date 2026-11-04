using System;
using System.Text;
using System.Collections.Generic;

namespace LK_LABA3_CSHARP
{
    public class Matrix
    {
        private int[,] _array;

        public Matrix(int n, int m)
        {
            InputValidator validator = new InputValidator();

            n = CheckSize(n);
            m = CheckSize(m);

            _array = new int[n, m];

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"\tВведите элемент [{i + 1}, {j + 1}] >> ");

                    _array[i, j] = validator.GetInt();
                }
            }
        }

        public Matrix(int n, Random random)
        {
            n = CheckSize(n);

            _array = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    _array[i, j] = GetEvenNumber(random);
                }
            }
        }

        public Matrix(int n)
        {
            n = CheckSize(n);

            _array = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if ((j - i) % 2 == 0)
                    {
                        _array[i, j] = i + 1;
                    }
                    else
                    {
                        _array[i, j] = n - j;
                    }
                }
            }
        }

        private Matrix(int n, int m, bool empty)
        {
            _array = new int[n, m];
        }

        public int Rows
        {
            get
            {
                return _array.GetLength(0);
            }
        }

        public int Columns
        {
            get
            {
                return _array.GetLength(1);
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

        private int GetMaxLength()
        {
            int maxLength = 0;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    int length = _array[i, j].ToString().Length;

                    if (length > maxLength)
                    {
                        maxLength = length;
                    }
                }
            }

            return maxLength;
        }

        public string FindShortestPath()
        {
            int minRow = 0;
            int minCol = 0;
            int maxRow = 0;
            int maxCol = 0;
            int minVal = _array[0, 0];
            int maxVal = _array[0, 0];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (_array[i, j] < minVal)
                    {
                        minVal = _array[i, j];
                        minRow = i;
                        minCol = j;
                    }
                    if (_array[i, j] > maxVal)
                    {
                        maxVal = _array[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            int[] dRow = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dCol = { -1, 0, 1, -1, 1, -1, 0, 1 };

            bool[,] visited = new bool[Rows, Columns];
            int[,] prevIndex = new int[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    prevIndex[i, j] = -1;
                }
            }

            Queue<int> queue = new Queue<int>();
            int startIndex = minRow * Columns + minCol;
            int endIndex = maxRow * Columns + maxCol;

            queue.Enqueue(startIndex);
            visited[minRow, minCol] = true;

            bool found = false;

            while (queue.Count > 0)
            {
                int currentIndex = queue.Dequeue();
                int currentRow = currentIndex / Columns;
                int currentCol = currentIndex % Columns;

                if (currentIndex == endIndex)
                {
                    found = true;
                    break;
                }

                for (int i = 0; i < 8; i++)
                {
                    int newRow = currentRow + dRow[i];
                    int newCol = currentCol + dCol[i];

                    if (newRow >= 0 && newRow < Rows && newCol >= 0 && newCol < Columns && !visited[newRow, newCol])
                    {
                        visited[newRow, newCol] = true;
                        prevIndex[newRow, newCol] = currentIndex;
                        queue.Enqueue(newRow * Columns + newCol);
                    }
                }
            }

            if (!found)
            {
                return "Путь не найден";
            }

            List<int> path = new List<int>();
            int current = endIndex;
            while (current != -1)
            {
                path.Add(current);
                int row = current / Columns;
                int col = current % Columns;
                current = prevIndex[row, col];
            }

            path.Reverse();

            StringBuilder result = new StringBuilder();
            result.AppendLine($"\tМинимум: {minVal} [{minRow + 1}, {minCol + 1}]");
            result.AppendLine($"\tМаксимум: {maxVal} [{maxRow + 1}, {maxCol + 1}]");
            result.AppendLine($"\tДлина пути: {path.Count} клеток");
            result.AppendLine("\tПуть:");

            for (int i = 0; i < path.Count; i++)
            {
                int row = path[i] / Columns;
                int col = path[i] % Columns;
                result.Append($"\t\t[{row + 1}, {col + 1}] = {_array[row, col]}");
                if (i < path.Count - 1)
                {
                    result.Append(" ->");
                }
                result.AppendLine();
            }

            return result.ToString();
        }

        public Matrix Transpose()
        {
            Matrix result = new Matrix(Columns, Rows, true);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result._array[j, i] = _array[i, j];
                }
            }
            return result;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new InvalidOperationException("Матрицы должны быть одинакового размера");
            }
            Matrix result = new Matrix(a.Rows, a.Columns, true);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result._array[i, j] = a._array[i, j] + b._array[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new InvalidOperationException("Матрицы должны быть одинакового размера");
            }
            Matrix result = new Matrix(a.Rows, a.Columns, true);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result._array[i, j] = a._array[i, j] - b._array[i, j];
                }
            }
            return result;
        }

        public override string ToString()
        {
            int maxLength = GetMaxLength();
            string border = new string('─', Columns * (maxLength + 2));
            string result = $"\t┌{border}┐\n";

            for (int i = 0; i < Rows; i++)
            {
                result += "\t│ ";

                for (int j = 0; j < Columns; j++)
                {
                    if (j > 0)
                    {
                        result += "  ";
                    }

                    result += _array[i, j].ToString().PadLeft(maxLength);
                }

                result += " │\n";
            }

            result += $"\t└{border}┘";

            return result;
        }
    }
}