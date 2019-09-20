using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _214_ListTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var scoreList = new List<int>();
            scoreList.Add(45);
            scoreList.Add(4355);
            scoreList.Add(4785);
            scoreList.Add(4545);
            scoreList.Add(4455);
            scoreList.Add(415);
            scoreList.Add(454);
            scoreList.Add(455);

            for (int i = 0; i < scoreList.Count; i++)
            {
                Console.Write(scoreList[i] + " ");
            }
            Console.WriteLine();
            foreach (var item in scoreList)
            {
                Console.Write(item + " ");
            }


            Console.ReadKey();
        }
    }
}
