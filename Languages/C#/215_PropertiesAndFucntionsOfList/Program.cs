using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _215_PropertiesAndFucntionsOfList
{
    class Program
    {
        static void Main(string[] args)
        {
            var scoreList = new List<int>();
            scoreList.Add(500);
            scoreList.Add(700);
            scoreList.Add(900);

            // Traversal
            for (int i = 0; i < scoreList.Count; i++)
            {
                Console.Write(scoreList[i] + " ");
            }
            Console.WriteLine();

            // Insert
            scoreList.Insert(1, -5);

            // Remove
            scoreList.RemoveAt(0);

            // IndexOf  从前往后搜索
            var index = scoreList.IndexOf(900);
            Console.WriteLine(index);

            // LastIndexOf  从后往前搜索
            scoreList.Add(100);
            Console.WriteLine(scoreList.LastIndexOf(100));

            scoreList.Sort();

            // Traversal
            for (int i = 0; i < scoreList.Count; i++)
            {
                Console.Write(scoreList[i] + " ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
