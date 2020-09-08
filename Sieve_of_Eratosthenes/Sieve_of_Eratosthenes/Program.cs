using System;
using System.Collections.Generic;

namespace Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("寻找2-100内素数（埃氏筛法）");
            string a;
            bool cir;
            cir = true;
            while (cir)
            {
                Console.WriteLine("是否进行计算?Y/N");
                a = Console.ReadLine();
                switch (a)
                {
                    case "y":
                    case "Y": cir = false; break;
                    case "n":
                    case "N": return;
                    default: break;
                }
            }
                List<int> result = SoE();
                for (int i = 0; i < result.Count; i++)
                    Console.WriteLine(result[i]);

            

        }

        static List<int> SoE()
        {
            List<int> result = new List<int>();
            for (int i = 2; i <= 100; i++)
                result.Add(i);

            for (int i = 0; i <= result.Count-1; i++)
            {
                for(int j = 2;j<result[i];j++)
                {
                    if (result[i] % j == 0)
                    {
                        result.RemoveAt(i);
                        i--;
                    }
                }
            }


            return result;
        }
    }
}
