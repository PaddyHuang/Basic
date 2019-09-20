using System;

namespace _Function
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 返回一个数所有的因子
            Console.Write("Get all divisor of n\nEnter n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array1 = GetDivisor(n);
            Console.Write("{0}: ", n);
            //for (int i = 0; i < array.Length; i++)
                //Console.Write(" {0} ", array[i]);
            foreach (int item in array1)
                Console.Write(" {0} ", item);
            Console.WriteLine("");
            //Console.Write("Get max from an array\nHow many numbers in the array: ");
            //int length = Convert.ToInt32(Console.ReadLine());
            //int[] array2 = new int[length];
            //Console.Write("Enter numbers:");
            //for (int i = 0; i < array2.Length; i++)
            //array2[i] = Convert.ToInt32(Console.Read());
            int[] array2 = { 2, 32, 432, 1, 55, 7565, 4, 89 };
            int max = MaxInt(array2);
            Console.WriteLine("Max Value is {0}", max);
        }

        static int MaxInt(int[] array){
            int max = array[0];
            foreach(int item in array){
                max = (max > item) ? max : item;
            }
            return max;
        }

        static int[] GetDivisor(int number){
            int count = 0;
            for (int i = 1; i <= number; i++)
                if (number % i == 0)
                    count++;
            int[] array = new int[count];
            for (int i = 1, index = 0; i <= number; i++){
                if(number%i==0){
                    array[index] = i;
                    index++;
                }
            }
            return array;
        }
    }
}
