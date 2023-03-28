namespace Math;
public class Relation
{
    // Takes two points and returns the percentage of the diffrance between them.
    public static double Normalization(double value, double min, double max)
    {
        return (value - min) / (max - min);
    }

    public static double Denormalization(double value, double min, double max)
    {
        return value * (max - min) + min;
    }

    public static double LinearInerpolation(double normalization, double min, double max)
    {
        return (max - min) * (normalization + min);
    }

    public static double Maping(double value, double sourceMin, double sourceMax, double destMin, double destMax)
    {
        double normalization = Normalization(value, sourceMin, sourceMax);
        return LinearInerpolation(normalization, destMin, destMax);
    }

    public static double Claping(double value, double min, double max)
    {
        return Math.Min(Math.Max(value, min), max);
    }
}
