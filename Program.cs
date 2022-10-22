using System;
using AnaGeometric;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Start!\n");
        Circle C = new(0, 0, 1);
        Circle C2 = new(2, 0, 1);
        foreach (Point p in C.GetIntersectionPoint(C2))
        {
            Console.WriteLine(p);
        }
        //Console.WriteLine($"l1: {l1}, l2: {l2}");
        //Console.WriteLine($"l1和l2的交点是{l1.GetIntersectionPoint(l2)}");
    }
}
