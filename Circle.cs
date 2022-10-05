namespace AnaGeometric;
public enum CircleType
{
    Standard,
    General
}
public class Circle
{
    public Circle(double param1 = 0, double param2 = 0, double param3 = 1, CircleType CType = CircleType.Standard)
    {
        if (param3 <= 0)
        {
            throw new System.ArgumentException("The radius can't be 0 or smaller than 0", "R");
        }
        if (CType == CircleType.Standard)
        {
            a = param1;
            b = param2;
            r = param3;
            D = -2 * a;
            E = -2 * b;
            F = a * a + b * b - r * r;
            this.CType = CType;
            return;
        }
        else if (CType == CircleType.General)
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
            this.CType = CType;
        }
    }
    public double GetRadius() => r;
    public Point GetCenter() => new Point(a, b);
    public override string ToString() => $"(x{-a})^2 + (y{-b})^2 = {r * r}";
    public double GetParam(char ch)
    {
        switch (ch)
        {
            case 'a': return a;
            case 'b': return b;
            case 'r': return r;
            default: return double.NaN;
        }
    }
    private double a, b, r, D, E, F;
    private CircleType CType;
}
