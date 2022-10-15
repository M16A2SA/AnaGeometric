namespace AnaGeometric;
public enum CircleType
{
    Standard,
    General
}
/// <summary>
/// Represents a circle in the rectangular coordinate system.
/// </summary>
public class Circle
{
    /// <summary>
    /// Constructor for both standard form and general form. 
    /// Make sure you don't mess everything up when giving parameters.
    /// </summary>
    /// <param name="param1">a, the horizontal coordinate for the center; 
    /// or D, the parameter for linear item x.</param>
    /// <param name="param2">b, the vertical coordinate for the center; 
    /// or E, the parameter for linear item y.</param>
    /// <param name="param3">r, the radius for the circle; 
    /// or F, the absolute item.</param>
    /// <param name="t">the type of the circle, set to standard form if not set explicitly,
    /// determines how the previous params will be interpreted.</param>
    /// <exception cref="System.ArgumentException"></exception>
    /// <exception cref="System.ArithmeticException"></exception>
    public Circle(double param1 = 0, double param2 = 0, double param3 = 1, CircleType t = CircleType.Standard)
    {
        if (t == CircleType.Standard)
        {
            if(param3 <= 0)
            {
                throw new System.ArgumentException("Radius is smaller than 0 or equals to 0", nameof(param3));
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
                throw new System.ArithmeticException("Radius is smaller than 0 or equals to 0");
            }
            a = -D / 2;
            b = -E / 2;
            r = System.Math.Sqrt(D * D + E * E - 4 * F) / 2;
            CType = t;
        }
    }
    public Point[] GetIntersectionPoint(Circle c)
    {
        double x1 = a, y1 = b;
        double x2 = c.a, y2 = c.b;
        double r1 = r, r2 = c.r;
        double R = System.Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        if(R == r1 + r2)
        {

        }else if(R > r1 + r2)
        {
            throw new System.ArithmeticException("The circles do not intersect");
        }
        double res_x1 = (x1 + x2) / 2 + (r1 * r1 - r2 * r2) / (2 * R * R) * (x2 - x1) +
            System.Math.Sqrt(2 * (r1 * r1 + r2 * r2) / R * R - (r1 * r1 - r2 * r2) * (r1 * r1 - r2 * r2) / R * R * R * R - 1) / 2 * (y2 - y1);
        double res_x2 = (x1 + x2) / 2 + (r1 * r1 - r2 * r2) / (2 * R * R) * (x2 - x1) -
            System.Math.Sqrt(2 * (r1 * r1 + r2 * r2) / R * R - (r1 * r1 - r2 * r2) * (r1 * r1 - r2 * r2) / R * R * R * R - 1) / 2 * (y2 - y1);
        double res_y1 = (y1 + y2) / 2 + (r1 * r1 - r2 * r2) / (2 * R * R) * (y2 - y1) +
            System.Math.Sqrt(2 * (r1 * r1 + r2 * r2) / R * R - (r1 * r1 - r2 * r2) * (r1 * r1 - r2 * r2) / R * R * R * R - 1) / 2 * (x1 - x2);
        double res_y2 = (y1 + y2) / 2 + (r1 * r1 - r2 * r2) / (2 * R * R) * (y2 - y1) -
            System.Math.Sqrt(2 * (r1 * r1 + r2 * r2) / R * R - (r1 * r1 - r2 * r2) * (r1 * r1 - r2 * r2) / R * R * R * R - 1) / 2 * (x1 - x2);
        Point[] res = { new(res_x1, res_y1), new (res_x2, res_y2)};
        return res;
    }
    public override string ToString()
    {
        if(CType == CircleType.Standard) 
            return $"(x{-a})^2 + (y{-b})^2 = {r * r}";
        else if(CType == CircleType.General)
            return $"x^2 + y^2 + {D}x + {E}y + {F} = 0";
        return string.Empty;
    }

    public double GetParam(char ch) => ch switch
    {
        'a' => a,
        'b' => b,
        'r' => r,
        'D' => D,
        'E' => E,
        'F' => F,
         _  => double.NaN,
    };
    public double Radius => r;
    public Point Center => new(a, b);
    private double a, b, r, D, E, F;
    private CircleType CType;
}
