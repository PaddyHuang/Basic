using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_Struct
{
    struct Position
    {
        public float x;
        public float y;
        public float z;
    }

    enum Direction
    {
        East,
        Weat,
        South,
        North
    }

    struct Path
    {
        public float distance;
        public Direction dir;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 通过三个变量表示一个敌人的坐标
            //float enermy1X = 34;
            //float enermy1Y = 34;
            //float enermy1Z = 34;

            //float enermy2X = 34;
            //float enermy2Y = 34;
            //float enermy2Z = 34;

            // 实例化一个结构体变量时，相当于实例化结构体中所有的变量
            Position enermy1Position;
            enermy1Position.x = 34;

            Position enermy2Position;
            enermy2Position.x = 35;
            // 使用结构体，让程序结构更清晰

            Path path;
            path.dir = Direction.East;
            path.distance = 1000;
        }
    }
}
