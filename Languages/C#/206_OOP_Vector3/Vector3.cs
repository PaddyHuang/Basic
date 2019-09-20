using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _206_OOP_Vector3
{
    public class Vector3
    {
        // 编程规范上，习惯把所有字段设置为private，只可以在类内部访问，不可以通过对象访问
        private float x, y, z;
        private float length;

        public float X
        {
            get { return x; }
            private set { x = value; }  // 如果在get或set前面加上 private， 表示这个块只能在类内部调用
        }

        //private string name;
        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}

        public string Name { get; set; }    // 编译器会自动一个字段，来存储Name

        private int age;
        public int Age
        {
            set
            {
                // 通过set方法，在设置值之前做一些校验工作
                // 属性的更多好处，需要在写代码过程中体会
                if (value >= 0)
                {
                    age = value;
                }
            }
        }

        // 属性中get或set必须有其中一个
        public int MyIntProperty
        {
            // 如果没有set块，则不能通过属性赋值了
            set
            {
                Console.WriteLine("Set");
                Console.WriteLine("在set块中访问value的值是：{0}", value);
            }
            // 如果没有get块，则不能通过属性取值了
            get
            {
                Console.WriteLine("Get");
                return 100;
            }
        }
        
        // 我们构造了一个构造函数，那么编译器不会为我们提供构造函数了
        public Vector3()
        {
            Console.WriteLine("Vector3的构造函数被调用了");
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            length = Length();
        }
        
        // 为字段提供set方法，来设置字段的值
        public void SetX(float x)
        {
            // 如果我们直接在方法内部访问同名的变量时，优先访问最近的（此处为形参）
            // 我们可以通过this. 表示访问的是类的字段或者方法
            this.x = x;
        }

        public void SetY(float y)
        {
            this.y = y;
        }

        public void SetZ(float z)
        {
            this.z = z;
        }

        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }
    }
}
