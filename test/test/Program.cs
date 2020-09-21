using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            object a=null;
            try
            {
                int b = (int)a;
            }catch(InvalidCastException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("asdaasd");
        }

    }
}
