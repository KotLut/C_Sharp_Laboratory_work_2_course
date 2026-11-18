using System;

namespace LABA_4_OPERATORS
{
    internal class Program
    {
        static void Main()
        {
            ScreenUtils.Initialize();
            InputValidator validator = new InputValidator();
            Utils utils = new Utils();

            bool isRun = true;
            int choice;
            QuadraticEquation equation;
            QuadraticEquation secondEquation;
            double discriminant;
            bool hasRoots;

            do
            {
                Console.Clear();
                ScreenUtils.DrawPicture("laba");
                ScreenUtils.PaintHeader("\n\tЛАБОРАТОРНАЯ РАБОТА 4 (задания 6-7)");
                Console.WriteLine("\t6)1) Конструктор по умолчанию");
                Console.WriteLine("\t6)2) Конструктор с параметрами");
                Console.WriteLine("\t6)3) Конструктор копирования");
                Console.WriteLine("\t6)4) Свойства");
                Console.WriteLine("\t6)5) Защита от a = 0");
                Console.WriteLine("\t6)6) Корни уравнения\n");
                Console.WriteLine("\t7)7) Унарные операции ++ и --");
                Console.WriteLine("\t7)8) Приведение типов");
                Console.WriteLine("\t7)9) Операции == и !=");
                Console.WriteLine("\t-1) Выход из программы");
                ScreenUtils.Paint("\tВыберите действие >> ", Color.Cyan);

                choice = validator.GetInt();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tКонструктор по умолчанию");
                        equation = new QuadraticEquation();
                        Console.WriteLine("\n\tУравнение: " + equation);
                        PrintRoots(equation.GetRoots());
                        utils.WaitForContinue();
                        break;

                    case 2:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tКонструктор с параметрами");
                        equation = ReadEquation(validator);
                        Console.WriteLine("\n\tУравнение: " + equation);
                        utils.WaitForContinue();
                        break;

                    case 3:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tКонструктор копирования");
                        equation = ReadEquation(validator);
                        secondEquation = new QuadraticEquation(equation);
                        Console.WriteLine("\n\tОригинал: " + equation);
                        Console.WriteLine("\tКопия:    " + secondEquation);

                        equation.B = equation.B + 1;
                        Console.WriteLine("\n\tУвеличили b у оригинала на 1:");
                        Console.WriteLine("\tОригинал: " + equation);
                        Console.WriteLine("\tКопия:    " + secondEquation);
                        utils.WaitForContinue();
                        break;

                    case 4:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tСвойства");
                        equation = ReadEquation(validator);
                        Console.WriteLine("\n\tЧтение через свойства:");
                        Console.WriteLine("\ta = " + equation.A + ", b = " + equation.B + ", c = " + equation.C);

                        Console.WriteLine("\n\tЗадайте новые коэффициенты:");
                        equation.A = ReadCoefficientA(validator);
                        equation.B = ReadDouble("\tНовый b >> ", validator);
                        equation.C = ReadDouble("\tНовый c >> ", validator);
                        Console.WriteLine("\n\tУравнение: " + equation);
                        utils.WaitForContinue();
                        break;

                    case 5:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tЗащита от a = 0");
                        equation = new QuadraticEquation(2, 3, 1);
                        Console.WriteLine("\n\tУравнение: " + equation);

                        Console.WriteLine("\n\tПрисваиваем свойству A значение 0:");
                        equation.A = 0;
                        Console.WriteLine("\tУравнение: " + equation);

                        Console.WriteLine("\n\tСоздаём объект с a = 0 через конструктор:");
                        secondEquation = new QuadraticEquation(0, 5, 6);
                        Console.WriteLine("\tУравнение: " + secondEquation);
                        utils.WaitForContinue();
                        break;

                    case 6:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tКорни уравнения");
                        equation = ReadEquation(validator);
                        Console.WriteLine("\n\tУравнение: " + equation);
                        PrintRoots(equation.GetRoots());
                        utils.WaitForContinue();
                        break;

                    case 7:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tУнарные операции ++ и --");
                        equation = ReadEquation(validator);
                        Console.WriteLine("\n\te1: " + equation);

                        secondEquation = equation++;
                        Console.WriteLine("\n\tВыполнили e2 = e1++:");
                        Console.WriteLine("\te1: " + equation);
                        Console.WriteLine("\te2: " + secondEquation);

                        --equation;
                        Console.WriteLine("\n\tВыполнили --e1:");
                        Console.WriteLine("\te1: " + equation);
                        utils.WaitForContinue();
                        break;

                    case 8:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tПриведение типов");
                        equation = ReadEquation(validator);
                        Console.WriteLine("\n\tУравнение: " + equation);

                        discriminant = equation;
                        Console.WriteLine("\tДискриминант (неявно в double): " + discriminant);

                        hasRoots = (bool)equation;
                        Console.WriteLine("\tКорни существуют (явно в bool): " + hasRoots);
                        utils.WaitForContinue();
                        break;

                    case 9:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tОперации == и !=");
                        Console.WriteLine("\n\tПервое уравнение:");
                        equation = ReadEquation(validator);
                        Console.WriteLine("\n\tВторое уравнение:");
                        secondEquation = ReadEquation(validator);

                        Console.WriteLine("\n\te1: " + equation);
                        Console.WriteLine("\te2: " + secondEquation);
                        Console.WriteLine("\te1 == e2: " + (equation == secondEquation));
                        Console.WriteLine("\te1 != e2: " + (equation != secondEquation));
                        utils.WaitForContinue();
                        break;

                    case -1:
                        Console.Clear();
                        ScreenUtils.PaintLine("\n\tДо новых встреч!\n", Color.Green);
                        isRun = false;
                        break;

                    default:
                        ScreenUtils.PrintError("\tНекорректный выбор!");
                        utils.WaitForContinue();
                        break;
                }
            } while (isRun);
        }

        private static double ReadDouble(string message, InputValidator validator)
        {
            Console.Write(message);

            return validator.GetDouble();
        }

        private static double ReadCoefficientA(InputValidator validator)
        {
            double a = ReadDouble("\tКоэффициент a (не равен 0) >> ", validator);

            while (a == 0)
            {
                ScreenUtils.PrintError("\tКоэффициент a не может быть равен 0 :(");
                ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);
                a = validator.GetDouble();
            }

            return a;
        }

        private static QuadraticEquation ReadEquation(InputValidator validator)
        {
            double a = ReadCoefficientA(validator);
            double b = ReadDouble("\tКоэффициент b >> ", validator);
            double c = ReadDouble("\tКоэффициент c >> ", validator);

            return new QuadraticEquation(a, b, c);
        }

        private static void PrintRoots(double[] roots)
        {
            if (roots.Length == 0)
            {
                ScreenUtils.PaintLine("\tКорней нет", Color.Yellow);
                return;
            }

            Console.Write("\tКорней: " + roots.Length + ", значения: ");

            for (int i = 0; i < roots.Length; i++)
            {
                if (roots[i] == 0)
                {
                    Console.Write("0 ");
                }
                else
                {
                    Console.Write(roots[i] + " ");
                }
            }

            Console.WriteLine();
        }
    }
}