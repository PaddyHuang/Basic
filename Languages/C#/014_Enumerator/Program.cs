using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014_Enumerator
{
    // 枚举类型定义，每一个枚举占用一个int类型的空间
    enum GameState
    {
        Pause,
        Failed,
        Success,
        Start
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 实例化枚举类型
            GameState state = GameState.Start;

            if (state == GameState.Start)
            {
                Console.WriteLine("Start Game!");
            }

            Console.WriteLine(state);
            Console.WriteLine(typeof(GameState));

            Console.ReadKey();
        }
    }
}
