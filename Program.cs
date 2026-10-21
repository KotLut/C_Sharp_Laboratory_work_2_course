using System;

namespace LK_LABA2_CSHARP
{
    internal class Program
    {
        static void Main()
        {
            ScreenUtils.Initialize();
            InputValidator validator = new InputValidator();
            Utils utils = new Utils();           

            bool isRun = true;
            do
            {
                Console.Clear();
                ScreenUtils.DrawPicture("laba");
                ScreenUtils.PaintHeader("\n\tЛАБОРАТОРНАЯ РАБОТА 2");
                Console.WriteLine("\tВыберите задачу:");
                Console.WriteLine("\t1) Задание 1.1 - Время");
                Console.WriteLine("\t2) Задание 1.2 - Дом");
                Console.WriteLine("\t3) Задание 2 - Сотрудники и отделы");
                Console.WriteLine("\t4) Задание 3 - Список сотрудников по отделу");
                Console.WriteLine("\t5) Задание 4 - Дом без изменения этажей");
                Console.WriteLine("\t6) Задание 5 - Пистолет");
                Console.WriteLine("\t0) Выход из программы");
                ScreenUtils.Paint("\tВыберите действие >> ", Color.Cyan);

                int choice = validator.GetInt();

                switch (choice)
                {
                    case 1:
                        bool isTask11Run = true;
                        do
                        {
                            Console.Clear();
                            ScreenUtils.PaintHeader("\n\tЗадание 1.1 - Время");
                            Console.WriteLine("\t1) Использовать значения из примеров");
                            Console.WriteLine("\t2) Ввести своё время");
                            Console.WriteLine("\t0) Назад");
                            ScreenUtils.Paint("\tВыберите подзадачу >> ", Color.Yellow);

                            int timeChoice = validator.GetInt();

                            switch (timeChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t1.1 Со значениями из примеров");

                                    Time time10 = new Time(10);
                                    Time time10000 = new Time(10000);
                                    Time time100000 = new Time(100000);

                                    Console.WriteLine($"\t10 секунд -> {time10}");
                                    Console.WriteLine($"\t10000 секунд -> {time10000}");
                                    Console.WriteLine($"\t100000 секунд -> {time100000}");
                                    utils.WaitForContinue();
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("\t\t1.1 Своё время");
                                    Console.Write("\tВведите секунды >> ");

                                    int userSeconds = validator.GetInt(0, int.MaxValue);

                                    Time userTime = new Time(userSeconds);

                                    Console.WriteLine($"\tРезультат: {userTime}");
                                    utils.WaitForContinue();
                                    break;

                                case 0:
                                    isTask11Run = false;
                                    break;

                                default:
                                    ScreenUtils.PrintError("\tНекорректный выбор!");
                                    utils.WaitForContinue();
                                    break;
                            }
                        } while (isTask11Run);

                        break;

                    case 2:
                        bool isTask12Run = true;
                        do
                        {
                            Console.Clear();
                            ScreenUtils.PaintHeader("\n\tЗадание 1.2 - Дом");
                            Console.WriteLine("\t1) Использовать значения из примеров");
                            Console.WriteLine("\t2) Ввести своё количество этажей");
                            Console.WriteLine("\t0) Назад");
                            ScreenUtils.Paint("\tВыберите подзадачу >> ", Color.Yellow);

                            int houseChoice = validator.GetInt();

                            switch (houseChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t1.2 Использовать значения из примеров");

                                    House house1 = new House(1);
                                    House house5 = new House(5);
                                    House house23 = new House(23);

                                    Console.WriteLine($"\t{house1}");
                                    Console.WriteLine($"\t{house5}");
                                    Console.WriteLine($"\t{house23}");
                                    utils.WaitForContinue();
                                    break;

                                case 2:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t1.2 Свой дом");
                                    Console.Write("\tВведите количество этажей (1-200) >> ");

                                    int userFloors = validator.GetInt(1, 200);

                                    House userHouse = new House(userFloors);

                                    Console.WriteLine($"\tРезультат: {userHouse}");
                                    utils.WaitForContinue();
                                    break;

                                case 0:
                                    isTask12Run = false;
                                    break;

                                default:
                                    ScreenUtils.PrintError("\tНекорректный выбор!");
                                    utils.WaitForContinue();
                                    break;
                            }
                        } while (isTask12Run);

                        break;

                    case 3:
                        bool isTask2Run = true;
                        do
                        {
                            Console.Clear();
                            ScreenUtils.PaintHeader("\n\tЗадание 2 - Сотрудники и отделы");
                            Console.WriteLine("\t1) Использовать значения из условия");
                            Console.WriteLine("\t2) Ввести своих сотрудников");
                            Console.WriteLine("\t0) Назад");
                            ScreenUtils.Paint("\tВыберите подзадачу >> ", Color.Yellow);

                            int employeeChoice = validator.GetInt();

                            switch (employeeChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t2.1 Сотрудники со значениями из условия");

                                    Department itDepartment = new Department("IT");

                                    Employee employee1 = new Employee("Петров", itDepartment);
                                    Employee employee2 = new Employee("Козлов", itDepartment);
                                    Employee employee3 = new Employee("Сидоров", itDepartment);

                                    itDepartment.Boss = employee2;

                                    Console.WriteLine($"\n\t{itDepartment}");
                                    Console.WriteLine($"\t{employee1}");
                                    Console.WriteLine($"\t{employee2}");
                                    Console.WriteLine($"\t{employee3}");
                                    
                                    utils.WaitForContinue();
                                    break;

                                case 2:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t2.2 Свои сотрудники");
                                    Console.Write("\tВведите название отдела >> ");

                                    string departmentTitle = validator.GetString();

                                    Department userDepartment = new Department(departmentTitle);

                                    Console.Write("\tСколько сотрудников в отделе (1-10) >> ");
                                    int employeesCount = validator.GetInt(1, 10);

                                    Employee[] employees = utils.ReadEmployees(userDepartment, employeesCount, validator);

                                    Console.WriteLine($"\n\tСотрудники отдела {departmentTitle}:");
                                    utils.PrintEmployees(employees);

                                    Console.Write("\tВведите номер начальника или 0, чтобы пропустить >> ");

                                    int bossNumber = validator.GetInt(0, employeesCount);

                                    if (bossNumber != 0)
                                    {
                                        userDepartment.Boss = employees[bossNumber - 1];
                                    }

                                    Console.WriteLine();

                                    Console.WriteLine($"\n\t{userDepartment}");
                                    for (int i = 0; i < employees.Length; i++)
                                    {
                                        Console.WriteLine($"\t{employees[i]}");
                                    }

                                    
                                    utils.WaitForContinue();
                                    break;

                                case 0:
                                    isTask2Run = false;
                                    break;

                                default:
                                    ScreenUtils.PrintError("\tНекорректный выбор!");
                                    utils.WaitForContinue();
                                    break;
                            }
                        } while (isTask2Run);

                        break;

                    case 4:
                        bool isTask3Run = true;
                        do
                        {
                            Console.Clear();
                            ScreenUtils.PaintHeader("\n\tЗадание 3 - Список сотрудников отдела");
                            Console.WriteLine("\t1) Использовать значения из условия");
                            Console.WriteLine("\t2) Ввести свой отдел");
                            Console.WriteLine("\t0) Назад");
                            ScreenUtils.Paint("\tВыберите подзадачу >> ", Color.Yellow);

                            int listChoice = validator.GetInt();

                            switch (listChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t3.1 Список сотрудников отдела");

                                    Department itDepartment = new Department("IT");

                                    Employee employee1 = new Employee("Петров", itDepartment);
                                    Employee employee2 = new Employee("Козлов", itDepartment);
                                    Employee employee3 = new Employee("Сидоров", itDepartment);

                                    itDepartment.Boss = employee2;

                                    Console.WriteLine("\n\tСписок отдела через ссылку на Петрова:");
                                    utils.PrintEmployees(employee1.GetDepartmentEmployees());

                                    Console.WriteLine("\n\tСписок отдела через ссылку на Сидорова:");
                                    utils.PrintEmployees(employee3.GetDepartmentEmployees());
                                    utils.WaitForContinue();
                                    break;

                                case 2:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t3.2 Свой отдел");
                                    Console.Write("\tВведите название отдела >> ");

                                    string listDepartmentTitle = validator.GetString();

                                    Department listDepartment = new Department(listDepartmentTitle);

                                    Console.Write("\tСколько сотрудников в отделе (1-10) >> ");

                                    int listCount = validator.GetInt(1, 10);

                                    Employee[] listEmployees = utils.ReadEmployees(listDepartment, listCount, validator);

                                    Console.WriteLine($"\n\tСотрудники отдела {listDepartmentTitle}:");
                                    utils.PrintEmployees(listEmployees);

                                    Console.Write("\n\tВыберите сотрудника (номер), чтобы узнать его коллег >> ");

                                    int pickedNumber = validator.GetInt(1, listCount);

                                    Employee picked = listEmployees[pickedNumber - 1];

                                    Console.WriteLine($"\n\tОтдел сотрудника {picked.Name}:");
                                    utils.PrintEmployees(picked.GetDepartmentEmployees());
                                    utils.WaitForContinue();
                                    break;

                                case 0:
                                    isTask3Run = false;
                                    break;

                                default:
                                    ScreenUtils.PrintError("\tНекорректный выбор!");
                                    utils.WaitForContinue();
                                    break;
                            }
                        } while (isTask3Run);

                        break;

                    case 5:
                        bool isTask4Run = true;
                        do
                        {
                            Console.Clear();
                            ScreenUtils.PaintHeader("\n\tЗадание 4 - Дом без изменения этажей");
                            Console.WriteLine("\t1) Использовать значения из условия");
                            Console.WriteLine("\t2) Создать свой дом");
                            Console.WriteLine("\t3) Попытка изменить количество этажей");
                            Console.WriteLine("\t0) Назад");
                            ScreenUtils.Paint("\tВыберите подзадачу >> ", Color.Yellow);

                            int fixedChoice = validator.GetInt();

                            switch (fixedChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t4.1 Значения из условия");

                                    House fixedHouse2 = new House(2);
                                    House fixedHouse35 = new House(35);
                                    House fixedHouse91 = new House(91);

                                    Console.WriteLine($"\t{fixedHouse2}");
                                    Console.WriteLine($"\t{fixedHouse35}");
                                    Console.WriteLine($"\t{fixedHouse91}");
                                    utils.WaitForContinue();
                                    break;

                                case 2:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t4.2 Свой дом");
                                    Console.Write("\tВведите количество этажей (1-1000) >> ");

                                    int fixedFloors = validator.GetInt(1, 1000);

                                    House fixedUserHouse = new House(fixedFloors);

                                    Console.WriteLine($"\tРезультат: {fixedUserHouse}");
                                    utils.WaitForContinue();
                                    break;

                                case 3:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t4.3 Попытка изменить количество этажей");

                                    House fixedSample = new House(35);

                                    Console.WriteLine($"\tСоздан: {fixedSample}");
                                    Console.WriteLine("\tПробуем записать 10 этажей...");

                                    try
                                    {
                                        fixedSample.Floors = 10;
                                    }
                                    catch (InvalidOperationException exception)
                                    {
                                        ScreenUtils.PaintLine("\n\tНе получилось :(", Color.Yellow);
                                        Console.WriteLine($"\tПричина: {exception.Message}");
                                    }

                                    Console.WriteLine($"\n\tИтог: {fixedSample}");
                                    utils.WaitForContinue();
                                    break;

                                case 0:
                                    isTask4Run = false;
                                    break;

                                default:
                                    ScreenUtils.PrintError("\tНекорректный выбор!");
                                    utils.WaitForContinue();
                                    break;
                            }
                        } while (isTask4Run);

                        break;

                    case 6:
                        bool isTask5Run = true;
                        do
                        {
                            Console.Clear();
                            ScreenUtils.PaintHeader("\n\tЗадание 5 - Пистолет");
                            Console.WriteLine("\t1) Использовать значения из условия");
                            Console.WriteLine("\t2) Пистолет без указания патронов");
                            Console.WriteLine("\t3) Свой пистолет");
                            Console.WriteLine("\t0) Назад");
                            ScreenUtils.Paint("\tВыберите подзадачу >> ", Color.Yellow);

                            int gunChoice = validator.GetInt();

                            switch (gunChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("\t\t5.1 Значения из условия");

                                    Gun gunThree = new Gun(3);

                                    Console.WriteLine($"\t{gunThree}");
                                    utils.ShootSeveralTimes(gunThree, 5);
                                    Console.WriteLine($"\t{gunThree}");
                                    utils.WaitForContinue();
                                    break;

                                case 2:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t5.2 Пистолет без указания патронов");

                                    Gun gunDefault = new Gun();

                                    Console.WriteLine($"\t{gunDefault}");
                                    utils.ShootSeveralTimes(gunDefault, 7);
                                    Console.WriteLine($"\t{gunDefault}");
                                    utils.WaitForContinue();
                                    break;

                                case 3:
                                    Console.Clear();
                                    ScreenUtils.PaintHeader("\t\t5.3 Свой пистолет");
                                    Console.Write("\tВведите количество патронов (0-100) >> ");

                                    int userBullets = validator.GetInt(0, 100);

                                    Gun userGun = new Gun(userBullets);

                                    Console.Write("\tСколько раз выстрелить (1-120) >> ");

                                    int shotsCount = validator.GetInt(1, 120);

                                    Console.WriteLine($"\n\t{userGun}");
                                    utils.ShootSeveralTimes(userGun, shotsCount);
                                    Console.WriteLine($"\t{userGun}");
                                    utils.WaitForContinue();
                                    break;

                                case 0:
                                    isTask5Run = false;
                                    break;

                                default:
                                    ScreenUtils.PrintError("\tНекорректный выбор!");
                                    utils.WaitForContinue();
                                    break;
                            }
                        } while (isTask5Run);

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