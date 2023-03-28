namespace Math;
public class Relation
{
    // Takes two points and returns the percentage of the diffrance between them.
    public static double Normalization(double value, double min, double max)
    {
        return (value - min) / (max - min);
    }

    // denormalization is the process of trying to improve the read performance of a database, 
    //at the expense of losing some write performance, 
    //by adding redundant copies of data or by grouping data.
    public static double Denormalization(double value, double min, double max)
    {
        return value * (max - min) + min;
    }

    // Takes a value between 0 and 1 and return the new parameter set bu the user.
    //Can be used for sliders.
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
