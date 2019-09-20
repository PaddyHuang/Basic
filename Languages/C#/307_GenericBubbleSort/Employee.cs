using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _307_GenericBubbleSort
{
    class Employee
    {
        public string Name { get; private set; }
        public int Salary { get; private set; }
        // Construction
        public Employee(string name, int salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        /// <summary>
        /// 如果e1大于e2，返回true，否则返回false（比较薪水）
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool Compare(Employee e1, Employee e2)
        {
            if (e1.Salary > e2.Salary)  return true;
            return false;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Salary: {1}", Name, Salary);
        }

    }
}
