using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_Explicit_ImplicitConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            byte myByte = 123;
            int myInt = myByte; // 当把小类型的数据装入大类型的数据时，编译器会自动进行类型转换
            //myByte = myInt;     // 当把大类型的数据装入小类型时，需要进行显示转换（强类型转换），或使用Convert进行转换
            myByte = (Byte)myInt;
            myByte = Convert.ToByte(myInt);
        }
    }
}
