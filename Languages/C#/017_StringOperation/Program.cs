using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _017_StringOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "$ abc ABC $";

            //string res = str.ToLower();           // 把字符串转化成小写并返回，对原字符串没有影响
            //string res = str.ToUpper();           // 把字符串转化成大写并返回，对原字符串没有影响
            string res = str.Trim('$', ' ', '#');   // 去掉字符串前面和后面指定的字符，对原字符串没有影响, 默认字符为空格
            //string res = str.TrimStart('$');        // 去掉字符串前面指定的字符，对原字符串没有影响
            //string res = str.TrimEnd('$');          // 去掉字符串后面指定的字符，对原字符串没有影响
            Console.WriteLine(res);

            string[] strArray = str.Split();
            foreach (string item in strArray)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey();
        }
    }
}
