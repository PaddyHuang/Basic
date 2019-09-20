using System;

namespace _Goto
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int myInteger = 5;
            goto myLabel;       // goto语句用来控制程序跳转到某个标签的位置
            myInteger++;
        myLabel: Console.WriteLine(myInteger);
        
        }
    }
}
