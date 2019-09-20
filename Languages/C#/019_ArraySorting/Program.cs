using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_ArraySorting
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] strArray = str.Split();    // Split string as Space
            int[] numArray = new int[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                int temp = Convert.ToInt32(strArray[i]);
                numArray[i] = temp;
            }

            // Sorting
            // Method 1. CLR Library
            //Array.Sort(numArray);

            // Method 2. Bubble Sort
            for (int j = 0; j < strArray.Length - 1; j++)       // 外层for循环控制内层for循环执行次数
            {
                for (int i = 0; i < numArray.Length - 1; i++)   // 每次遍历，把最大的放在最后
                {
                    // numArray[i] : numArray[i + 1]
                    if (numArray[i] > numArray[i + 1])
                    {
                        int temp = numArray[i];
                        numArray[i] = numArray[i + 1];
                        numArray[i + 1] = temp;
                    }
                }
            }            

            for (int i = 0; i < numArray.Length; i++)
            {
                Console.Write(numArray[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
