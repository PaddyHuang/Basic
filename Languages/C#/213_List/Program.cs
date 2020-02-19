using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _213_List
{
    class Program
    {
        static void Main(string[] args)
        {
            // Definitoin
            // 1.
            List<int> scoreList = new List<int>();  // 创建一个空列表，尖括号表示列表的数据类型
            // 2.
            var scoreList2 = new List<int>();
            // 3.
            var scoreList3 = new List<int>() { 1, 2, 3 };

            // Add
            scoreList.Add(12);
            scoreList.Add(54);

            // Index from 0 on
            Console.WriteLine(scoreList[0]);
            //Console.WriteLine(scoreList[2]);    // Argument out of Range

            // Capacity & Count
            Console.WriteLine("Capacity: {0}, Count: {1}", scoreList.Capacity, scoreList.Count);

            // Test
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Capacity: {0}, Count: {1}", scoreList2.Capacity, scoreList2.Count);
                scoreList2.Add(10);
            }


            Console.ReadKey();
        }
    }
}
