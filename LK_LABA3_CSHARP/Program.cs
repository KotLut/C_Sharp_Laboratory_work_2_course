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