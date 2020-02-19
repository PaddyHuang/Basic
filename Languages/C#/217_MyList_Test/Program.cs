using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _217_MyList_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Definition
            MyList<int> myList = new MyList<int>();
            // 2. Add
            myList.Add(58);
            myList.Add(546);
            myList.Add(123);
            myList.Add(12);
            myList.Add(12);
            myList.Add(12);
            myList.Add(12);

            // 3. index 索引器
            myList[0] = 100;    // set
            //myList[50] = 0;

            // 4. Insert
            myList.Insert(1, 2);

            for (int i = 0; i < myList.Count; i++)
            {
                //Console.WriteLine(myList.GetItem(i));
                Console.WriteLine(myList[i]);   // get
            }

            Console.ReadKey(); 
        }
    }
}
