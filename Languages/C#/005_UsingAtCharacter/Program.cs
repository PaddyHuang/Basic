using System;

namespace _UsingAtCharacter
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 当我们在字符串前加@符号，就可以把一个字符串定义在多行
            // 编译器不会再去识别字符串中当转义字符
            // 如果需要在字符串中表示一对双引号，则用两个双引号表示
            string str1 = @"I'm a good man.\n
                You are a bad girl!";
            Console.WriteLine(str1);
            string str2 = @"I'm a good man.\n""You are a bad girl!";
            Console.WriteLine(str2);

            // 使用@字符当第二个好处
            string path1 = "C:\\XXX\\XX\\XXX.doc";
            Console.WriteLine(path1);
            string path2 = @"C:\XXX\XX\XXX.doc";
            Console.WriteLine(path2);
        }
    }
}
