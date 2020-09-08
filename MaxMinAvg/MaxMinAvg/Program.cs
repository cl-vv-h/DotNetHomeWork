using System;

namespace MaxMinAvg
{
    class Program
    {
        static void Main(string[] args)
        {
            int count;
            string arraystr;
            Console.WriteLine("请输入元素个数");
            count = Int32.Parse(Console.ReadLine());

            int[] array = new int[count];

            Console.WriteLine("输入所有元素（元素间用,隔开）");
            arraystr = Console.ReadLine();

            string[] nums = arraystr.Split(",");
            for(int i = 0;i<count;i++)
            {
                array[i] = Int32.Parse(nums[i]);
            }

            Console.WriteLine("数组的最大值为:" + getMax(array).ToString());
            Console.WriteLine("数组的最小值为:" + getMin(array).ToString());
            Console.WriteLine("数组的平均值为:" + getAvg(array).ToString());

        }

        static int getMax(int[] array)
        {
            int[] a = array;
            Array.Sort(a);
            
            return a[array.Length-1];
        }

        static int getMin(int[] array)
        {
            int[] a = array;
            Array.Sort(a);

            return a[0];
        }

        static float getAvg(int[] array)
        {
            float sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];

            return sum / array.Length;
        }
    }
}
