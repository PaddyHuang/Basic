using System;

namespace _Struct
{
    struct CustomerName{
        public string firstName;
        public string lastName;
        public string GetName(){
            return firstName + " " + lastName;
        }
    }

    struct Vector3{
        public float x;
        public float y;
        public float z;
        public double Distance(){
            return Math.Sqrt(x * x + y * y + z * z);
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            CustomerName myName;
            myName.firstName = "Polin";
            myName.lastName = "H";

            //Console.WriteLine("My name is: " + myName.firstName + " " + myName.lastName);
            Console.WriteLine("My name is: " + myName.GetName());

            Vector3 myVector;
            myVector.x = 3;
            myVector.y = 3;
            myVector.z = 3;
            Console.WriteLine(myVector.Distance());


        }
    }
}
