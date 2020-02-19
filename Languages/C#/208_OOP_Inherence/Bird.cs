using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _208_OOP_Inherence
{
    abstract class Bird     // 一个抽象类，相当于一个不完整的模板
    {
        private float speed;

        public void Eat()
        {

        }

        public abstract void Fly();
        
    }
}
