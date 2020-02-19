using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _208_OOP_Inherence
{
    class Boss : Enermy
    {
        public override void Move()     // 重写：原来的方法不存在了
        {
            //this.hp = 100;      // 访问当前类的所有字段和方法
            this.HP = 100;
            base.AI();            // 访问父类中的所有字段和方法

            Console.WriteLine("Boss Move");
        }

        public new void AI()    // 当子类里有一个前命和父类相同的方法时，就会隐藏父类中的同名方法
        {                       // 父类中的方法仍存在
            Console.WriteLine("Boss AI");
        }

        public void Attack()
        {
            AI();
            Move();
            //hp = 100;
            HP = 100;   
            Console.WriteLine("Attack");
        }
    }
}
