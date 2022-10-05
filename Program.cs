using System;
using AnaGeometric;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Start!\n");
        Point p1 = new Point(114, 514);
        Point O = new Point(0, 0);
        Line l1 = new Line(1, 0, 1, LineType.General);
        Line l2 = new Line(2, -2, -3, LineType.General);
        // Circle C1 = new Circle(1, 2, 1);
        //Console.WriteLine($"{p1}关于{l1}的对称点事");
        //Console.WriteLine(p1.GetSymmetryPoint(l1) + "\n");
        //Console.WriteLine($"l1: {l1}, l2: {l2}");
        //Console.WriteLine($"l1和l2的交点是{l1.GetIntersectionPoint(l2)}");
        Console.WriteLine(l2);
        l2.Convert(LineType.Slope_Intercept);
        Console.WriteLine(l2);

        /*
        Console.WriteLine("p1: " + p1.ToString());
        Console.WriteLine("l1: " + l1.ToString());
        Console.WriteLine("C1: " + C1.ToString());
        Console.WriteLine("Radius of C1: " + C1.GetRadius());
        l1.Convert(LineType.Slope_Intercept);
        Console.WriteLine("l1 in Slope intercept form: " + l1.ToString());
        Console.WriteLine("Min/Max distance between C1 and l1: ");
        foreach (double res in l1.GetDistanceFromCircle(C1))
        {
            Console.WriteLine(res);
        } 
        */
        /* Console.WriteLine("Distance between p1 and (0,0): " + AnaGeometric.Coords.GetDistance(p1, O));
        Console.WriteLine("Distance between (0,0) and y = x + 4: " + O.GetDistanceFromLine(l1));
        Console.WriteLine("Distance between p1 and y = x + 4: " + p1.GetDistanceFromLine(l1)); */

    }
}
