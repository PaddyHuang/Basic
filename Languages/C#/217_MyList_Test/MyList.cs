using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _217_MyList_Test
{
    class MyList<T>
    {
        private T[] array;

        public int Capacity { get; }

        private int count;
        public int Count { get { return count; } }

        // 1. Constructor
        public MyList(int size)
        {
            if (size >= 0)
                array = new T[size];
        }

        public MyList()
        {
            array = new T[0];
        }

        // 2. index
        public T this[int index]
        {
            get // 当通过索引器取值时，会调用get块
            {
                return GetItem(index);
            }
            set // 当通过索引器设置值时，会调用set块
            {
                if (index >= 0 && index <= count - 1)
                {
                    array[index] = value;
                }
                else
                {
                    throw new Exception("索引超出了范围");
                }
            }
        }

        // 3. Add
        public void Add(T item)
        {
            if (count == Capacity)  // 判断列表是不是满了,如果一样大，说明列表满了，需要扩大空间
            {
                if (Capacity == 0)  // 当数组长度为0时，创建一个长度为4的数组
                {
                    array = new T[4];
                }
                else
                {                   // 当数组长度不为0时，创建一个长度为原来2倍的数组
                    var newArray = new T[Capacity * 2];
                    Array.Copy(array, newArray, count); // 把旧数组复制到新数组
                    array = newArray;       // 旧数组指针断掉
                }
            }

            array[count] = item;
            count++;        // 元素个数自增            
        }

        public T GetItem(int index)
        {
            if (index >= 0 && index <= count - 1)
            {
                return array[index];
            }
            else
            {
                throw new Exception("索引超出了范围");
            }
        }

        // 4. Insert
        public void Insert(int index, T item)
        {
            if (index >= 0 && index <= count - 1)
            {
                if (count == Capacity)  // 容量不够
                {
                    // 扩容
                    var newArray = new T[Capacity * 2];
                    Array.Copy(array, newArray, count);
                    array = newArray;                    
                }
                for (int i = count; i >= index; i--)
                {
                    array[i] = array[i - 1];    // array后移一位
                }

                array[index] = item;
                count++;
            }
            else
            {
                throw new Exception("索引超出了范围");
            }
        }

    }
}
