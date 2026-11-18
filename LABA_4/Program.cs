using System;
using System.Collections.Generic;

namespace LABA_4
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
            int choice;
            int count;

            List<string> list;
            bool hasDuplicates;

            LinkedList<string> linkedList;
            string value;
            bool isRemoved;

            int listenersCount;
            HashSet<string> catalog;
            List<HashSet<string>> listeners;

            string textPath = "text.txt";
            HashSet<char> vowels;

            string olympiadPath = "olympiad.txt";
            string olympiadResult;

            do
            {
                Console.Clear();
                ScreenUtils.DrawPicture("laba");
                ScreenUtils.PaintHeader("\n\tЛАБОРАТОРНАЯ РАБОТА 4");
                Console.WriteLine("\t1) Задание 1 - Одинаковые элементы в списке");
                Console.WriteLine("\t2) Задание 2 - Удаление первого вхождения");
                Console.WriteLine("\t3) Задание 3 - Музыкальные предпочтения");
                Console.WriteLine("\t4) Задание 4 - Гласные в одном слове");
                Console.WriteLine("\t5) Задание 5 - Олимпиада");
                Console.WriteLine("\t-1) Выход из программы");
                ScreenUtils.Paint("\tВыберите действие >> ", Color.Cyan);

                choice = validator.GetInt();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tЗадание 1 - Одинаковые элементы в списке");
                        Console.Write("\tВведите количество элементов " +
                            "(1-25, 0 - сработает автозаполнение) >> ");
                        count = validator.GetInt(0, 25);

                        if (count == 0)
                        {
                            list = CollectionTasks.CreateRandomList(random);
                        }
                        else
                        {
                            list = CollectionTasks.ReadList(count, validator);
                        }

                        Console.WriteLine("\n\tСписок:");
                        CollectionTasks.PrintList(list);

                        hasDuplicates = CollectionTasks.HasDuplicates(list);

                        if (hasDuplicates)
                        {
                            ScreenUtils.PaintLine("\n\tВ списке есть одинаковые элементы", Color.Green);
                        }
                        else
                        {
                            ScreenUtils.PaintLine("\n\tВсе элементы списка разные", Color.Yellow);
                        }

                        utils.WaitForContinue();
                        break;

                    case 2:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tЗадание 2 - Удаление первого вхождения");
                        Console.Write("\tВведите количество элементов " +
                            "(1-25, 0 - сработает автозаполнение) >> ");
                        count = validator.GetInt(0, 25);

                        if (count == 0)
                        {
                            linkedList = CollectionTasks.CreateRandomLinkedList(random);
                        }
                        else
                        {
                            linkedList = CollectionTasks.ReadLinkedList(count, validator);
                        }

                        Console.WriteLine("\n\tСписок до удаления:");
                        CollectionTasks.PrintLinkedList(linkedList);

                        Console.Write("\n\tВведите элемент для удаления >> ");
                        value = validator.GetString();

                        isRemoved = CollectionTasks.RemoveFirst(linkedList, value);

                        if (isRemoved)
                        {
                            ScreenUtils.PaintLine("\n\tПервое вхождение удалено", Color.Green);
                            Console.WriteLine("\n\tСписок после удаления:");
                            CollectionTasks.PrintLinkedList(linkedList);
                        }
                        else
                        {
                            ScreenUtils.PaintLine("\n\tТакого элемента в списке нет", Color.Yellow);
                        }

                        utils.WaitForContinue();
                        break;

                    case 3:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tЗадание 3 - Музыкальные предпочтения");
                        Console.Write("\tВведите количество произведений " +
                            "(1-10, 0 - сработает автозаполнение) >> ");
                        count = validator.GetInt(0, 10);

                        Console.Write("\tВведите количество меломанов (1-3) >> ");
                        listenersCount = validator.GetInt(1, 3);

                        if (count == 0)
                        {
                            catalog = CollectionTasks.CreateRandomCatalog(random);
                            listeners = CollectionTasks.CreateRandomListeners(
                                catalog, listenersCount, random);
                        }
                        else
                        {
                            catalog = CollectionTasks.ReadCatalog(count, validator);
                            listeners = CollectionTasks.ReadListeners(
                                catalog, listenersCount, validator);
                        }

                        Console.WriteLine();
                        CollectionTasks.PrintSet("Перечень: ", catalog);
                        CollectionTasks.PrintListeners(listeners);

                        Console.WriteLine();
                        CollectionTasks.PrintSet("Нравятся всем: ",
                            CollectionTasks.GetLikedByAll(listeners));
                        CollectionTasks.PrintSet("Нравятся некоторым: ",
                            CollectionTasks.GetLikedBySome(listeners));
                        CollectionTasks.PrintSet("Не нравятся никому: ",
                            CollectionTasks.GetLikedByNobody(catalog, listeners));

                        utils.WaitForContinue();
                        break;

                    case 4:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tЗадание 4 - Гласные в одном слове");
                        Console.Write("\tВведите количество строк текста " +
                            "(1-5, 0 - сработает автозаполнение) >> ");
                        count = validator.GetInt(0, 5);

                        Console.WriteLine();

                        if (count == 0)
                        {
                            CollectionTasks.CreateRandomTextFile(textPath, random);
                        }
                        else
                        {
                            CollectionTasks.CreateTextFileFromKeyboard(textPath, count, validator);
                        }

                        Console.WriteLine();
                        CollectionTasks.PrintTextFile(textPath);

                        vowels = CollectionTasks.FindVowelsInOneWord(textPath);
                        CollectionTasks.PrintVowels(vowels);

                        utils.WaitForContinue();
                        break;

                    case 5:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\tЗадание 5 - Олимпиада");
                        Console.Write("\tВведите количество участников " +
                            "(1-30, 0 - сработает автозаполнение) >> ");
                        count = validator.GetInt(0, 30);

                        Console.WriteLine();

                        if (count == 0)
                        {
                            CollectionTasks.CreateRandomOlympiadFile(olympiadPath, random);
                        }
                        else
                        {
                            CollectionTasks.CreateOlympiadFileFromKeyboard(olympiadPath, count, validator);
                        }

                        Console.WriteLine();
                        CollectionTasks.PrintTextFile(olympiadPath);

                        olympiadResult = CollectionTasks.FindBestNonWinner(olympiadPath);
                        ScreenUtils.PaintLine($"\n\tОтвет: {olympiadResult}", Color.Green);

                        utils.WaitForContinue();
                        break;

                    case -1:
                        Console.Clear();
                        ScreenUtils.DrawPicture("goodbye");
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
    }
}