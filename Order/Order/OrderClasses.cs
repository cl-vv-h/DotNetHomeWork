using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Order
{
    public class Order
    {
        public int ID;
        public Detail detail;

        public Order(int ID, Detail detail)
        {
            this.ID = ID;
            this.detail = detail;
        }

        public string ToString()
        {
            string str = "订单号：" + ID + "\t顾客：" + detail.Client + "\t总价：" + detail.Price;
            return str;
        }
    }

    public class Detail
    {
        public List<OrderedCargo> Cargos;
        public string Name;
        public string Client;
        public double Price;
        public string remark;

        public Detail(List<OrderedCargo> cargos,string Client,string remark)
        {
            cargos.Sort((x, y) => { return x.Name.CompareTo(y.Name); });
            Cargos = cargos;
            Name = NameToString();
            this.Client = Client;
            Price = getPrice();
            this.remark = remark;
        }

        public string NameToString()
        {
            string name="";
            for(int i=0;i<Cargos.Count;i++)
            {
                name += Cargos[i].Name;
                if (i != Cargos.Count - 1)
                    name += ",";
            }
            return name;
        }

        public double getPrice()
        {
            double price = 0;
            for(int i =0 ;i<Cargos.Count;i++)
            {
                price += Cargos[i].Price*Cargos[i].Num;
            }
            return price;
        }
        public void reflash(List<OrderedCargo> cargos, String Client)
        {
            Name = NameToString();
            this.Client = Client;
            Price = getPrice();
            Cargos = cargos;
        }

        public string ToString()
        {
            string str = "顾客：" + Client + "\t商品内容：" + NameToString() + "\t总价：" + Price + "\t备注：" + remark;
            return str;
        }

        
    }

    public static class Service
    {
        public static void Insert(Order order,List<Order> orders)
        {
            orders.Add(order);
        }

        public static void Delete(Order order,List<Order> orders)
        {
            orders.Remove(order);
        }

        public static void Update(Order order)
        {
            try
            {
                bool cyc = true;
                while (cyc)
                {
                    Console.WriteLine("1、修改顾客，2、添加商品，3、减少商品，4、修改备注，5、退出");
                    Console.WriteLine("输入选择:");
                    string str = Console.ReadLine();
                    switch (str)
                    {
                        case "1":
                            {
                                Console.WriteLine("输入新顾客信息：");
                                string client = Console.ReadLine();
                                order.detail.Client = client;
                                break;
                            }
                        case "2":
                            {
                                int tept = -1 ;
                                Console.WriteLine("需要添加的商品：");
                                string cargoname = Console.ReadLine();
                                for(int i=0;i<order.detail.Cargos.Count;i++)
                                {
                                    if (order.detail.Cargos[i].Name == cargoname)
                                        tept = i;
                                }
                                try
                                {
                                    if (tept == -1)
                                    {
                                        Console.WriteLine("单价:");
                                        double price = double.Parse(Console.ReadLine());
                                        Console.WriteLine("个数:");
                                        int num = Int32.Parse(Console.ReadLine());
                                        OrderedCargo orderedCargo = new OrderedCargo(cargoname, price, num);
                                        order.detail.Cargos.Add(orderedCargo);
                                        order.detail.Price += orderedCargo.Price * orderedCargo.Num;

                                    }
                                    else
                                    {
                                        Console.WriteLine("添加个数:");
                                        int num = Int32.Parse(Console.ReadLine());
                                        order.detail.Cargos[tept].Num += num;
                                        order.detail.Price += num * order.detail.Cargos[tept].Price;
                                    }
                                    break;
                                }catch(Exception e)
                                {
                                    throw new Exception("输入格式不正确");
                                }
                            }
                        case "3":
                            {
                                int tept = -1;
                                Console.WriteLine("需要删除的商品：");
                                string cargoname = Console.ReadLine();
                                for (int i = 0; i < order.detail.Cargos.Count; i++)
                                {
                                    if (order.detail.Cargos[i].Name == cargoname)
                                        tept = i;
                                }
                                try
                                {
                                    if (tept == -1)
                                    {
                                        Console.WriteLine("无该商品");

                                    }
                                    else
                                    {
                                        Console.WriteLine("减少个数:");
                                        int num = Int32.Parse(Console.ReadLine());
                                        if (num > order.detail.Cargos[tept].Num)
                                        {
                                            Console.WriteLine("没有这么多该商品");
                                        }
                                        else if(num == order.detail.Cargos[tept].Num)
                                        {
                                            order.detail.Cargos.RemoveAt(tept);
                                            order.detail.getPrice();
                                        }
                                        else
                                        {
                                            order.detail.Cargos[tept].Num -= num;
                                            order.detail.getPrice();
                                            //order.detail.Price -= num * order.detail.Cargos[tept].Price;
                                        }
                                    }
                                    break;
                                }
                                catch (Exception e)
                                {
                                    throw new Exception("输入格式不正确");
                                }
                            }
                        case "4":
                            {
                                Console.WriteLine("输入新备注信息：");
                                string remark = Console.ReadLine();
                                order.detail.remark = remark;
                                break;
                            }
                        case "5":cyc = false;break;
                        default:break;
                    }
                }
            }
            catch
            {
                throw new Exception("输入格式不正确");
            }
        }

        public static bool Equals(List<Order> orders, Order order)
        {
            for (int i = 0; i < orders.Count; i++)
                if (orders[i].detail.ToString() == order.detail.ToString())
                    return true;

            return false;
        }
        public static List<Order> Query(List<Order> orders,string str)
        {
            string regexstr = ".*" + str + ".*";
            var Query = (from order in orders where Regex.IsMatch(order.ID.ToString(),regexstr) || Regex.IsMatch(order.detail.ToString(),regexstr) 
                                select order);
            List<Order> query = Query.ToList();
            query.Sort((x, y) => { return x.detail.Price.CompareTo(y.detail.Price); });
            return query;
        }

        public static void Orderlist(List<Order> orders)
        {
            orders.Sort((x, y) => { return x.ID.CompareTo(y.ID); });
        }

        public static void Export(List<Order> orders)
        {
            XDocument document = new XDocument();
            XElement root = new XElement("List");
            for (int i = 0; i < orders.Count; i++)
            { 
                XElement order = new XElement("Order"+i);
                XElement cargos = new XElement("Cargos");
                List<OrderedCargo> a = orders[i].detail.Cargos;
                for (int j = 0; j < a.Count; j++)
                    cargos.SetElementValue("cargo" + j, a[j].Name + " " + a[j].Price + " " + a[j].Num);
                order.Add(cargos);
                XElement client = new XElement("Client");
                client.Value = (orders[i].detail.Client);
                XElement remark = new XElement("Remark");
                remark.Value = orders[i].detail.remark;
                order.Add(client);
                order.Add(remark);
                root.Add(order);
            }
            root.Save("Orders.xml");
        }


        public static List<Order> Import()
        {
            List<Order> orders = new List<Order>();
            XDocument document = XDocument.Load("Orders.xml");
            XElement root = document.Root;
            for (int i = 0; root.Element("Order" + (i)) != null; i++)
            {
                XElement order = root.Element("Order" + i);
                List<OrderedCargo> cargos = new List<OrderedCargo>();
                XElement Cargos = order.Element("Cargos");
                for (int j = 0; Cargos.Element("cargo" + (j)) != null; j++)
                {
                    XElement cargo = Cargos.Element("cargo" + (j));
                    string str = cargo.Value;
                    string[] strs = str.Split(" ");
                    OrderedCargo singleCargo = new OrderedCargo(strs[0], double.Parse(strs[1]), Int32.Parse(strs[2]));
                    cargos.Add(singleCargo);
                }
                XElement client = order.Element("Client");
                XElement remark = order.Element("Remark");

                Detail detail = new Detail(cargos, client.Value, remark.Value);
                Order singleOrder = new Order(i, detail);
                orders.Add(singleOrder);
            }

            return orders;
        }

    }
}