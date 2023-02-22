using System.Globalization;

namespace Src;

public class VectorImmutable2D
{
    public double XPosition { get; private init; }
    public double YPosition { get; private init; }

    public VectorImmutable2D() : this(0, 0)
    {

    }

    public VectorImmutable2D(double xPosition, double yPosition)
    {
        XPosition = xPosition;
        YPosition = yPosition;
    }

    public static VectorImmutable2D operator + (VectorImmutable2D left, VectorImmutable2D right)
    {
        return new VectorImmutable2D
        {
            XPosition = left.XPosition + right.XPosition,
            YPosition = left.YPosition + right.YPosition
        };
    }
    
    public static VectorImmutable2D operator - (VectorImmutable2D left, VectorImmutable2D right)
    {
        return new VectorImmutable2D
        {
            XPosition = left.XPosition - right.XPosition,
            YPosition = left.YPosition - right.YPosition
        };
    }
    
    public static VectorImmutable2D operator * (VectorImmutable2D input, float multiply)
    {
        return new VectorImmutable2D
        {
            XPosition = input.XPosition * multiply,
            YPosition = input.YPosition * multiply
        };
    }
    
    public static VectorImmutable2D operator * (float multiply, VectorImmutable2D input)
    {
        return new VectorImmutable2D
        {
            XPosition = input.XPosition * multiply,
            YPosition = input.YPosition * multiply
        };
    }

    public static VectorImmutable2D operator / (VectorImmutable2D input, float divider)
    {
        if (divider == 0 || divider == 0.0)
        {
            throw new ArithmeticException("Cannot divide vector by zero!");
        }
        
        return new VectorImmutable2D
        {
            XPosition = input.XPosition / divider,
            YPosition = input.YPosition / divider
        };
    }
    
    public static VectorImmutable2D operator / (float divider, VectorImmutable2D input)
    {
        if (divider == 0 || divider == 0.0)
        {
            throw new ArithmeticException("Cannot divide vector by zero!");
        }
        
        return new VectorImmutable2D
        {
            XPosition = input.XPosition / divider,
            YPosition = input.YPosition / divider
        };
    }

    public override string ToString()
    {
        return $"({Math.Round(XPosition, 2).ToString(CultureInfo.InvariantCulture)},{Math.Round(YPosition, 2).ToString(CultureInfo.InvariantCulture)})";
    }
}