using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005__
{
    class Program
    {
        static void Main(string[] args)
        {
            // 在字符串前加@字符，编译器就不会识别字符串中的转义字符，如\n
            string str1 = "I'm a good man.\nYou're a bad girl.";
            Console.WriteLine(str1);
            string str2 = @"I'm a good man.\n You're a bad girl.";
            Console.WriteLine(str2);

            // @字符的常用方法
            string path1 = "c:\\xxx\\xx\\xxx.txt";
            Console.WriteLine(path1);
            string path2 = @"c:\xxx\xx\xxx.txt";
            Console.WriteLine(path2);

            Console.ReadKey();
        }
    }
}
