using Src;

namespace Tests;

[TestFixture]
public class VectorImmutableTests
{
    [TestCase(new float[] { }, "()")]
    [TestCase(new float[] { 3 }, "(3)")]
    [TestCase(new float[] { 3, 4 }, "(3,4)")]
    [TestCase(new float[] { 3, 4, 5 }, "(3,4,5)")]
    [TestCase(new float[] { 3, 4, 5, 6 }, "(3,4,5,6)")]
    public void Create_01_Ok(float[] positions, string expectedResult)
    {
        // Act
        var vector = new VectorImmutable(positions);

        // Assert
        Assert.That(vector.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { }, new float[] { }, "()")]
    [TestCase(new float[] { 3 }, new float[] { 3 }, "(6)")]
    [TestCase(new float[] { 3, 4 }, new float[] { 1, 2 }, "(4,6)")]
    [TestCase(new float[] { 3, 4, 5 }, new float[] { 1, 2, 3 }, "(4,6,8)")]
    [TestCase(new float[] { 3, 4, 5, 6 }, new float[] { 1, 2, 3, 4 }, "(4,6,8,10)")]
    public void AddVectorToVector_01_Ok(float[] leftPositions, float[] rightPositions, string expectedResult)
    {
        // Arrange
        var left = new VectorImmutable(leftPositions);
        var right = new VectorImmutable(rightPositions);

        // Act
        var result = left + right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { }, new float[] { 1 })]
    [TestCase(new float[] { 1 }, new float[] { })]
    [TestCase(new float[] { 1, 2 }, new float[] { 1 })]
    [TestCase(new float[] { 1, 2 }, new float[] { 1, 3, 5 })]
    public void AddVectorToVector_02_ThrowsExceptionOnNotEqualVectorLengths(float[] leftPositions, float[] rightPositions)
    {
        // Arrange
        var left = new VectorImmutable(leftPositions);
        var right = new VectorImmutable(rightPositions);

        // Act && assert
        Assert.Throws<VectorsAreNotEqualException>(() =>
        {
            var result = left + right;
        });
    }

    [TestCase(new float[] { }, 1, "()")]
    [TestCase(new float[] { 3 }, 3, "(6)")]
    [TestCase(new float[] { 3, 4 }, 2, "(5,6)")]
    [TestCase(new float[] { 3, 4, 5 }, 4, "(7,8,9)")]
    [TestCase(new float[] { 3, 4, 5, 6 }, 5, "(8,9,10,11)")]
    public void AddVectorToValue_01_Ok(float[] positions, float additionValue, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(positions);

        // Act
        var result = vector + additionValue;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { }, 1, "()")]
    [TestCase(new float[] { 3 }, 3, "(6)")]
    [TestCase(new float[] { 3, 4 }, 2, "(5,6)")]
    [TestCase(new float[] { 3, 4, 5 }, 4, "(7,8,9)")]
    [TestCase(new float[] { 3, 4, 5, 6 }, 5, "(8,9,10,11)")]
    public void AddValueToVector_01_Ok(float[] positions, float additionValue, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(positions);

        // Act
        var result = additionValue + vector;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { }, new float[] { }, "()")]
    [TestCase(new float[] { 7 }, new float[] { 3 }, "(4)")]
    [TestCase(new float[] { 4, 7 }, new float[] { 1, 2 }, "(3,5)")]
    [TestCase(new float[] { 4, 7, 9 }, new float[] { 1, 2, 3 }, "(3,5,6)")]
    [TestCase(new float[] { 4, 7, 9, 15 }, new float[] { 1, 2, 3, 10 }, "(3,5,6,5)")]
    public void SubtractVectorOfVector_01_Ok(float[] leftPositions, float[] rightPositions, string expectedResult)
    {
        // Arrange
        var left = new VectorImmutable(leftPositions);
        var right = new VectorImmutable(rightPositions);

        // Act
        var result = left - right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { }, new float[] { 1 })]
    [TestCase(new float[] { 1 }, new float[] { })]
    [TestCase(new float[] { 1, 2 }, new float[] { 1 })]
    [TestCase(new float[] { 1, 2 }, new float[] { 1, 3, 5 })]
    public void SubtractVectorOfVector_02_ThrowsExceptionOnNotEqualVectorLengths(float[] leftPositions, float[] rightPositions)
    {
        // Arrange
        var left = new VectorImmutable(leftPositions);
        var right = new VectorImmutable(rightPositions);

        // Act && assert
        Assert.Throws<VectorsAreNotEqualException>(() =>
        {
            var result = left - right;
        });
    }

    [TestCase(new float[] { }, 1, "()")]
    [TestCase(new float[] { 3 }, 3, "(0)")]
    [TestCase(new float[] { 3, 4 }, 2, "(1,2)")]
    [TestCase(new float[] { 3, 4, 5 }, 4, "(-1,0,1)")]
    [TestCase(new float[] { 3, 4, 5, 6 }, 5, "(-2,-1,0,1)")]
    public void SubtractVectorOfValue_01_Ok(float[] positions, float subtractionValue, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(positions);

        // Act
        var result = vector - subtractionValue;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { }, 1, "()")]
    [TestCase(new float[] { 3 }, 3, "(0)")]
    [TestCase(new float[] { 3, 4 }, 2, "(1,2)")]
    [TestCase(new float[] { 3, 4, 5 }, 4, "(-1,0,1)")]
    [TestCase(new float[] { 3, 4, 5, 6 }, 5, "(-2,-1,0,1)")]
    public void SubtractValueOfVector_01_Ok(float[] positions, float subtractionValue, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(positions);

        // Act
        var result = subtractionValue - vector;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { }, new float[] { }, "()")]
    [TestCase(new float[] { 7 }, new float[] { 3 }, "(21)")]
    [TestCase(new float[] { 4, 7 }, new float[] { 1, 2 }, "(4,14)")]
    [TestCase(new float[] { 4, 7, 3 }, new float[] { 1, 2, 3 }, "(4,14,9)")]
    [TestCase(new float[] { 4, 7, 3, 2 }, new float[] { 1, 2, 3, 4 }, "(4,14,9,8)")]
    public void MultiplyVectorWithVector_01_Ok(float[] leftPositions, float[] rightPositions, string expectedResult)
    {
        // Arrange
        var left = new VectorImmutable(leftPositions);
        var right = new VectorImmutable(rightPositions);

        // Act
        var result = left * right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { }, new float[] { 1 })]
    [TestCase(new float[] { 1 }, new float[] { })]
    [TestCase(new float[] { 1, 2 }, new float[] { 1 })]
    [TestCase(new float[] { 1, 2 }, new float[] { 1, 3, 5 })]
    public void MultiplyVectorWithVector_02_ThrowsExceptionOnNotEqualVectorLengths(float[] leftPositions, float[] rightPositions)
    {
        // Arrange
        var left = new VectorImmutable(leftPositions);
        var right = new VectorImmutable(rightPositions);

        // Act && assert
        Assert.Throws<VectorsAreNotEqualException>(() =>
        {
            var result = left * right;
        });
    }

    [TestCase(new float[] { }, 2, "()")]
    [TestCase(new float[] { 1 }, 2, "(2)")]
    [TestCase(new float[] { 3, 4 }, 2, "(6,8)")]
    [TestCase(new float[] { 3, 4, 5 }, 2, "(6,8,10)")]
    [TestCase(new float[] { 3, 4, 5, 6 }, 2, "(6,8,10,12)")]
    public void MultiplyVectorWithValue_01_Ok(float[] positions, float multiply, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(positions);

        // Act
        var result = vector * multiply;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { }, 2, "()")]
    [TestCase(new float[] { 1 }, 2, "(2)")]
    [TestCase(new float[] { 3, 4 }, 2, "(6,8)")]
    [TestCase(new float[] { 3, 4, 5 }, 2, "(6,8,10)")]
    [TestCase(new float[] { 3, 4, 5, 6 }, 2, "(6,8,10,12)")]
    public void MultiplyValueWithVector_01_Ok(float[] positions, float multiply, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(positions);

        // Act
        var result = multiply * vector;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { }, new float[] { }, "()")]
    [TestCase(new float[] { 0 }, new float[] { 0 }, "(0)")]
    [TestCase(new float[] { 6 }, new float[] { 3 }, "(2)")]
    [TestCase(new float[] { 0, 0 }, new float[] { 0, 0 }, "(0,0)")]
    [TestCase(new float[] { 8, 0 }, new float[] { 0, 0 }, "(0,0)")]
    [TestCase(new float[] { 6, 4 }, new float[] { 3, 2 }, "(2,2)")]
    [TestCase(new float[] { 6, 4, 6 }, new float[] { 3, 2, 3 }, "(2,2,2)")]
    [TestCase(new float[] { 6, 4, 6, 7 }, new float[] { 3, 2, 4, 5 }, "(2,2,1.5,1.4)")]
    public void DivideVectorByVector_01_Ok(float[] leftPositions, float[] rightPositions, string expectedResult)
    {
        // Arrange
        var left = new VectorImmutable(leftPositions);
        var right = new VectorImmutable(rightPositions);

        // Act
        var result = left / right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [Test]
    public void DivideVectorByVector_01_ThrowsOnVectorsNotEqual()
    {
        // Arrange
        var left = new VectorImmutable(new float[] { 1, 2 });
        var right = new VectorImmutable(new float[] { 1 });

        // Act & assert
        Assert.Throws<VectorsAreNotEqualException>(() =>
        {
            var result = left / right;
        });
    }

    [TestCase(new float[] { }, 2, "()")]
    [TestCase(new float[] { 6 }, 2, "(3)")]
    [TestCase(new float[] { 6, 4 }, 2, "(3,2)")]
    [TestCase(new float[] { 6, 4, 8 }, 2, "(3,2,4)")]
    [TestCase(new float[] { 6, 4, 8, 10 }, 2, "(3,2,4,5)")]
    public void DivideVectorByValue_01_Ok(float[] positions, float divider, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(positions);

        // Act
        var result = vector / divider;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { })]
    [TestCase(new float[] { 0, 4 })]
    [TestCase(new float[] { 0, 0 })]
    [TestCase(new float[] { 4, 0 })]
    [TestCase(new float[] { 6, 4 })]
    public void DivideVectorByValue_02_ThrowsExceptionOnDivisionByZero(float[] positions)
    {
        // Arrange
        var vector = new VectorImmutable(positions);

        // Act && assert
        Assert.Throws<ArithmeticException>(() =>
        {
            var result = vector / 0;
        });
    }

    [TestCase(new float[] { }, 2, "()")]
    [TestCase(new float[] { 6 }, 2, "(0.33)")]
    [TestCase(new float[] { 6, 4 }, 2, "(0.33,0.5)")]
    [TestCase(new float[] { 6, 4, 8 }, 2, "(0.33,0.5,0.25)")]
    [TestCase(new float[] { 6, 4, 8, 10 }, 2, "(0.33,0.5,0.25,0.2)")]
    public void DivideValueByVector_01_Ok(float[] positions, float divider, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(positions);

        // Act
        var result = divider / vector;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { })]
    [TestCase(new float[] { 0, 4 })]
    [TestCase(new float[] { 0, 0 })]
    [TestCase(new float[] { 4, 0 })]
    [TestCase(new float[] { 6, 4 })]
    public void DivideValueByVector_02_ThrowsExceptionOnDivisionByZero(float[] positions)
    {
        // Arrange
        var vector = new VectorImmutable(positions);

        // Act && assert
        Assert.Throws<ArithmeticException>(() =>
        {
            var result = 0 / vector;
        });
    }
}
