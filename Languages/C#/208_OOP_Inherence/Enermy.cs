using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _208_OOP_Inherence
{
    class Enermy
    {
        private float hp;
        public float HP
        {
            get { return hp;}
            set { hp = value;}
        }

        private float speed;
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public void AI()
        {   
            //Move();
            Console.WriteLine("AI Common Function");
        }

        public virtual void Move()      // virtual - override
        {
            Console.WriteLine("Move Common Function");
        }

    }
}
