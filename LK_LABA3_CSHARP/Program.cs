using System;

namespace LK_LABA3_CSHARP
{
    internal class Program
    {
        static void Main()
        {
            ScreenUtils.Initialize();
            InputValidator validator = new InputValidator();
            Utils utils = new Utils();
            Random random = new Random();

            bool isRun = true;
            do
            {
                Console.Clear();
                ScreenUtils.DrawPicture("laba");
                ScreenUtils.PaintHeader("\n\tЛАБОРАТОРНАЯ РАБОТА 3");
                Console.WriteLine("\tВыберите задачу:");
                Console.WriteLine("\t1) Задание 1 - Заполнение двумерных массивов");
                Console.WriteLine("\t2) Задание 2 - Кратчайший путь в матрице");
                Console.WriteLine("\t3) Задание 3 - Матричные выражения");
                Console.WriteLine("\t4) Задание 4 - Бинарные файлы (кратные k)");
                Console.WriteLine("\t5) Задание 5 - Бинарные файлы и структуры (игрушки)");
                Console.WriteLine("\t6) Задание 6 - Текстовые файлы (сумма по индексу)");
                Console.WriteLine("\t7) Задание 7 - Текстовые файлы (произведение кратных k)");
                Console.WriteLine("\t8) Задание 8 - Текстовые файлы (фильтрация строк)");
                Console.WriteLine("\t0) Выход из программы");
                ScreenUtils.Paint("\tВыберите действие >> ", Color.Cyan);

                int choice = validator.GetInt();

                switch (choice)
                {
                    case 1:
                        bool isTask1Run = true;
                        do
                        {
                            Console.Clear();
                            ScreenUtils.PaintHeader("\n\tЗадание 1 - Заполнение двумерных массивов");
                            Console.WriteLine("\t1) Массив n x m, ввод с клавиатуры по столбцам");
                            Console.WriteLine("\t2) Массив n x n, случайные четырёхзначные числа из чётных цифр");
                            Console.WriteLine("\t3) Массив n x n по образцу");
                            Console.WriteLine("\t0) Назад");
                            ScreenUtils.Paint("\tВыберите подзадачу >> ", Color.Yellow);

                            int fillChoice = validator.GetInt();

                            switch (fillChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t1.1 Массив n x m с клавиатуры");
                                    Console.Write("\tВведите количество строк n (1-10) >> ");

                                    int rowsCount = validator.GetInt(1, 10);

                                    Console.Write("\tВведите количество столбцов m (1-10) >> ");

                                    int columnsCount = validator.GetInt(1, 10);

                                    Console.WriteLine("\n\tЭлементы вводятся по столбцам, сверху вниз:");

                                    Matrix keyboardMatrix = new Matrix(rowsCount, columnsCount);

                                    Console.WriteLine($"\n{keyboardMatrix}");
                                    utils.WaitForContinue();
                                    break;

                                case 2:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t1.2 Случайный массив n x n");
                                    Console.Write("\tВведите размер n (1-10) >> ");

                                    int randomSize = validator.GetInt(1, 10);

                                    Matrix randomMatrix = new Matrix(randomSize, random);

                                    Console.WriteLine($"\n{randomMatrix}");
                                    utils.WaitForContinue();
                                    break;

                                case 3:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t1.3 Массив n x n по образцу");
                                    Console.Write("\tВведите размер n (1-10) >> ");

                                    int patternSize = validator.GetInt(1, 10);

                                    Matrix patternMatrix = new Matrix(patternSize);

                                    Console.WriteLine($"\n{patternMatrix}");
                                    utils.WaitForContinue();
                                    break;

                                case 0:
                                    isTask1Run = false;
                                    break;

                                default:
                                    ScreenUtils.PrintError("\tНекорректный выбор!");
                                    utils.WaitForContinue();
                                    break;
                            }
                        } while (isTask1Run);

                        break;

                    case 2:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\t\tЗадание 2: Кратчайший путь между мин и макс");
                        Console.Write("\tВведите размер n (1-10) >> ");

                        int pathSize = validator.GetInt(1, 10);

                        Matrix pathMatrix = new Matrix(pathSize, random);

                        Console.WriteLine($"\n{pathMatrix}");

                        Console.WriteLine(pathMatrix.FindShortestPath());

                        utils.WaitForContinue();
                        break;

                    case 3:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tЗадание 3 - Матричные выражения A^T - (B + C^T)");
                        Console.Write("\tВведите размер матриц n x n (1-10) >> ");
                        int matrixSize = validator.GetInt(1, 10);

                        Console.WriteLine("\n\tСоздаём матрицу A (случайные числа):");
                        Matrix matrixA = new Matrix(matrixSize, random);
                        Console.WriteLine($"\n{matrixA}");

                        Console.WriteLine("\n\tСоздаём матрицу B (случайные числа):");
                        Matrix matrixB = new Matrix(matrixSize, random);
                        Console.WriteLine($"\n{matrixB}");

                        Console.WriteLine("\n\tСоздаём матрицу C (по образцу):");
                        Matrix matrixC = new Matrix(matrixSize);
                        Console.WriteLine($"\n{matrixC}");

                        Console.WriteLine("\n\tВычисляем выражение A^T - (B + C^T):");
                        Matrix result = matrixA.Transpose() - (matrixB + matrixC.Transpose());
                        Console.WriteLine($"\n{result}");

                        utils.WaitForContinue();
                        break;

                    case 4:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tЗадание 4 - Бинарные файлы (кратные k)");

                        Console.Write("\tВведите количество чисел (1-100) >> ");
                        int fileCount = validator.GetInt(1, 100);

                        Console.Write("\tВведите минимальное значение (-1000 до 1000) >> ");
                        int minValue = validator.GetInt(-1000, 1000);

                        Console.Write("\tВведите максимальное значение (-1000 до 1000) >> ");
                        int maxValue = validator.GetInt(-1000, 1000);

                        while (maxValue < minValue)
                        {
                            ScreenUtils.PrintError("\tМаксимум должен быть не меньше минимума минимума :(");
                            Console.Write("\tПовторите ввод максимального значения >> ");
                            maxValue = validator.GetInt(-1000, 1000);
                        }

                        Console.Write("\tВведите делитель k (не равно 0) >> ");
                        int k = validator.GetInt();

                        while (k == 0)
                        {
                            ScreenUtils.PrintError("\tДелитель не может быть равен 0 :(");
                            Console.Write("\tПовторите ввод >> ");
                            k = validator.GetInt();
                        }

                        Console.WriteLine();
                        FileTasks.CreateBinaryFile("data.bin", fileCount, minValue, maxValue, random);
                        FileTasks.FilterBinaryFile("data.bin", "filtered.bin", k);
                        Console.WriteLine();
                        FileTasks.PrintBinaryFile("data.bin");
                        Console.WriteLine();
                        FileTasks.PrintBinaryFile("filtered.bin");

                        utils.WaitForContinue();
                        break;

                    case 5:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tЗадание 5 - Бинарные файлы и структуры (игрушки)");

                        Console.Write("\tВведите количество игрушек (1-100) >> ");
                        int toysCount = validator.GetInt(1, 100);

                        Console.WriteLine();
                        FileTasks.CreateToysFile("toys.xml", toysCount, random);
                        Console.WriteLine();
                        FileTasks.PrintToysFile("toys.xml");
                        Console.WriteLine();
                        FileTasks.FindMostExpensiveConstructor("toys.xml");

                        utils.WaitForContinue();
                        break;

                    case 6:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tЗадание 6 - Текстовые файлы (сумма по индексу)");

                        Console.Write("\tВведите количество чисел (1-100) >> ");
                        int numbersCount = validator.GetInt(1, 100);

                        Console.Write("\tВведите минимальное значение (-1000 до 1000) >> ");
                        int minVal = validator.GetInt(-1000, 1000);

                        Console.Write("\tВведите максимальное значение (-1000 до 1000) >> ");
                        int maxVal = validator.GetInt(-1000, 1000);

                        while (maxVal < minVal)
                        {
                            ScreenUtils.PrintError("\tМаксимум должен быть не меньше минимума минимума :(");
                            Console.Write("\tПовторите ввод максимального значения >> ");
                            maxVal = validator.GetInt(-1000, 1000);
                        }

                        Console.WriteLine();
                        FileTasks.CreateNumbersFile("numbers.txt", numbersCount, minVal, maxVal, random);
                        Console.WriteLine();
                        FileTasks.PrintNumbersFile("numbers.txt");
                        Console.WriteLine();
                        FileTasks.FindSumEqualIndex("numbers.txt");

                        utils.WaitForContinue();
                        break;

                    case 7:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tЗадание 7 - Текстовые файлы (произведение кратных k)");

                        Console.Write("\tВведите количество строк (1-50) >> ");
                        int linesCount = validator.GetInt(1, 50);

                        Console.Write("\tВведите минимальное значение (-1000 до 1000) >> ");
                        int minVal7 = validator.GetInt(-1000, 1000);

                        Console.Write("\tВведите максимальное значение (-1000 до 1000) >> ");
                        int maxVal7 = validator.GetInt(-1000, 1000);

                        while (maxVal7 < minVal7)
                        {
                            ScreenUtils.PrintError("\tМаксимум должен быть не меньше минимума минимума :(");
                            Console.Write("\tПовторите ввод максимального значения >> ");
                            maxVal7 = validator.GetInt(-1000, 1000);
                        }

                        Console.Write("\tВведите делитель k (не равно 0) >> ");
                        int k7 = validator.GetInt();

                        while (k7 == 0)
                        {
                            ScreenUtils.PrintError("\tДелитель не может быть равен 0 :(");
                            Console.Write("\tПовторите ввод >> ");
                            k7 = validator.GetInt();
                        }

                        Console.WriteLine();
                        FileTasks.CreateMultiNumbersFile("multi_numbers.txt", linesCount, minVal7, maxVal7, random);
                        Console.WriteLine();
                        FileTasks.PrintMultiNumbersFile("multi_numbers.txt");
                        Console.WriteLine();
                        FileTasks.FindProductDivisibleByK("multi_numbers.txt", k7);

                        utils.WaitForContinue();
                        break;

                    case 8:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tЗадание 8 - Текстовые файлы (фильтрация строк)");

                        Console.Write("\tВведите количество строк (1-50) >> ");
                        int textLinesCount = validator.GetInt(1, 50);

                        Console.WriteLine();
                        FileTasks.CreateTextFile("text.txt", textLinesCount, random);
                        Console.WriteLine();
                        FileTasks.PrintTextFile("text.txt");
                        Console.WriteLine();
                        FileTasks.FilterLinesWithoutRussian("text.txt", "filtered_text.txt");
                        Console.WriteLine();
                        FileTasks.PrintTextFile("filtered_text.txt");

                        utils.WaitForContinue();
                        break;

                    case 0:
                        Console.Clear();
                        ScreenUtils.PaintLine("\n\tДо новых встреч!\n\n\n", Color.Green);
                        ScreenUtils.DrawPicture("goodbye");
                        isRun = false;
                        break;

                    default:
                        ScreenUtils.PrintError("\tНекорректный выбор!");
                        utils.WaitForContinue();
                        break;
                }
            } while (isRun);
        }
    }
}