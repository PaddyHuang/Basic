using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_TypeOfVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            byte myByte = 34;   // 0-255
            int score = 6000;
            long count = 100000000000000;
            Console.WriteLine(string.Format("byte: {0}, score: {1}, count: {2}", myByte, score, count));

            float myFloat = 12.5f;
            double myDouble = 12.6;
            Console.WriteLine(string.Format("float: {0}, double: {1}", myFloat, myDouble));

            char myChar = 'a';
            string myString = "";
            string myString2 = "a";
            bool myBool = true;
            Console.WriteLine(string.Format("char: {0}, str1: {1}, str2: {2}, bool: {3}", myChar, myString, myString2, myBool));

            Console.ReadKey();
        }
    }
}
