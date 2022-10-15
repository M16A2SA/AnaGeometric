using System;
using AnaGeometric;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Start!\n");
        Vector a = new(1, 0);
        Vector b = new(-1, 0);
        Console.WriteLine(a.GetAngle(b));
        Console.WriteLine(a.IsCollinear(b));
        Console.WriteLine(a.IsPerpendicular(b));
        //Console.WriteLine($"l1: {l1}, l2: {l2}");
        //Console.WriteLine($"l1和l2的交点是{l1.GetIntersectionPoint(l2)}");
    }
}
