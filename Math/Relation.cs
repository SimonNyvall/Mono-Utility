namespace Math;
public class Relation
{
    public static double Normalization(double value, double min, double max)
    {
        return (value - min) / (max - min);
    }

    public static double Denormalization(double value, double min, double max)
    {
        return value * (max - min) + min;
    }

    
}
