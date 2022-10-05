using System;
namespace AnaGeometric;

public class Point
{
    /// <summary>
    /// Initalizes the point
    /// </summary>
    /// <param name="x">Horizontal coordinate</param>
    /// <param name="y">Vertical coordinate</param>
    public Point(double x = 0, double y = 0)
    {
        X = x;
        Y = y;
    }
    /// <summary>
    /// Gets the distance between two points
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns>The distance</returns>
    public static double GetDistance(Point p1, Point p2)
    {
        return Math.Sqrt(
            Math.Abs(
                Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)
                )
            );
    }
    /// <summary>
    /// Gets the distance between this instance and the given point
    /// </summary>
    /// <param name="p"></param>
    /// <returns>The distance</returns>
    public double GetDistanceFromPoint(Point p) =>
        Math.Sqrt(
            Math.Abs(
                Math.Pow(p.X - X, 2) + Math.Pow(p.Y - Y, 2)
                )
            );
    /// <summary>
    /// Gets the distance between this instance and the given line
    /// </summary>
    /// <param name="l1"></param>
    /// <returns></returns>
    public double GetDistanceFromLine(Line l1)
    {
        double a = l1.GetParam('A');
        double b = l1.GetParam('B');

        return Math.Abs(a * X + b * Y + l1.GetParam('C'))
            / Math.Sqrt(a * a + b * b);
    }
    public double GetSlopeFactor(Point p2)
    {
        return (X - p2.GetX()) / (Y - p2.GetY());
    }
    public Point GetSymmetryPoint(Line l1)
    {
        double A = l1.GetParam('A');
        double B = l1.GetParam('B');
        double C = l1.GetParam('C');
        double x = 2 * A * (X * B * B + Y * B + C) / (A * A + B * B) - X;
        double y = 2 * A * A * (X * B + Y + C / B) / (A * A + B * B) - C / B - Y;
        return new Point(-x, -y);
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
    public double GetX() => X;
    public double GetY() => Y;

    double X { get; set; }
    double Y { get; set; }

};
