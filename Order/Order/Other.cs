using System;

namespace Order
{


    public class OrderedCargo
    {
        public int Num;
        public string Name;
        public double Price;

        public OrderedCargo(string Name, double Price,int Num)
        {
            this.Name = Name;
            this.Price = Price;
            this.Num = Num;
        }
        public string ToString()
        {
            string str = "商品名：" + Name + "\t单价：" + Price +"\t个数："+Num;
            return str;
        }

    }

    class MyException : Exception
    {
        public MyException(string message) : base(message)
        {
        }
    }
}