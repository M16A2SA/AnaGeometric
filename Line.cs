namespace AnaGeometric;
public enum LineType
{
    General = 0,
    Point_Slope = 1,
    Slope_Intercept = 2,
}
/// <summary>
/// Represents a line in the rectangular coordinate system.
/// </summary>
public class Line
{
    /// <summary>
    /// Constructor for slope-intercept form
    /// </summary>
    /// <param name="K"></param>
    /// <param name="B"></param>
    public Line(double K, double B)
    {
        k = K;
        b = B;
        A = k;
        this.B = -1;
        C = b;
        LType = LineType.Slope_Intercept;
    }
    /// <summary>
    /// Constructor for general form
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="t"></param>
    public Line(double a, double b, double c, LineType t = LineType.General)
    {
        if (a == 0 && b == 0)
        {
            throw new System.ArgumentException("A and B can't both be 0");
        }
        A = a;
        B = b;
        C = c;

        k = -A / B;
        this.b = -C / B;
        LType = t;
    }
    public Line() : this(1, -1, 0, LineType.General) { }
    /// <summary>
    /// Gets the maximum and minimum distance between this instance and the specified circle
    /// </summary>
    /// <param name="C1">The circle</param>
    /// <returns>A double array, with the first element represents the minimum distance, and 
    /// the second element represents the maximum distance. If the line intersects with the 
    /// circle then the first element will be NaN</returns>
    public double[] GetDistanceFromCircle(Circle C1)
    {
        double[] result = { 0, 0 };

        Point CC1 = C1.Center;
        double radius = C1.Radius;
        double dist = CC1.GetDistanceFromLine(this);
        if (dist - radius < 0)
        {
            result[0] = double.NaN;
            return result;
        }
        else
        {
            result[0] = dist - radius;
            result[1] = dist + radius;
        }
        return result;
    }
    /// <summary>
    /// Converts this instance to the specified type.
    /// When converting to point slope type the point is the intersection
    /// point of the line and the x-axis. Or if it doesn't exist it's the point
    /// with the y-axis
    /// </summary>
    /// <param name="t"></param>
    /// <returns>The converted line.</returns>
    /// <exception cref="System.ArithmeticException">When switching to slope-intercept form and
    /// k doesn't exist.</exception>
    public Line Convert(LineType t)
    {
        LType = t;
        switch (t)
        {
            case LineType.Slope_Intercept:
                if (B == 0) throw new System.ArithmeticException("k for this line doesn't exist");
                k = -A / B;
                b = -C / B;
                return new Line(k, b);
            case LineType.General:
                A = k;
                B = -1;
                C = b;
                return new Line(A, B, C);
            case LineType.Point_Slope:
                if (A == 0)
                {
                    _y = -C / B;
                    _x = 0;
                }
                else
                {
                    _x = -C / A;
                    _y = 0;
                }
                return this;
            default:
                break;
        }
        return new Line();
    }
    /// <summary>
    /// Get parameters of the line
    /// </summary>
    /// <param name="ch">A, B or C in General form or k, b in slope-intercept form</param>
    /// <returns>The specified parameter</returns>
    public double GetParam(char ch) => ch switch
    {
        'A' => A,
        'B' => B,
        'C' => C,
        'k' => k,
        'b' => b,
        _ => double.NaN,
    };
    public Point GetIntersectionPoint(Line l2)
    {
        double A2 = l2.GetParam('A');
        double B2 = l2.GetParam('B');
        if (A * B2 == A2 * B) throw new System.Exception("The lines do not intersect.");
        double C2 = l2.GetParam('C');

        // double x = (A2 * B * C - A * B * C2) / (A * A * B2 - A * B);
        // double y = (A2 * C - A * C2) / (A * B2 - B);
        double x = -(B2 * C - B * C2) / (B2 * A - B * A2);
        double y = -(C2 * A - C * A2) / (B2 * A - B * A2);
        return new Point(x, y);
    }
    override public string ToString()
    {
        switch (LType)
        {
            case LineType.General:
                string pA = A == 0 ? "" : (A == 1 ? "x" : (A == -1 ? "-x" : $"{A}x"));
                string pB = B == 0 ? "" : (B == 1 ? "+y" : (B == -1 ? "-y" : B < 0 ? $"{B}y" : $"+{B}y"));
                string pC = C == 0 ? "" : (C > 0 ? $"+{C}" : $"{C}");
                return $"{pA}{pB}{pC}=0";
            case LineType.Slope_Intercept:
                string pk = k == 0 ? "" : (k == 1 ? "x" : (k == -1 ? "-x" : $"{k}x"));
                string pb = b == 0 ? "" : (b < 0 ? $"{b}" : $"+{b}");
                return $"y = {pk}{pb}";
            case LineType.Point_Slope:
                pk = k == 0 ? "" : (k == 1 ? "" : (k == -1 ? "-" : $"{k}"));
                string px = _x == 0 ? "x" : (_x < 0 ? $"(x{_x})" : $"(x+{_x})");
                string py = _y == 0 ? "y" : (_y < 0 ? $"(y{_y})" : $"(y+{_y})");
                return $"{py}={pk}{px}"; //FIXME
        }
        return string.Empty;
    }

    private LineType LType;
    private double A;
    private double B;
    private double C;

    private double _x;
    private double _y;

    private double k;
    private double b;
}
