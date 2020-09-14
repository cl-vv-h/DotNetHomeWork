using System;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("选择模式：1、判断形状，计算面积；2、随机生成十个形状，计算其面积之和");
            string choose;
            choose = Console.ReadLine();
            switch (choose)
            {
                case "1":


                {
                    Console.WriteLine("请输入点集 输入方式为    a,b c,d ...  ");
                       string dotstr;
                    dotstr = Console.ReadLine();
                    dot[] Dots = new dot[dotstr.Length - dotstr.Replace(",", "").Length];
                    string[] dots = dotstr.Split(" ");
                    for (int i = 0; i < dots.Length; i++)
                    {
                        string[] a = dots[i].Split(",");
                      Dots[i] = new dot(float.Parse(a[0]), float.Parse(a[1]));
                    }
                        
                    Console.WriteLine("需要判断的形状");
                    Console.WriteLine("1、矩形；2、正方形；3、三角形");
                            
                    string choice;  
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Shapes shape1 = ShapeFactory.GetShapes(ShapeTypes.Rectangle, Dots);
                            Console.WriteLine("形状判断结果为:" + shape1.judgeShape());
                            if (shape1.judgeShape())
                                Console.WriteLine("面积为：" + shape1.getArea());
                            break;
                        case "2":
                            Shapes shape2 = ShapeFactory.GetShapes(ShapeTypes.Square, Dots);
                            Console.WriteLine("形状判断结果为:" + shape2.judgeShape());
                            if (shape2.judgeShape())
                                Console.WriteLine("面积为：" + shape2.getArea());
                            break;
                        case "3":
                            Shapes shape3 = ShapeFactory.GetShapes(ShapeTypes.Triangle, Dots);
                            Console.WriteLine("形状判断结果为:" + shape3.judgeShape());
                            if (shape3.judgeShape())
                                Console.WriteLine("面积为：" + shape3.getArea());
                            break;
                        default: Console.WriteLine("无该选项"); break;
                    }
                    break;
                }
                case "2":
                    {
                        Shapes[] shapes = new Shapes[10];
                        float x, y;
                        dot[] Dots1 = new dot[4];
                        dot[] Dots2 = new dot[3];
                        Console.WriteLine("形状生成中...");
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine((i+1)+"...");
                            Random ra = new Random();
                            int num = ra.Next(1, 4);
                            switch (num)
                            {
                                case 1:
                                    x = ra.Next(1, 40);
                                    y = ra.Next(1, 40);
                                    Dots1[0] = new dot(x, y);
                                    x = ra.Next(1, 40);
                                    y = ra.Next(1, 40);
                                    Dots1[2] = new dot(x, y);
                                    Dots1[1] = new dot(Dots1[0].y, Dots1[2].x);
                                    Dots1[3] = new dot(Dots1[0].x, Dots1[2].y);
                                    shapes[i] = ShapeFactory.GetShapes(ShapeTypes.Rectangle, Dots1);
                                    break;
                                case 2:
                                    x = ra.Next(1, 40);
                                    y = ra.Next(1, 40);
                                    Dots1[0] = new dot(x, y);
                                    x = ra.Next(1, 40);
                                    Dots1[2] = new dot(x, y + x - Dots1[0].x);
                                    Dots1[1] = new dot(Dots1[0].y, Dots1[2].x);
                                    Dots1[3] = new dot(Dots1[0].x, Dots1[2].y);
                                    shapes[i] = ShapeFactory.GetShapes(ShapeTypes.Square, Dots1);
                                    break;
                                default:
                                    x = ra.Next(1, 40);
                                    y = ra.Next(1, 40);
                                    Dots2[0] = new dot(x, y);
                                    x = ra.Next(1, 40);
                                    y = ra.Next(1, 40);
                                    Dots2[1] = new dot(x, y);
                                    x = ra.Next(1, 40);
                                    y = ra.Next(1, 40);
                                    Dots2[2] = new dot(x, y);
                                    shapes[i] = ShapeFactory.GetShapes(ShapeTypes.Triangle, Dots2);
                                    break;

                            }
                            //for (int j = 0; j < 4; j++)
                            //    Console.WriteLine(Dots2[1].x);
                        }
                        Console.WriteLine("生成完成，计算面积总和...");
                        float sum = 0;
                        for (int i = 0; i < 10; i++)
                            sum += shapes[i].getArea();
                        Console.WriteLine("面积总和为：" + sum);
                        break;
                    }
                default:Console.WriteLine("无该选项");break;
        }
        
        }

        public class dot
        {
            public float x;
            public float y;

            public dot(float x, float y)
            {
                this.x = x;
                this.y = y;
            }
        }

        static float dis(dot a,dot b)
        {
            return ((a.y - b.y) * (a.y - b.y) + (a.x - b.x) * (a.x - b.x));
        }

        static bool notSame(dot[] dots)
        {
            int i;
            for(i = 0;i<dots.Length;i++)
            {
                for(int j =i+1;j<dots.Length;j++)
                {
                    if (dots[i].x == dots[j].x && dots[i].y == dots[j].y)
                        break;
                }
            }
            if (i == dots.Length)
                return true;
            return false;
        }
        public interface Shapes
        {
            //dot[] Dots { get; set; }

            float getArea();

            bool judgeShape();

        }

        public class Rectangle : Shapes
        {
            public Rectangle(dot[] Dots)
            {
                this.Dots = Dots;
            }
            
            public dot[] Dots;

            public float getArea()
            {
                if (judgeShape())
                    return (float)Math.Pow(dis(Dots[0],Dots[1])*dis(Dots[1],Dots[2]),0.5);
                else
                    return 0;
            }

            public bool judgeShape()
            {
                if (Dots.Length == 4 && notSame(Dots) &&dis(Dots[0],Dots[1])== dis(Dots[2],Dots[3])&& dis(Dots[0],Dots[3])== dis(Dots[1],Dots[2]) && (dis(Dots[0],Dots[1])+dis(Dots[1],Dots[2]))==dis(Dots[0],Dots[2]))
                    return true;
                else
                    return false;
            }
        }

        public class Square : Shapes
        {
            public Square(dot[] Dots)
            {
                this.Dots = Dots;
            }

            public dot[] Dots;

            public float getArea()
            {
                if (judgeShape())
                    return (float)Math.Pow(dis(Dots[0], Dots[1]) * dis(Dots[1], Dots[2]), 0.5);
                else
                    return 0;
            }

            public bool judgeShape()
            {
                if (Dots.Length == 4 && notSame(Dots) && dis(Dots[0],Dots[1])==dis(Dots[1],Dots[2])&&dis(Dots[0], Dots[1]) == dis(Dots[2], Dots[3]) && dis(Dots[0], Dots[3]) == dis(Dots[1], Dots[2]) && (dis(Dots[0], Dots[1]) + dis(Dots[1], Dots[2])) == dis(Dots[0], Dots[2]))
                    return true;
                else
                    return false;
            }
        }

        public class Triangle : Shapes
        {
            public Triangle(dot[] Dots)
            {
                this.Dots = Dots;
            }

            public dot[] Dots;

            public float getArea()
            {
                if (judgeShape())
                {
                    float a = (float)0.5 * (Dots[0].x * Dots[1].y - Dots[1].x * Dots[0].y + Dots[1].x * Dots[2].y - Dots[2].x * Dots[1].y + Dots[2].x * Dots[0].y - Dots[0].x * Dots[2].y);
                    if (a > 0)
                        return a;
                    else return -a;
                }
                else
                    return 0;
            }

            public bool judgeShape()
            {
                if (Dots.Length == 3 && notSame(Dots))
                    return true;
                else
                    return false;
            }

            }
        public enum ShapeTypes
        {
            Rectangle,
            Square,
            Triangle
        }

        public class ShapeFactory
        {
            public static Shapes GetShapes(ShapeTypes shapeTypes, dot[] Dots)
            {
                if (shapeTypes == ShapeTypes.Rectangle)
                    return new Rectangle(Dots);
                if (shapeTypes == ShapeTypes.Square)
                    return new Square(Dots);
                if (shapeTypes == ShapeTypes.Triangle)
                    return new Triangle(Dots);
                else
                    return null;
            }
        }



   


    }
}
