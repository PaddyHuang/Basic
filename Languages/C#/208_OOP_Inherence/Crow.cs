using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _208_OOP_Inherence
{
    class Crow : Bird   // 继承一个抽象类时，必须实现其父类抽象方法
    {
        public override void Fly()
        {
            Console.WriteLine("Crow is flying");
            //throw new NotImplementedException();
        }
    }
}
