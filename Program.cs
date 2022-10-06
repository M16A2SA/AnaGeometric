using System;
using AnaGeometric;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Start!\n");
        Point p1 = new Point(3, 4);

        Line l1 = new Line(1, 1, -3, LineType.General);
        Line l2 = new Line(1, -1, 2, LineType.General);
        Circle C1 = new Circle(1, 2, 1);
        Console.WriteLine($"{p1}关于{l1}的对称点是");
        Console.WriteLine(p1.GetSymmetryPoint(l1) + "\n");
        //Console.WriteLine($"l1: {l1}, l2: {l2}");
        //Console.WriteLine($"l1和l2的交点是{l1.GetIntersectionPoint(l2)}");
    }
}
