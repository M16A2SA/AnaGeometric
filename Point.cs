using System;
namespace AnaGeometric;
/// <summary>
/// Represents a point in the rectangular coordinate system.
/// </summary>
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
    public Point GetMidPoint(Point p2)
    {
        double x2 = p2.X;
        double y2 = p2.Y;
        double res_x = (X + x2) / 2;
        double res_y = (Y + y2) / 2;
        return new(res_x, res_y);
    }
    public Point GetSymmetryPoint(Line l1)
    {
        double A = l1.GetParam('A');
        double B = l1.GetParam('B');
        double C = l1.GetParam('C');
        //double x = 2 * A * (X * B * B + Y * B + C) / (A * A + B * B) - X;
        //double y = 2 * A * A * (X * B + Y + C / B) / (A * A + B * B) - C / B - Y;
        //double x = 2 * (X * B * B / A - B * Y - C) / (A + B * B / A) - X;
        //double y = 2 * (-C / B - (X * B - A * Y - A * C / B) / (A + B * B / A) - Y);
        double x = X - 2 * A * (A * X + B * Y + C) / (A * A + B * B);
        double y = Y - 2 * B * (A * X + B * Y + C) / (A * A + B * B);
        return new Point(x, y);
    }
    public override bool Equals(object? obj)
    {
        return obj is Point point &&
               X == point.X && Y == point.Y;
    }
    public override int GetHashCode() => base.GetHashCode();
    public override string ToString() => $"({X}, {Y})";
    public double GetX() => X;
    public double GetY() => Y;
    private double X { get; }
    private double Y { get; }
}
