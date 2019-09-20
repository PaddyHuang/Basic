using System;

namespace _VariableType
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            byte myBute = 34;
            int score = 6000;
            long count = 1000000030;

            Console.WriteLine("byte:{0}, score:{1}, count:{2}", myBute, score, count);

            float myFloat = 12.5f;
            double myDouble = 12.6;

            char mychar = 'a';
            string myString = "a";

            Console.WriteLine("myFloat:{0}, myDouble:{1}", myFloat, myDouble);
            Console.WriteLine("char: {0}",sizeof(char));
            //Console.WriteLine("string: {0}", sizeof(string));
            Console.WriteLine("bool: {0}",sizeof(bool));
            Console.WriteLine("int: {0}",sizeof(int));
            Console.WriteLine("long: {0}",sizeof(long));
            Console.WriteLine("byte: {0}",sizeof(byte));
            Console.WriteLine("sbyte: {0}",sizeof(sbyte));
            Console.WriteLine("float: {0}",sizeof(float));
            Console.WriteLine("double: {0}",sizeof(double));

        }
    }
}
