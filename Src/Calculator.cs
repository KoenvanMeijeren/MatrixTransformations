namespace Src;

public static class Calculator
{
    public static double RadiansToDegree(double radians)
    {
        return (180 / Math.PI) * radians;
    }

    public static double DegreesToRadians(double degrees)
    {
        return (Math.PI / 180) * degrees;
    }
}
