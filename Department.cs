using System;

namespace LK_LABA2_CSHARP
{
    public class Department
    {
        private string title;
        private Employee boss;
        private Employee[] employees;

        public Department()
        {
            Title = "Без названия";
            employees = new Employee[0];
        }

        public Department(string title)
        {
            Title = title;
            employees = new Employee[0];
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("\tНазвание отдела не может быть пустым :(");
                    title = "Без названия";
                }
                else
                {
                    title = value;
                }
            }
        }

        public Employee Boss
        {
            get
            {
                return boss;
            }
            set
            {
                if (value != null && value.Department != this)
                {
                    Console.WriteLine("\tНачальник должен работать в этом отделе :(");
                }
                else
                {
                    boss = value;
                }
            }
        }

        public void AddEmployee(Employee employee)
        {
            Employee[] result = new Employee[employees.Length + 1];

            for (int i = 0; i < employees.Length; i++)
            {
                result[i] = employees[i];
            }

            result[result.Length - 1] = employee;
            employees = result;
        }

        public Employee[] GetEmployees()
        {
            Employee[] result = new Employee[employees.Length];

            for (int i = 0; i < employees.Length; i++)
            {
                result[i] = employees[i];
            }

            return result;
        }

        public override string ToString()
        {
            if (boss == null)
            {
                return $"Отдел {title} (начальник не назначен):";
            }

            return $"Отдел {title} (начальник {boss.Name}):";
        }
    }



}