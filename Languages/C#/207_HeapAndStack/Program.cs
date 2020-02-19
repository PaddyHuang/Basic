using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _207_HeapAndStack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            //Test2();
            //Test3();
            //Test4();
            Test5();

            Console.ReadKey();
        }

        static void Test1()
        {
            int i = 45;
            int j = 78;
            int temp = 89;
            char c = 's';
            bool b = true;
        }

        static void Test2()
        {
            int i = 98;
            int j = 546;
            string name = "Polin";
        }

        static void Test3()
        {
            string name = "Polin";
            string name2 = "Rophen";
            name = name2;
            Console.WriteLine(name + ":" + name2);
        }

        static void Test4()
        {
            Vector3 v = new Vector3();
            v.x = 100;
            v.y = 100;
            v.z = 100;
            Vector3 v2 = new Vector3();
            v2.x = 200;
            v2.y = 200;
            v2.z = 200;

            v2 = v;
            v2.x = 300;
            Console.WriteLine(v.x);
        }

        static void Test5()
        {
            Vector3[] vArray = new Vector3[] { new Vector3(), new Vector3(), new Vector3() };
            Vector3 v1 = vArray[0];
            vArray[0].x = 100;
            v1.x = 200;
            Console.WriteLine(vArray[0].x);
        }
    }
}
