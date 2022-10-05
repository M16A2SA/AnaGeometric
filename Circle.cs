namespace AnaGeometric;
public enum CircleType
{
    Standard,
    General
}
public class Circle
{
    public Circle(double param1 = 0, double param2 = 0, double param3 = 1, CircleType t = CircleType.Standard)
    {
        if (t == CircleType.Standard)
        {
            if(param3 <= 0)
            {
                throw new System.ArgumentException("The radius can't be 0 or smaller than 0", nameof(param3));
            }
            a = param1;
            b = param2;
            r = param3;
            D = -2 * a;
            E = -2 * b;
            F = a * a + b * b - r * r;
            CType = t;
            return;
        }
        else if (t == CircleType.General)
        {
            D = param1;
            E = param2;
            F = param3;
            if (D * D + E * E - 4 * F <= 0)
            {
                throw new System.Exception("Radius is smaller than 0 or equals to 0");
            }
            a = -D / 2;
            b = -E / 2;
            r = System.Math.Sqrt(D * D + E * E - 4 * F) / 2;
            CType = t;
        }
    }
    public double GetRadius() => r;
    public Point GetCenter() => new Point(a, b);
    public override string ToString()
    {
        if(CType == CircleType.Standard) 
            return $"(x{-a})^2 + (y{-b})^2 = {r * r}";
        else if(CType == CircleType.General)
        {

            return $"x^2 + y^2";
        }
        return string.Empty;
    }

    public double GetParam(char ch)
    {
        return ch switch
        {
            'a' => a,
            'b' => b,
            'r' => r,
            'D' => D,
            'E' => E,
            'F' => F,
            _ => double.NaN,
        };
    }
    private double a, b, r, D, E, F;
    private CircleType CType;
}
