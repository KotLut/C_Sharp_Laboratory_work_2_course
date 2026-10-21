using System;

namespace LK_LABA2_CSHARP
{
    public class Employee
    {
        private string name;
        private Department department;

        public Employee()
        {
            Name = "Без имени";
            Department = null;
        }

        public Employee(string name, Department department)
        {
            Name = name;
            Department = department;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("\tИмя не может быть пустым :(");
                    name = "Без имени";
                }
                else
                {
                    name = value;
                }
            }
        }

        public Department Department
        {
            get
            {
                return department;
            }

            //set
            //{
            //    department = value;
            //}

            set
            {
                department = value;

                if (department != null)
                {
                    department.AddEmployee(this);
                }
            }
        }

        public bool IsBoss
        {
            get
            {
                return department != null && this == department.Boss;
            }
        }

        public Employee[] GetDepartmentEmployees()
        {
            if (department == null)
            {
                return new Employee[0];
            }

            return department.GetEmployees();
        }

        public override string ToString()
        {
            if (department == null)
            {
                return $"{name} не работает ни в одном отделе";
            }

            if (IsBoss)
            {
                return $"{name} начальник отдела {department.Title}";
            }

            if (department.Boss == null)
            {
                return $"{name} работает в отделе {department.Title}, начальник которого пока не назначен";
            }

            return $"{name} работает в отделе {department.Title}, начальник которого {department.Boss.Name}";
        }
    }
}