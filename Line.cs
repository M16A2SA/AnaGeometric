namespace AnaGeometric;
public enum LineType
{
    General = 0,
    Point_Oblique = 1,
    Slope_Intercept = 2,
}
public class Line
{
    /// <summary>
    /// Constructor for slope-intercept form
    /// </summary>
    /// <param name="K"></param>
    /// <param name="B"></param>
    public Line(double K, double B)
    {
        this.k = K;
        this.b = B;
        this.A = k;
        this.B = -1;
        this.C = b;
        LType = LineType.Slope_Intercept;
    }
    /// <summary>
    /// Constructor for general form
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="t"></param>
    public Line(double a = 1, double b = 1, double c = 1, LineType t = LineType.General)
    {
        if (a == 0 && b == 0)
        {
            throw new System.ArgumentException("A and B can't both be 0");
        }
        this.A = a;
        this.B = b;
        this.C = c;

        this.k = -this.A / this.B;
        this.b = -this.C / this.B;
        LType = t;
    }
    /// <summary>
    /// Gets the maximum and minimum distance between this instance and the specified circle
    /// </summary>
    /// <param name="C1"></param>
    /// <returns>A double array, with the first element represents the minimum distance, and 
    /// the second element represents the maximum distance.</returns>
    public double[] GetDistanceFromCircle(Circle C1)
    {
        double[] result = { 0, 0 };

        Point CC1 = C1.GetCenter();
        double radius = C1.GetRadius();
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
    public Line Convert(LineType t)
    {
        LType = t;
        switch (t)
        {
            case LineType.Point_Oblique:
                k = -A / B;
                b = -C / B;
                return new Line(k, b);
            case LineType.General:
                A = k;
                B = -1;
                C = b;
                return new Line(A, B, C);
        }
        return new Line();
    }
    /// <summary>
    /// Get parameters of the line
    /// </summary>
    /// <param name="ch">A, B or C in General form or k, b in slope-intercept form</param>
    /// <returns>The specified parameter</returns>
    public double GetParam(char ch)
    {
        switch (ch)
        {
            case 'A': return A;
            case 'B': return B;
            case 'C': return C;
            case 'k': return k;
            case 'b': return b;
            default: return double.NaN;
        }
    }
    public Point GetIntersectionPoint(Line l2)
    {
        double A2 = l2.GetParam('A');
        double B2 = l2.GetParam('B');
        if (A * B2 == A2 * B) throw new System.Exception("The lines do not intersect.");
        double C2 = l2.GetParam('C');

        // double x = (A2 * B * C - A * B * C2) / (A * A * B2 - A * B);
        // double y = (A2 * C - A * C2) / (A * B2 - B);
        double x = -(B2 * C - B * C2) / (B2 * A - B * A2);
        double y = -(A * C2 - C * A2) / (B2 * A - B * A2);
        return new Point(x, y);
    }
    override public string ToString()
    {
        switch (LType)
        {
            case LineType.General:
                string pA = A == 0 ? "" : (A == 1 ? "x" : (A == -1 ? "-x" : $"{A}x"));
                string pB = B == 0 ? "" : (B == 1 ? "+ y" : (B == -1 ? "- y" : $"+ {B}y"));
                string pC = C == 0 ? "" : (C > 0 ? $"+ {C}" : $"{C}");
                return $"{pA} {pB} {pC} = 0";
            case LineType.Slope_Intercept:
                return $"y = {k}x - {b}";
        }
        return System.String.Empty;
    }

    private LineType LType;
    private double A;
    private double B;
    private double C;

    private double k;
    private double b;
}