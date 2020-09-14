using System;

namespace ForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入一个泛型链表");
            Console.WriteLine("输入链表长度N");
            int N;
            N = Int32.Parse(Console.ReadLine());
            string choice;
            Console.WriteLine("输入链表类型：1、整型；2、字符串型");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    GenericList<int> intList = new GenericList<int>();
                    for (int i = 1; i <= N; i++)
                    {
                        Console.WriteLine("输入第"+i+"个元素");
                        int k = Int32.Parse(Console.ReadLine());
                        intList.Add(k);
                    }
                    Action<int> action1 = (m => Console.WriteLine(m));
                    intList.ForEach(intList.Head, action1);
                    break;
                case "2":
                    GenericList<string> strList = new GenericList<string>();
                    for (int i = 1; i <= N; i++)
                    {
                        Console.WriteLine("输入第" + i + "个元素");
                        string k = Console.ReadLine();
                        strList.Add(k);
                    }
                    Action<string> action2 = (m => Console.WriteLine(m));
                    strList.ForEach(strList.Head, action2);
                    break;
                default:
                    Console.WriteLine("无该选项");
                    break;
            }
            
        }
    }

    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T> where T : IComparable
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(tail==null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Node<T> node, Action<T> action)
        {
            T max, min;
            max = min = node.Data;
            while (node != null)
            {
                action(node.Data);
                max = compareGenericMax(max, node.Data);
                min = compareGenericMin(min, node.Data);
                node = node.Next;
            }
            Console.Write("最大值为:");
            action( max);
            Console.Write("最小值为:");
            action(min);


        }
        public static T compareGenericMax(T t1, T t2)
        {
            if (t1.CompareTo(t2) > 0)
            {
                return t1;
            }
            else
            {
                return t2;
            }
        }
        public static T compareGenericMin(T t1, T t2)
        {
            if (t1.CompareTo(t2) > 0)
            {
                return t2;
            }
            else
            {
                return t1;
            }
        }
    }
}
