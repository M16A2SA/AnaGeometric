namespace AnaGeometric;
public enum LineType
{
    General = 0,
    Point_Oblique = 1,
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
        if(a == 0 && b == 0)
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
    public Line() : this(1, -1, 0, LineType.General)
    {

    }
    /// <summary>
    /// Gets the maximum and minimum distance between this instance and the specified circle
    /// </summary>
    /// <param name="C1"></param>
    /// <returns>A double array, with the first element represents the minimum distance, and 
    /// the second element represents the maximum distance. If the line intersects with the 
    /// circle then the first element will be NaN</returns>
    public double[] GetDistanceFromCircle(Circle C1)
    {
        double[] result = { 0, 0 };

        Point CC1 = C1.GetCenter();
        double radius = C1.GetRadius();
        double dist = CC1.GetDistanceFromLine(this);
        if(dist - radius < 0)
        {
            result[0] = double.NaN;
            return result;
        } else
        {
            result[0] = dist - radius;
            result[1] = dist + radius;
        }
        return result;
    }
    public Line Convert(LineType t)
    {
        LType = t;
        switch(t)
        {
            case LineType.Slope_Intercept:
                k = -A / B;
                b = -C / B;
                return new Line(k, b);
            case LineType.General:
                A = k;
                B = -1;
                C = b;
                return new Line(A, B, C);
            case LineType.Point_Oblique:
                break;
            default:
                break;
        }// 点斜式应使用在x轴上的点，在y轴上的点可以通过斜截式得到
         //TODO Waiting for implementation...
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
         _  => double.NaN,
    };
    public Point GetIntersectionPoint(Line l2)
    {
        double A2 = l2.GetParam('A');
        double B2 = l2.GetParam('B');
        if(A * B2 == A2 * B) throw new System.Exception("The lines do not intersect.");
        double C2 = l2.GetParam('C');

        // double x = (A2 * B * C - A * B * C2) / (A * A * B2 - A * B);
        // double y = (A2 * C - A * C2) / (A * B2 - B);
        double x = -(B2 * C - B * C2) / (B2 * A - B * A2);
        double y = -(A * C2 - C * A2) / (B2 * A - B * A2);
        return new Point(x, y);
    }
    override public string ToString()
    {
        switch(LType)
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
        }
        return string.Empty;
    }

    private LineType LType;
    private double A;
    private double B;
    private double C;

    private double k;
    private double b;
}
