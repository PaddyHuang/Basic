using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _303_RegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "I'm blue cat";

            // 搜索字符串符合正则表达式的情况
            // 把所有符合的位置，替换成后面的字符串
            string head = Regex.Replace(s, "^", "开始：");
            Console.WriteLine(head);

            string rear = Regex.Replace(s, "$", ": 结束");
            Console.WriteLine(rear);

            // Test 全部输入数字
            string str = Console.ReadLine();
            //TrditionalMatch(s);

            string pattern = @"^\d*$";      // 正则表达式  从头到尾全部是数字
            string pattern1 = @"\d*";       // 只要有一个数字
            string pattern2 = @"^\W*$";     // 除了字母、数字、下划线之外的所有字符
            
            bool isMatch = Regex.IsMatch(str, pattern1);
            Console.WriteLine(isMatch);

            string pattern3 = @"[^ahou]";   // 除了ahou之外的所有字符
            string res = Regex.Replace(s, pattern3, ".");
            Console.WriteLine(res);

            // 校验合法QQ号
            string qq = "1234567";
            string qq2 = "1234979456789";
            string qq3 = "d1234567";
            string patternQQ = @"^\d{5,12}$";
            Console.WriteLine(Regex.IsMatch(qq, patternQQ));
            Console.WriteLine(Regex.IsMatch(qq2, patternQQ));
            Console.WriteLine(Regex.IsMatch(qq3, patternQQ));

            // 择一匹配
            // 1. 查找数字或字母
            string str2 = "asdf2324{}|爱的";
            string pattern5 = @"\d|[a-z]";
            MatchCollection col =  Regex.Matches(str2, pattern5);
            foreach (var item in col)
            {                
                Console.WriteLine(item.ToString());    
            }
            // 2. 将人名输出
            string strNames = "zhang;wang,zhou.luo:huang";
            string patternNames = @"[;,.:]";    // 全部匹配
            string patternNames1 = @"[;]|[,]|[.]|[:]";    // 择一匹配
            string[] resArray = Regex.Split(strNames, patternNames);
            string[] resArray1 = Regex.Split(strNames, patternNames1);
            foreach (var item in resArray)
            {
                Console.WriteLine(item);
            }
            foreach (var item in resArray1)
            {
                Console.WriteLine(item);
            }

            // 分组限定
            // 重复多个字符使用(abcd){n}进行分组限定
            string inputStr = Console.ReadLine();
            string strGroup = @"(ab\w{2}){2}";  // == ab\w(2)ab\w(2)
            Console.WriteLine("分组字符重复2次替换为5555，结果为：" + Regex.Replace(inputStr, strGroup, "5555"));

            // 校验IPv4地址 一共4位，每一位0-255
            // 0-255.0-255.0-255.0-255
            string ipv4 = "192.168.1.1";
            string ipv4Pattern = @"^((([01]?\d\d?|2[0-4]\d|25[0-5])\.){3})([01]?\d\d?|2[0-4]\d|25[0-5])$";
            Console.WriteLine(Regex.IsMatch(ipv4, ipv4Pattern));

            Console.ReadKey();
        }

        static void TrditionalMatch(string s)
        {            
            bool isMatch = true;    //默认标志位，表示s是一个合法密码
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                {
                    isMatch = false;
                    break;
                }
            }

            if (isMatch)
            {
                Console.WriteLine("Valid Password");
            }
            else
            {
                Console.WriteLine("invalid Password");
            }
        }

    }
}
