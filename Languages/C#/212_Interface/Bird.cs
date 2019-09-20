using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _212_Interface
{
    class Bird : IFly, IB
    {
        public void Fly()
        {
            
        }

        public void MethodA()
        {

        }

        public void Method1()
        {
            throw new NotImplementedException();
        }

        public void Method2()
        {
            throw new NotImplementedException();
        }        
    }
}
