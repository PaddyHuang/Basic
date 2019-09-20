using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020_StructFunction
{
    struct CustomName
    {
        public string firstName;
        public string lastName;

        public string ToString()
        {
            return string.Format("My Name is {0}·{1}", firstName, lastName);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CustomName name;
            name.firstName = "Polin";
            name.lastName = "Huang";
            Console.WriteLine(name.ToString());
            Console.ReadKey();
        }
    }
}
