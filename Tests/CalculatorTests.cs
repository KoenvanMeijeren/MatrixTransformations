using Src;

namespace Tests;

public class CalculatorTests
{
    [TestCase(0.0d, 0)]
    [TestCase(0.78539816339744828d, 45)]
    [TestCase(1.5707963267948966d, 90)]
    [TestCase(3.1415926535897931d, 180)]
    [TestCase(6.2831853071795862d, 360)]
    public void ConvertToDegree_01_Ok(double radians, double expected)
    {
        // Act & Assert
        Assert.That(Calculator.ConvertToDegree(radians), Is.EqualTo(expected));
    }
    
    [TestCase(0, 0.0d)]
    [TestCase(45, 0.78539816339744828d)]
    [TestCase(90, 1.5707963267948966d)]
    [TestCase(180, 3.1415926535897931d)]
    [TestCase(360, 6.2831853071795862d)]
    public void ConvertToRadians_01_Ok(float degrees, double expected)
    {
        // Act & Assert
        Assert.That(Calculator.ConvertToRadians(degrees), Is.EqualTo(expected));
    }
}
