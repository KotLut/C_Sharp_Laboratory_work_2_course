using System;
using System.Collections.Generic;

namespace LABA_5
{
    internal class Program
    {
        static void Main()
        {
            ScreenUtils.Initialize();
            InputValidator validator = new InputValidator();
            Utils utils = new Utils();
            FreelanceDatabase database = new FreelanceDatabase("LR5-var6.xls");

            bool isRun = true;
            bool isLoaded;
            int choice;

            isLoaded = database.Load();

            if (!isLoaded)
            {
                utils.WaitForContinue();
            }

            do
            {
                Console.Clear();
                ScreenUtils.DrawPicture("laba");
                ScreenUtils.PaintHeader("\n\tЛАБОРАТОРНАЯ РАБОТА 5");
                Console.WriteLine("\t1) Чтение базы данных из Excel");
                Console.WriteLine("\t2) Просмотр базы данных");
                Console.WriteLine("\t3) Удаление элемента");
                Console.WriteLine("\t4) Добавление элемента");
                Console.WriteLine("\t5) Запрос 1 - Заказы дороже заданной суммы");
                Console.WriteLine("\t6) Запрос 2 - Выручка по услуге");
                Console.WriteLine("\t7) Запрос 3 - Исполнители страны по услуге");
                Console.WriteLine("\t8) Запрос 4 - Лучший исполнитель");
                Console.WriteLine("\t9) Сохранение изменений в Excel");
                Console.WriteLine("\t-1) Выход из программы");
                ScreenUtils.Paint("\tВыберите действие >> ", Color.Cyan);

                choice = validator.GetInt();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\t1) Чтение базы данных из Excel");
                        ReadDatabase(database, validator);
                        utils.WaitForContinue();
                        break;

                    case 2:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\t2) Просмотр базы данных");
                        ShowDatabase(database, validator);
                        utils.WaitForContinue();
                        break;

                    case 3:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\t3) Удаление элемента");
                        DeleteElement(database, validator);
                        utils.WaitForContinue();
                        break;

                    case 4:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\t4) Добавление элемента");
                        AddElement(database, validator);
                        utils.WaitForContinue();
                        break;

                    case 5:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\t5) Запрос 1 - Заказы дороже заданной суммы");
                        ShowOrdersMoreThan(database, validator);
                        utils.WaitForContinue();
                        break;

                    case 6:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\t6) Запрос 2 - Выручка по услуге");
                        ShowServiceTotal(database, validator);
                        utils.WaitForContinue();
                        break;

                    case 7:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\t7) Запрос 3 - Исполнители страны по услуге");
                        ShowPerformersByCountry(database, validator);
                        utils.WaitForContinue();
                        break;

                    case 8:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\t8) Запрос 4 - Лучший исполнитель");
                        ShowBestPerformer(database, validator);
                        utils.WaitForContinue();
                        break;

                    case 9:
                        Console.Clear();
                        ScreenUtils.PaintHeader("\n\t9) Сохранение изменений в Excel");
                        SaveDatabase(database);
                        utils.WaitForContinue();
                        break;

                    case -1:
                        if (CanExit(database, validator))
                        {
                            Console.Clear();
                            ScreenUtils.DrawPicture("goodbye");
                            ScreenUtils.PaintLine("\n\tДо новых встреч!\n", Color.Green);
                            isRun = false;
                        }
                        else
                        {
                            utils.WaitForContinue();
                        }

                        break;

                    default:
                        ScreenUtils.PrintError("\tНекорректный выбор!");
                        utils.WaitForContinue();
                        break;
                }
            } while (isRun);
        }

        static void ReadDatabase(FreelanceDatabase database, InputValidator validator)
        {
            int answer = 1;

            if (database.IsChanged)
            {
                Console.Write("\tЕсть несохранённые изменения, они пропадут. " +
                    "Продолжить? (1 - да, 0 - нет) >> ");
                answer = validator.GetInt(0, 1);
            }

            if (answer == 1)
            {
                if (database.Load())
                {
                    ScreenUtils.PaintLine("\n\tБаза данных прочитана", Color.Green);
                }
            }
        }

        static void ShowDatabase(FreelanceDatabase database, InputValidator validator)
        {
            int table;
            int count;
            int first;
            int last;

            table = ChooseTable(validator);

            if (table == 1)
            {
                count = database.Orders.Count;
            }
            else if (table == 2)
            {
                count = database.Services.Count;
            }
            else
            {
                count = database.Performers.Count;
            }

            if (count == 0)
            {
                ScreenUtils.PaintLine("\n\tТаблица пуста", Color.Yellow);
                return;
            }

            Console.Write("\tС какой строки (1-" + count + ", 0 - автоввод) >> ");
            first = validator.GetInt(0, count);

            if (first == 0)
            {
                first = 1;
                last = Math.Min(20, count);
            }
            else
            {
                Console.Write("\tПо какую строку (" + first + "-" + count + ") >> ");
                last = validator.GetInt(first, count);
            }

            Console.WriteLine();

            if (table == 1)
            {
                database.GetOrders(first, last).ForEach(order => Console.WriteLine("\t" + order));
            }
            else if (table == 2)
            {
                database.GetServices(first, last).ForEach(service => Console.WriteLine("\t" + service));
            }
            else
            {
                database.GetPerformers(first, last).ForEach(performer => Console.WriteLine("\t" + performer));
            }

            ScreenUtils.PaintLine("\n\tПоказаны строки с " + first + " по " + last +
                " из " + count, Color.Gray);
        }

        static int ChooseTable(InputValidator validator)
        {
            Console.WriteLine("\t1 - Заказы");
            Console.WriteLine("\t2 - Услуги");
            Console.WriteLine("\t3 - Исполнители");
            Console.Write("\tВыберите таблицу >> ");

            return validator.GetInt(1, 3);
        }

        static void DeleteElement(FreelanceDatabase database, InputValidator validator)
        {
            int table;
            int id;
            int relatedOrders = 0;
            int answer = 1;
            bool isFound;

            table = ChooseTable(validator);

            Console.Write("\tВведите код элемента для удаления >> ");
            id = validator.GetInt(1, int.MaxValue);

            if (table == 1)
            {
                isFound = database.HasOrder(id);
            }
            else if (table == 2)
            {
                isFound = database.HasService(id);
                relatedOrders = database.CountOrdersByService(id);
            }
            else
            {
                isFound = database.HasPerformer(id);
                relatedOrders = database.CountOrdersByPerformer(id);
            }

            if (!isFound)
            {
                ScreenUtils.PrintError("\n\tЭлемента с таким кодом нет :(");
                return;
            }

            if (relatedOrders > 0)
            {
                Console.Write("\n\tВместе с ним будет удалено заказов: " + relatedOrders +
                    ". Продолжить? (1 - да, 0 - нет) >> ");
                answer = validator.GetInt(0, 1);
            }

            if (answer == 0)
            {
                ScreenUtils.PaintLine("\n\tУдаление отменено", Color.Yellow);
                return;
            }

            if (table == 1)
            {
                database.RemoveOrder(id);
            }
            else if (table == 2)
            {
                database.RemoveService(id);
            }
            else
            {
                database.RemovePerformer(id);
            }

            ScreenUtils.PaintLine("\n\tЭлемент удалён", Color.Green);

            if (relatedOrders > 0)
            {
                ScreenUtils.PaintLine("\tУдалено связанных заказов: " + relatedOrders, Color.Green);
            }
        }

        static int ReadServiceId(FreelanceDatabase database, InputValidator validator)
        {
            int id = validator.GetInt(1, int.MaxValue);

            while (!database.HasService(id))
            {
                ScreenUtils.PrintError("\tУслуги с таким кодом нет :(");
                ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);

                id = validator.GetInt(1, int.MaxValue);
            }

            return id;
        }

        static int ReadPerformerId(FreelanceDatabase database, InputValidator validator)
        {
            int id = validator.GetInt(1, int.MaxValue);

            while (!database.HasPerformer(id))
            {
                ScreenUtils.PrintError("\tИсполнителя с таким кодом нет :(");
                ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);

                id = validator.GetInt(1, int.MaxValue);
            }

            return id;
        }

        static void AddElement(FreelanceDatabase database, InputValidator validator)
        {
            int table;
            int id;
            int age;
            int serviceId;
            int performerId;
            int cost;
            string citizenship;
            string name;

            table = ChooseTable(validator);
            Console.WriteLine();

            if (table == 1)
            {
                if (database.Services.Count == 0 || database.Performers.Count == 0)
                {
                    ScreenUtils.PrintError("\tНельзя добавить заказ: нет услуг или исполнителей :(");
                    return;
                }

                Console.WriteLine("\tУслуги:");
                database.Services.ForEach(service => Console.WriteLine("\t" + service));

                Console.Write("\n\tВведите код услуги >> ");
                serviceId = ReadServiceId(database, validator);

                Console.Write("\tВведите код исполнителя >> ");
                performerId = ReadPerformerId(database, validator);

                Console.Write("\tВведите стоимость в рублях (1-100000000) >> ");
                cost = validator.GetInt(1, 100000000);

                id = database.AddOrder(serviceId, performerId, cost);
                ScreenUtils.PaintLine("\n\tЗаказ добавлен, код: " + id, Color.Green);
            }
            else if (table == 2)
            {
                Console.Write("\tВведите название услуги >> ");
                name = validator.GetString();

                if (database.HasServiceName(name))
                {
                    ScreenUtils.PrintError("\n\tТакая услуга уже есть :(");
                    return;
                }

                id = database.AddService(name);
                ScreenUtils.PaintLine("\n\tУслуга добавлена, код: " + id, Color.Green);
            }
            else
            {
                Console.Write("\tВведите возраст (18-125) >> ");
                age = validator.GetInt(18, 125);

                Console.Write("\tВведите гражданство >> ");
                citizenship = validator.GetString();

                id = database.AddPerformer(age, citizenship);
                ScreenUtils.PaintLine("\n\tИсполнитель добавлен, код: " + id, Color.Green);
            }
        }

        static int ChooseService(FreelanceDatabase database, InputValidator validator)
        {
            if (database.Services.Count == 0)
            {
                ScreenUtils.PrintError("\tСписок услуг пуст :(");
                return 0;
            }

            Console.WriteLine("\tУслуги:");
            database.Services.ForEach(service => Console.WriteLine("\t" + service));

            Console.Write("\n\tВведите код услуги >> ");

            return ReadServiceId(database, validator);
        }

        static void ShowOrdersMoreThan(FreelanceDatabase database, InputValidator validator)
        {
            int cost;
            int shown;
            List<Order> orders;

            Console.Write("\tВведите сумму в рублях (1-100000000) >> ");
            cost = validator.GetInt(1, 100000000);

            orders = database.GetOrdersMoreThan(cost);

            if (orders.Count == 0)
            {
                ScreenUtils.PaintLine("\n\tЗаказов дороже " + Order.FormatMoney(cost) + " нет", Color.Yellow);
                return;
            }

            shown = Math.Min(20, orders.Count);

            Console.WriteLine();
            orders.GetRange(0, shown).ForEach(order => Console.WriteLine("\t" + order));

            ScreenUtils.PaintLine("\n\tНайдено заказов: " + orders.Count +
                " (показаны первые " + shown + ")", Color.Green);
        }

        static void ShowServiceTotal(FreelanceDatabase database, InputValidator validator)
        {
            int serviceId;
            string serviceName;
            long total;

            serviceId = ChooseService(database, validator);

            if (serviceId == 0)
            {
                return;
            }

            serviceName = database.GetServiceName(serviceId);
            total = database.GetServiceTotal(serviceName);

            ScreenUtils.PaintLine("\n\tВыручка по услуге " + serviceName + ": " +
                Order.FormatMoney(total) + " руб.", Color.Green);
        }

        static void ShowPerformersByCountry(FreelanceDatabase database, InputValidator validator)
        {
            int serviceId;
            string serviceName;
            string country;
            List<Performer> performers;

            serviceId = ChooseService(database, validator);

            if (serviceId == 0)
            {
                return;
            }

            serviceName = database.GetServiceName(serviceId);

            Console.Write("\tВведите гражданство >> ");
            country = validator.GetString();

            performers = database.GetPerformersByCountryAndService(country, serviceName);

            if (performers.Count == 0)
            {
                ScreenUtils.PaintLine("\n\tТакие исполнители не найдены", Color.Yellow);
                return;
            }

            Console.WriteLine();
            performers.ForEach(performer => Console.WriteLine("\t" + performer));

            ScreenUtils.PaintLine("\n\tНайдено исполнителей: " + performers.Count, Color.Green);
        }

        static void ShowBestPerformer(FreelanceDatabase database, InputValidator validator)
        {
            int serviceId;
            int minAge;
            int performerId;
            string serviceName;
            string country;

            serviceId = ChooseService(database, validator);

            if (serviceId == 0)
            {
                return;
            }

            serviceName = database.GetServiceName(serviceId);

            Console.Write("\tВведите гражданство >> ");
            country = validator.GetString();

            Console.Write("\tИсполнитель должен быть старше (0-100) >> ");
            minAge = validator.GetInt(0, 100);

            performerId = database.GetBestPerformerId(country, minAge, serviceName);

            if (performerId == 0)
            {
                ScreenUtils.PaintLine("\n\tПодходящего исполнителя нет", Color.Yellow);
            }
            else
            {
                ScreenUtils.PaintLine("\n\tКод исполнителя: " + performerId, Color.Green);
            }
        }

        static void SaveDatabase(FreelanceDatabase database)
        {
            if (!database.IsChanged)
            {
                ScreenUtils.PaintLine("\n\tИзменений нет, сохранять нечего", Color.Yellow);
                return;
            }

            if (database.Save())
            {
                ScreenUtils.PaintLine("\n\tИзменения сохранены в файл " + database.Path, Color.Green);
            }
        }

        static bool CanExit(FreelanceDatabase database, InputValidator validator)
        {
            int answer;
            bool result = true;

            if (database.IsChanged)
            {
                Console.Write("\n\tЕсть несохранённые изменения. " +
                    "Сохранить перед выходом? (1 - да, 0 - нет) >> ");
                answer = validator.GetInt(0, 1);

                if (answer == 1)
                {
                    result = database.Save();
                }
            }

            return result;
        }
    }
}