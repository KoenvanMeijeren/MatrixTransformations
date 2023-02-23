namespace Src;

public static class Calculator
{
    public static double ConvertToDegree(double radians)
    {
        return (180 / Math.PI) * radians;
    }

    public static double ConvertToRadians(double degrees)
    {
        return (Math.PI / 180) * degrees;
    }
}
