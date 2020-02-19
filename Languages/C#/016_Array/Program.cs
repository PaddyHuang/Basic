using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _016_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initial Array
            // Method 1. 
            int[] scores = { 12, 123, 45654};   // 使用此方法赋值数组时，要在初始化时赋值
                                                //scores = { 12, 123, 45654};       // 这样赋值不行

            // Method 2.
            //int[] score1 = new int[];
            int[] scores1;
            scores1 = new int[10];

            // Method 3.
            int[] scores2 = new int[] { 1, 2, 3, 4 };
            Console.WriteLine(scores2[2]);

            Console.ReadKey();
        }
    }
}
