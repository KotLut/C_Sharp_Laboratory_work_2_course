using System;

namespace LABA1_LK_CP
{
    internal class Program
    {
        static void Main()
        {
            Lab1 lab = new Lab1();
            InputValidator validator = new InputValidator();
            Utils utils = new Utils();

            bool isRun = true;

            do
            {
                Console.Clear();
                Console.WriteLine("\n\tЛАБОРАТОРНАЯ РАБОТА 1");
                Console.WriteLine("\tВыберете задачу:");
                Console.WriteLine("\t1) Задание 1 - Методы");
                Console.WriteLine("\t2) Задание 2 - Условия");
                Console.WriteLine("\t3) Задание 3 - Циклы");
                Console.WriteLine("\t4) Задание 4 - Массивы");
                Console.WriteLine("\t0) Выход из программы");
                Console.Write("\tВыберите действие >> ");

                int choice = validator.GetInt();

                switch (choice)
                {
                    case 1:
                        bool isTask1Run = true;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\n\tЗадание 1 - Методы");
                            Console.WriteLine("\t1) Дробная часть");
                            Console.WriteLine("\t3) Букву в число");
                            Console.WriteLine("\t5) Двузначное");
                            Console.WriteLine("\t7) Диапазон");
                            Console.WriteLine("\t9) Равенство");
                            Console.WriteLine("\t0) Назад");
                            Console.Write("\tВыберите подзадачу >> ");

                            int taskChoice = validator.GetInt();

                            switch (taskChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("\t\t1.1 Дробная часть");
                                    Console.Write("\tВведите число >> ");

                                    double x = validator.GetDouble();

                                    double fractionResult = lab.fraction(x);

                                    Console.WriteLine($"\tРезультат: {fractionResult}");
                                    utils.WaitForContinue();
                                    break;

                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("\t\t1.3 Букву в число");
                                    Console.Write("\tВведите символ(цифру) >> ");

                                    char xChar = validator.GetChar();

                                    while (xChar < '0' || xChar > '9')
                                    {
                                        Console.WriteLine("\tНужно ввести цифру от 0 до 9 :(");
                                        Console.Write("\tПовторите ввод >> ");

                                        xChar = validator.GetChar();
                                    }

                                    int charResult = lab.charToNum(xChar);

                                    Console.WriteLine($"\tРезультат: {charResult}");
                                    utils.WaitForContinue();
                                    break;

                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("\t\t1.5 Двузначное");
                                    Console.Write("\tВведите число >> ");
                                    int number = validator.GetInt();

                                    bool isTwoDigits = lab.is2Digits(number);

                                    Console.WriteLine($"\tРезультат: {isTwoDigits}");
                                    utils.WaitForContinue();
                                    break;

                                case 7:
                                    Console.Clear();
                                    Console.WriteLine("\t\t1.7 Диапазон");
                                    Console.Write("\tВведите первую границу >> ");
                                    int a = validator.GetInt();

                                    Console.Write("\tВведите вторую границу >> ");
                                    int b = validator.GetInt();

                                    Console.Write("\tВведите число >> ");
                                    int num = validator.GetInt();

                                    bool isInRange = lab.isInRange(a, b, num);

                                    Console.WriteLine($"\tРезультат: {isInRange}");
                                    utils.WaitForContinue();
                                    break;

                                case 9:
                                    Console.Clear();
                                    Console.WriteLine("\t\t1.9 Равенство");
                                    Console.Write("\tВведите первое число >> ");
                                    int firstNumber = validator.GetInt();

                                    Console.Write("\tВведите второе число >> ");
                                    int secondNumber = validator.GetInt();

                                    Console.Write("\tВведите третье число >> ");
                                    int thirdNumber = validator.GetInt();

                                    bool isEqual = lab.isEqual(firstNumber,secondNumber,thirdNumber);

                                    Console.WriteLine($"\tРезультат: {isEqual}");
                                    utils.WaitForContinue();
                                    break;

                                case 0:
                                    isTask1Run = false;
                                    break;

                                default:
                                    Console.WriteLine("\tНекорректный выбор!");
                                    utils.WaitForContinue();
                                    break;
                            }
                        } while (isTask1Run);

                        break;

                    case 2:
                        bool isTask2Run = true;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\n\tЗадание 2 - Условия");
                            Console.WriteLine("\t1) Модуль числа");
                            Console.WriteLine("\t3) Тридцать пять");
                            Console.WriteLine("\t5) Тройной максимум");
                            Console.WriteLine("\t7) Двойная сумма");
                            Console.WriteLine("\t9) День недели");
                            Console.WriteLine("\t0) Назад");
                            Console.Write("\tВыберите подзадачу >> ");

                            int taskChoice = validator.GetInt();

                            switch (taskChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("\t\t2.1 Модуль числа");
                                    Console.Write("\tВведите число >> ");

                                    int number = validator.GetInt();

                                    int absResult = lab.abs(number);

                                    Console.WriteLine($"\tРезультат: {absResult}");
                                    utils.WaitForContinue();
                                    break;

                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("\t\t2.3 Тридцать пять");
                                    Console.Write("\tВведите число >> ");

                                    int z = validator.GetInt();

                                    bool is35Result = lab.is35(z);

                                    Console.WriteLine($"\tРезультат: {is35Result}");
                                    utils.WaitForContinue();
                                    break;

                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("\t\t2.5 Тройной максимум");

                                    Console.Write("\tВведите первое число >> ");
                                    int firstNumber = validator.GetInt();

                                    Console.Write("\tВведите второе число >> ");
                                    int secondNumber = validator.GetInt();

                                    Console.Write("\tВведите третье число >> ");
                                    int thirdNumber = validator.GetInt();

                                    int maxResult = lab.max3(
                                        firstNumber,
                                        secondNumber,
                                        thirdNumber);

                                    Console.WriteLine($"\tРезультат: {maxResult}");
                                    utils.WaitForContinue();
                                    break;

                                case 7:
                                    Console.Clear();
                                    Console.WriteLine("\t\t2.7 Двойная сумма");

                                    Console.Write("\tВведите первое число >> ");
                                    int x = validator.GetInt();

                                    Console.Write("\tВведите второе число >> ");
                                    int y = validator.GetInt();

                                    int sumResult = lab.sum2(x, y);

                                    Console.WriteLine($"\tРезультат: {sumResult}");
                                    utils.WaitForContinue();
                                    break;

                                case 9:
                                    Console.Clear();
                                    Console.WriteLine("\t\t2.9 День недели");
                                    Console.Write("\tВведите номер дня недели >> ");

                                    int dayNumber = validator.GetInt();

                                    string dayResult = lab.day(dayNumber);

                                    Console.WriteLine($"\tРезультат: {dayResult}");
                                    utils.WaitForContinue();
                                    break;

                                case 0:
                                    isTask2Run = false;
                                    break;

                                default:
                                    Console.WriteLine("\tНекорректный выбор!");
                                    utils.WaitForContinue();
                                    break;
                            }
                        } while (isTask2Run);

                        break;

                    case 3:
                        bool isTask3Run = true;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\n\tЗадание 3 - Циклы");
                            Console.WriteLine("\t1) Числа подряд");
                            Console.WriteLine("\t3) Четные числа");
                            Console.WriteLine("\t5) Длина числа");
                            Console.WriteLine("\t7) Квадрат");
                            Console.WriteLine("\t9) Правый треугольник");
                            Console.WriteLine("\t0) Назад");
                            Console.Write("\tВыберите подзадачу >> ");

                            int taskChoice = validator.GetInt();

                            switch (taskChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("\t\t3.1 Числа подряд");
                                    Console.Write("\tВведите число >> ");

                                    int number31 = validator.GetInt();

                                    string listResult = lab.listNums(number31);

                                    Console.WriteLine($"\tРезультат: {listResult}");
                                    utils.WaitForContinue();
                                    break;

                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("\t\t3.3 Четные числа");
                                    Console.Write("\tВведите число >> ");

                                    int num33 = validator.GetInt();

                                    string evenResult = lab.chet(num33);

                                    Console.WriteLine($"\tРезультат: {evenResult}");
                                    utils.WaitForContinue();
                                    break;

                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("\t\t3.5 Длина числа");
                                    Console.Write("\tВведите число >> ");

                                    long num35 = validator.GetLong();

                                    int lengthResult = lab.numLen(num35);

                                    Console.WriteLine($"\tРезультат: {lengthResult}");
                                    utils.WaitForContinue();
                                    break;

                                case 7:
                                    Console.Clear();
                                    Console.WriteLine("\t\t3.7 Квадрат");
                                    Console.Write("\tВведите размер квадрата >> ");

                                    int size = validator.GetInt();

                                    lab.square(size);

                                    utils.WaitForContinue();
                                    break;

                                case 9:
                                    Console.Clear();
                                    Console.WriteLine("\t\t3.9 Правый треугольник");
                                    Console.Write("\tВведите высоту >> ");

                                    int height = validator.GetInt();

                                    lab.rightTriangle(height);

                                    utils.WaitForContinue();
                                    break;

                                case 0:
                                    isTask3Run = false;
                                    break;

                                default:
                                    Console.WriteLine("\tНекорректный выбор!");
                                    utils.WaitForContinue();
                                    break;
                            }
                        } while (isTask3Run);

                        break;

                    case 4:
                        bool isTask4Run = true;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\n\tЗадание 4 - Массивы");
                            Console.WriteLine("\t1) Поиск первого значения");
                            Console.WriteLine("\t3) Поиск максимального");
                            Console.WriteLine("\t5) Добавление массива в массив");
                            Console.WriteLine("\t7) Возвратный реверс");
                            Console.WriteLine("\t9) Все вхождения");
                            Console.WriteLine("\t0) Назад");
                            Console.Write("\tВыберите подзадачу >> ");

                            int taskChoice = validator.GetInt();

                            switch (taskChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("\t\t4.1 Поиск первого значения");

                                    Console.Write("\tВведите размер массива >> ");
                                    int size41 = validator.GetInt();

                                    while (size41 <= 0)
                                    {
                                        Console.WriteLine("\tРазмер должен быть больше 0 :(");
                                        Console.Write("\tПовторите ввод >> ");
                                        size41 = validator.GetInt();
                                    }

                                    int[] arr41 = utils.GenerateArray(size41);

                                    Console.Write("\tМассив: ");
                                    utils.PrintArray(arr41);

                                    Console.Write("\tВведите число для поиска >> ");
                                    int x41 = validator.GetInt();

                                    int firstResult = lab.findFirst(arr41, x41);

                                    Console.WriteLine($"\tРезультат: {firstResult}");
                                    utils.WaitForContinue();
                                    break;

                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("\t\t4.3 Поиск максимального");

                                    Console.Write("\tВведите размер массива >> ");
                                    int size43 = validator.GetInt();

                                    while (size43 <= 0)
                                    {
                                        Console.WriteLine("\tРазмер должен быть больше 0 :(");
                                        Console.Write("\tПовторите ввод >> ");
                                        size43 = validator.GetInt();
                                    }

                                    int[] arr43 = utils.GenerateArray(size43);

                                    Console.Write("\tМассив: ");
                                    utils.PrintArray(arr43);

                                    int maxResult = lab.maxAbs(arr43);

                                    Console.WriteLine($"\tРезультат: {maxResult}");
                                    utils.WaitForContinue();
                                    break;

                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("\t\t4.5 Добавление массива в массив");

                                    Console.Write("\tВведите размер первого массива >> ");
                                    int size45 = validator.GetInt();

                                    while (size45 <= 0)
                                    {
                                        Console.WriteLine("\tРазмер должен быть больше 0 :(");
                                        Console.Write("\tПовторите ввод >> ");
                                        size45 = validator.GetInt();
                                    }

                                    int[] arr45 = utils.GenerateArray(size45);

                                    Console.Write("\tМассив: ");
                                    utils.PrintArray(arr45);

                                    Console.Write("\tВведите размер вставляемого массива >> ");
                                    int insSize = validator.GetInt();

                                    while (insSize <= 0)
                                    {
                                        Console.WriteLine("\tРазмер должен быть больше 0 :(");
                                        Console.Write("\tПовторите ввод >> ");
                                        insSize = validator.GetInt();
                                    }

                                    int[] ins45 = utils.GenerateArray(insSize);

                                    Console.Write("\tВставляемый массив: ");
                                    utils.PrintArray(ins45);

                                    Console.Write("\tВведите позицию вставки >> ");
                                    int pos = validator.GetInt();

                                    while (pos < 0 || pos > arr45.Length)
                                    {
                                        Console.WriteLine("\tПозиция должна находиться в пределах массива :(");
                                        Console.Write("\tПовторите ввод >> ");
                                        pos = validator.GetInt();
                                    }

                                    int[] addResult = lab.add(arr45, ins45, pos);

                                    Console.Write("\tРезультат: ");
                                    utils.PrintArray(addResult);

                                    utils.WaitForContinue();
                                    break;

                                case 7:
                                    Console.Clear();
                                    Console.WriteLine("\t\t4.7 Возвратный реверс");

                                    Console.Write("\tВведите размер массива >> ");
                                    int size47 = validator.GetInt();

                                    while (size47 <= 0)
                                    {
                                        Console.WriteLine("\tРазмер должен быть больше 0 :(");
                                        Console.Write("\tПовторите ввод >> ");
                                        size47 = validator.GetInt();
                                    }

                                    int[] arr47 = utils.GenerateArray(size47);

                                    Console.Write("\tМассив: ");
                                    utils.PrintArray(arr47);

                                    int[] reverseResult = lab.reverseBack(arr47);

                                    Console.Write("\tРезультат: ");
                                    utils.PrintArray(reverseResult);

                                    utils.WaitForContinue();
                                    break;

                                case 9:
                                    Console.Clear();
                                    Console.WriteLine("\t\t4.9 Все вхождения");

                                    Console.Write("\tВведите размер массива >> ");
                                    int size49 = validator.GetInt();

                                    while (size49 <= 0)
                                    {
                                        Console.WriteLine("\tРазмер должен быть больше 0 :(");
                                        Console.Write("\tПовторите ввод >> ");
                                        size49 = validator.GetInt();
                                    }

                                    int[] arr49 = utils.GenerateArray(size49);

                                    Console.Write("\tМассив: ");
                                    utils.PrintArray(arr49);

                                    Console.Write("\tВведите число для поиска >> ");
                                    int x49 = validator.GetInt();

                                    int[] findResult = lab.findAll(arr49, x49);

                                    Console.Write("\tРезультат: ");
                                    utils.PrintArray(findResult);

                                    utils.WaitForContinue();
                                    break;

                                case 0:
                                    isTask4Run = false;
                                    break;

                                default:
                                    Console.WriteLine("\tНекорректный выбор!");
                                    utils.WaitForContinue();
                                    break;
                            }
                        } while (isTask4Run);

                        break;

                    case 0:
                        Console.Clear();
                        Console.WriteLine("\n\tДо новых встреч!\n\n\n");
                        isRun = false;
                        break;

                    default:
                        Console.WriteLine("\tНекорректный выбор!");
                        utils.WaitForContinue();
                        break;
                }
            } while (isRun);
        }
    }
}