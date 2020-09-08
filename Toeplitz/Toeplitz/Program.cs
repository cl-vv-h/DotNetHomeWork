using System;

namespace Toeplitz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入一个M*N矩阵");

            int m, n;
            Console.WriteLine("输入行数M:");
            m = Int32.Parse(Console.ReadLine());
            Console.WriteLine("输入列数N");
            n = Int32.Parse(Console.ReadLine());
            int[,] matrix = new int[m, n]; 

            for(int i = 0;i<m;i++)
            {
                Console.WriteLine("请输入第"+i+"行各元素(元素间用,(英文逗号)隔开，输入N个元素)");
                string column;
                column = Console.ReadLine();
                string[] elements = column.Split(",");
                for (int j = 0; j < n; j++)
                    matrix[i, j] = Int32.Parse(elements[j]);
            }

            bool cir=true;
            string a;
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

            if (judge(matrix, m, n))
                Console.WriteLine("该矩阵是托普利茨矩阵 ");
            else
                Console.WriteLine("该矩阵不是托普利茨矩阵 ");

        }

        static bool judge(int[,] matrix, int m, int n)
        {
            int x, y;
            int count = 0;
            for(int i = 0;i<n;i++)
            {
                x = m - 1;
                y = i;
                while (x>0&&y>0)
                {
                    if (matrix[x, y] == matrix[x - 1, y - 1])
                    {
                        x--; y--;
                    }
                    else
                        break;
                }
                if (x == 0 || y == 0)
                    count++;

            }

            for(int i = 0;i<m;i++)
            {
                x = i;
                y = n - 1;
                while(x>0&&y>0)
                {
                    if (matrix[x, y] == matrix[x - 1, y - 1])
                    {
                        x--; y--;
                    }
                    else
                        break;
                }
                if (x == 0 || y == 0)
                    count++;
            }

            if (count == m + n)
                return true;
            else
                return false;
        }
    }
}
