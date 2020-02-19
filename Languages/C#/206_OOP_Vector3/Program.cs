using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _206_OOP_Vector3
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector3 vector1 = new Vector3();
            //vector1.x = 1;
            //vector1.y = 1;
            //vector1.z = 1;

            vector1.SetX(1);
            vector1.SetY(1);
            vector1.SetZ(1);

            Console.WriteLine(vector1.Length());

            Vector3 vector2 = new Vector3(2, 2, 2);
            Console.WriteLine(vector2.Length());

            // 使用属性
            vector2.MyIntProperty = 800;        // set
            int temp = vector2.MyIntProperty;   //get
            Console.WriteLine(temp);

            Console.ReadKey();
        }
    }
}
