using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Polin";
            // 1. length
            int length = s.Length;
            Console.WriteLine(length);
            // 2. Compare
            if (s == "Polin")
            {
                Console.WriteLine("Same");
            }
            else
            {
                Console.WriteLine("Different");
            }
            // 3. concat
            s = "http://" + s;
            Console.WriteLine(s);
            // 4. index
            char c = s[1];
            Console.WriteLine(c);
            // 5. Traversal
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
            }
            // 6. CompareTo
            s = " www.Polin.com ";
            int res = s.CompareTo("polin");
            Console.WriteLine(res);     // 当两个字符串相等，返回0
                                        // 当遇到的第一个不相同字符时，s的字符在字母表中更靠前，则返回1，否则返回-1

            // 7. Replace   替换指定字符或字符串
            var newStr1 = s.Replace('.', '-');
            var newStr2 = s.Replace(".", "---");
            Console.WriteLine(s);
            Console.WriteLine(newStr1);
            Console.WriteLine(newStr2);
            // 8. Split     分割字符串
            string[] strArray = s.Split('.');
            foreach (var item in strArray)
            {
                Console.WriteLine(item);
            }
            // 9. Substring   截取子字符串
            string str = s.Substring(4, 9);
            Console.WriteLine(str);
            // 10. ToUpper & ToLower    切换大小写
            Console.WriteLine(s.ToUpper());
            Console.WriteLine(s.ToLower());
            // 11.  Trim        去除首尾空格，中间空格不去除
            string str1 = s.Trim();
            Console.WriteLine(str1);
            // 12. IndexOf      查找字符串，成功则返回第一个字符的索引，否则返回-1
            int index = s.IndexOf("Polin");
            Console.WriteLine(index);



            Console.ReadKey();
        }
    }
}
