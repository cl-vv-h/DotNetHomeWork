using System;
using System.Collections.Generic;

namespace Order
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();
            /**List<OrderedCargo> cargos = new List<OrderedCargo>();
            OrderedCargo cargo1 = new OrderedCargo("牙刷", 4.5, 4);
            OrderedCargo cargo2 = new OrderedCargo("牙膏", 6, 2);
            cargos.Add(cargo1);
            cargos.Add(cargo2);
            cargos.Sort((x, y) => { return x.Price.CompareTo(y.Price); });
            Detail detail1 = new Detail(cargos, "张三", "没什么备注");
            Order order = new Order(1, detail1);

            List<OrderedCargo> cargos2 = new List<OrderedCargo>();
            cargo1 = new OrderedCargo("毛巾", 8.5, 1);
            cargo2 = new OrderedCargo("刷子", 3, 2);
            cargos2.Add(cargo1);
            cargos2.Add(cargo2);
            cargos2.Sort((x, y) => { return x.Price.CompareTo(y.Price); });
            Detail detail2 = new Detail(cargos2, "李四", "有一点备注");
            Order order2 = new Order(2, detail2);

            orders.Add(order);
            orders.Add(order2);

            Service.Export(orders);
            */
            orders = Service.Import();
            string a;
            bool con = true;
            while(con)
            {
                Console.WriteLine("1、创建订单，2、删除订单，3、查询订单，4、修改订单，5、退出");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        try
                        {
                            Console.Write("输入ID：");
                            int id = Int32.Parse(Console.ReadLine());
                            for (int i = 0; i < orders.Count; i++)
                                if (id == orders[i].ID)
                                    throw new MyException("该ID已存在");
                            Console.Write("顾客名：");
                            string Client = Console.ReadLine();
                            List<OrderedCargo> adds = new List<OrderedCargo>();
                            for(; ;)
                            {
                                Console.WriteLine("输入商品名(输入exit结束):");
                                string Name = Console.ReadLine();
                                if (Name == "exit")
                                    break;
                                Console.WriteLine("输入商品单价及个数:");
                                double price = double.Parse(Console.ReadLine());
                                int num = Int32.Parse(Console.ReadLine());
                                OrderedCargo add = new OrderedCargo(Name, price, num);
                                adds.Add(add); 
                            }
                            adds.Sort((x, y) => { return x.Price.CompareTo(y.Price); });
                            Console.WriteLine("备注:");
                            string remark = Console.ReadLine();
                            Detail detail = new Detail(adds, Client, remark);
                            Order singleorder = new Order(id, detail);
                            if (!Service.Equals(orders, singleorder))
                            {
                                orders.Add(singleorder);
                                Service.Orderlist(orders);
                            }
                            else
                                Console.WriteLine("该订单已存在");
                            break;
                            
                        }catch
                        {
                            throw new MyException("输入格式不正确");
                        }
                        
                    case "2":
                        {
                            Console.WriteLine("输入想要删除订单的订单号");
                            try
                            {
                                int id = Int32.Parse(Console.ReadLine());
                                for(int i = 0;i<orders.Count;i++)
                                {
                                    if (id == orders[i].ID)
                                    {
                                        orders.RemoveAt(i);
                                        break;
                                    }
                                    if (i == orders.Count-1)
                                        Console.WriteLine("无此ID");
                                }
                                break;
                            }
                            catch
                            {
                                throw new Exception("输入不正确");
                            }
                        }
                    case "3":
                        {
                            Console.WriteLine("输入关键字:");
                            string key = Console.ReadLine();
                            List<Order> query = new List<Order>();
                            query = Service.Query(orders, key);
                            for (int i = 0; i < query.Count; i++)
                                Console.WriteLine(query[i].ToString());
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("输入想要修改订单的订单号:");
                            try
                            {
                                int id = Int32.Parse(Console.ReadLine());
                                for (int i = 0; i < orders.Count; i++)
                                {
                                    if (id == orders[i].ID)
                                    {
                                        Service.Update(orders[i]);
                                        break;
                                    }
                                    if (i == orders.Count - 1)
                                        Console.WriteLine("无此订单");
                                }
                                break;
                            }
                            catch
                            {
                                throw new Exception("输入不正确");
                            }
                        }

                    case "5":return;

                    default: break;

                }
            }
        }
    }
}
