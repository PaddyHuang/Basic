using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _307_GenericBubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sortArray = new int[] { 123, 235, 8, 145, 46873 };
            TraditionalBubble(sortArray);
            foreach (var item in sortArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // Generic Bubble
            Employee[] employees = new Employee[]
            {
                new Employee("a",372),
                new Employee("b",362),
                new Employee("c",32),
                new Employee("d",3352),
                new Employee("e",3123),
                new Employee("f",322),
                new Employee("g",912),
            };

            GenericBubble<Employee>(employees, Employee.Compare);
            foreach (var item in employees)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }

        static void TraditionalBubble(int[] sortArray)
        {
            var swapped = true;
            do
            {
                swapped = false;
                for (int i = 0; i < sortArray.Length - 1; i++)
                {
                    if (sortArray[i] > sortArray[i + 1])
                    {
                        var temp = sortArray[i];
                        sortArray[i] = sortArray[i + 1];
                        sortArray[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        // 由于比较的数据类型不确定，故比较的方法也不确定，参数中还需要加上委托指向特定的比较方法
        static void GenericBubble<T>(T[] sortArray, Func<T, T, bool> compareMethod)
        {
            var swapped = true;
            do
            {
                swapped = false;
                for (int i = 0; i < sortArray.Length - 1; i++)
                {
                    if (compareMethod(sortArray[i], sortArray[i + 1]))
                    {
                        T temp = sortArray[i]; 
                        sortArray[i] = sortArray[i + 1];
                        sortArray[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

    }
}
