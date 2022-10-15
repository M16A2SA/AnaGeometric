namespace AnaGeometric;

public readonly struct Vector
{
    private readonly double _x;
    private readonly double _y;

    public Vector(double x, double y)
    {
        _x = x;
        _y = y;
    }
    public static Vector operator +(Vector a) => a;
    public static Vector operator -(Vector a) => new(-a._x, -a._y);
    public static Vector operator +(Vector a, Vector b)
        => new(a._x + b._x, a._y + b._y);
    public static Vector operator -(Vector a, Vector b)
        => a + (-b);
    public static Vector operator *(double m, Vector a)
        => new(m * a._x, m * a._y);
    public static double operator *(Vector a, Vector b)
        => a._x * b._x + a._y * b._y;
    public double GetAngle(Vector a) => System.Math.Acos(this * a / (Modulus * a.Modulus));
    public Vector GetUnitVector() => (1 / Modulus) * this;
    public bool IsPerpendicular(Vector a) => this * a == 0;
    public bool IsCollinear(Vector a) => a._x * _y == a._y * _x;
    public bool Equals(Vector a) => _x == a._x && _y == a._y;
    public double Modulus => System.Math.Sqrt((_x * _x) + (_y * _y));
}