using Src;

namespace Tests;

public class MatrixImmutableTests
{
    [Test]
    public void Create_01_0D_Ok()
    {
        // Act
        var result = new MatrixImmutable();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.IsEmpty(), Is.True);
            Assert.That(result.Length(), Is.EqualTo(0));
            Assert.That(result.ToString(), Is.EqualTo("{}"));
        });
    }

    [Test]
    public void Create_02_1D_Ok()
    {
        // Act
        var vector1 = new VectorImmutable(3);
        var vector2 = new VectorImmutable(1);
        var result = new MatrixImmutable(vector1, vector2);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.IsEmpty(), Is.False);
            Assert.That(result.Length(), Is.EqualTo(2));
            Assert.That(result.ToString(), Is.EqualTo("{(3),(1)}"));
        });
    }

    [Test]
    public void Create_02_2D_Ok()
    {
        // Act
        var vector1 = new VectorImmutable(3, 4);
        var vector2 = new VectorImmutable(1, 6);
        var result = new MatrixImmutable(vector1, vector2);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.IsEmpty(), Is.False);
            Assert.That(result.Length(), Is.EqualTo(2));
            Assert.That(result.ToString(), Is.EqualTo("{(3,4),(1,6)}"));
        });
    }

    [Test]
    public void Create_03_3D_Ok()
    {
        // Act
        var vector1 = new VectorImmutable(3, 2, 4);
        var vector2 = new VectorImmutable(1, 0, 4);
        var vector3 = new VectorImmutable(1, 3, 4);
        var result = new MatrixImmutable(vector1, vector2, vector3);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.IsEmpty(), Is.False);
            Assert.That(result.Length(), Is.EqualTo(3));
            Assert.That(result.ToString(), Is.EqualTo("{(3,2,4),(1,0,4),(1,3,4)}"));
        });
    }

    [Test]
    public void ToVector_01_0D_Ok()
    {
        // Arrange
        var matrix = new MatrixImmutable();

        // Act
        var result = MatrixImmutable.ToVector(matrix, 0);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("()"));
    }

    [Test]
    public void ToVector_02_1D_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(3);
        var vector2 = new VectorImmutable(1);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act
        var result = MatrixImmutable.ToVector(matrix, 0);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("(3,1)"));
    }

    [Test]
    public void ToVector_03_1D_ThrowsExceptionOnColumnOutOfBounds()
    {
        // Arrange
        var vector1 = new VectorImmutable(3);
        var vector2 = new VectorImmutable(1);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act && assert
        Assert.Throws<MatrixIndexOutOfBoundsException>(() => MatrixImmutable.ToVector(matrix, 1));
    }

    [Test]
    public void ToVector_04_2D_FirstColumnOk()
    {
        // Arrange
        var vector1 = new VectorImmutable(3, 2);
        var vector2 = new VectorImmutable(1, 0);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act
        var result = MatrixImmutable.ToVector(matrix, 0);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("(3,1)"));
    }

    [Test]
    public void ToVector_05_2D_SecondColumnOk()
    {
        // Arrange
        var vector1 = new VectorImmutable(3, 2);
        var vector2 = new VectorImmutable(1, 0);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act
        var result = MatrixImmutable.ToVector(matrix, 1);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("(2,0)"));
    }

    [Test]
    public void ToVector_06_2D_ThrowsExceptionOnColumnOutOfBounds()
    {
        // Arrange
        var vector1 = new VectorImmutable(3, 2);
        var vector2 = new VectorImmutable(1, 0);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act && assert
        Assert.Throws<MatrixIndexOutOfBoundsException>(() => MatrixImmutable.ToVector(matrix, 2));
    }

    [Test]
    public void ToVector_07_ThrowsExceptionOnDifferentDimensions()
    {
        // Arrange
        var vector1 = new VectorImmutable(3, 2);
        var vector2 = new VectorImmutable(1);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act && assert
        Assert.Throws<MatrixDifferentVectorsDimensionsException>(() => MatrixImmutable.ToVector(matrix, 0));
    }

    [Test]
    public void ToVector_08_ThrowsExceptionOnDifferentDimensions()
    {
        // Arrange
        var vector1 = new VectorImmutable(3);
        var vector2 = new VectorImmutable(1, 2);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act && assert
        Assert.Throws<MatrixDifferentVectorsDimensionsException>(() => MatrixImmutable.ToVector(matrix, 0));
    }

    [Test]
    public void Identity_01_0D_Ok()
    {
        // Arrange
        var matrix = new MatrixImmutable();

        // Act
        var result = MatrixImmutable.Identity(matrix);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{}"));
    }

    [Test]
    public void Identity_02_1D_Ok()
    {
        // Arrange
        var vector = new VectorImmutable(2);
        var matrix = new MatrixImmutable(vector);

        // Act
        var result = MatrixImmutable.Identity(matrix);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(1)}"));
    }

    [Test]
    public void Identity_03_1D_ThrowsOnDifferentVectorsDimensions()
    {
        // Arrange
        var vector1 = new VectorImmutable(2);
        var vector2 = new VectorImmutable();
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act && assert
        Assert.Throws<MatrixVectorsLengthNotEqualToVectorDimensionsException>(() => MatrixImmutable.Identity(matrix));
    }

    [Test]
    public void Identity_04_2D_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(2, 4);
        var vector2 = new VectorImmutable(-1, 3);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act
        var result = MatrixImmutable.Identity(matrix);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(1,0),(0,1)}"));
    }

    [Test]
    public void Identity_04_2D_ThrowsOnDifferentVectorDimensions()
    {
        // Arrange
        var vector1 = new VectorImmutable(2);
        var vector2 = new VectorImmutable(-1, 3);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act & assert
        Assert.Throws<MatrixVectorsLengthNotEqualToVectorDimensionsException>(() => MatrixImmutable.Identity(matrix));
    }

    [Test]
    public void Identity_05_3D_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(2, 4, 5);
        var vector2 = new VectorImmutable(-1, 3, 7);
        var vector3 = new VectorImmutable(1, 8, 6);
        var matrix = new MatrixImmutable(vector1, vector2, vector3);

        // Act
        var result = MatrixImmutable.Identity(matrix);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(1,0,0),(0,1,0),(0,0,1)}"));
    }

    [Test]
    public void Identity_06_3D_ThrowsOnDifferentVectorsDimensions()
    {
        // Arrange
        var vector1 = new VectorImmutable(2, 4, 5);
        var vector2 = new VectorImmutable(-1, 3, 7);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act && assert
        Assert.Throws<MatrixVectorsLengthNotEqualToVectorDimensionsException>(() => MatrixImmutable.Identity(matrix));
    }

    [Test]
    public void Identity_07_2x1D_ThrowsErrorsOnMatrixVectorsLengthNotEqualToVectorDimensions()
    {
        // Arrange
        var vector1 = new VectorImmutable(2);
        var vector2 = new VectorImmutable(2);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act & assert
        Assert.Throws<MatrixVectorsLengthNotEqualToVectorDimensionsException>(() => MatrixImmutable.Identity(matrix));
    }
    
    [TestCase(0, 0, "{}")]
    [TestCase(1, 1, "{(1)}")]
    [TestCase(2, 1, "{(1,0),(0,1)}")]
    [TestCase(2, 2, "{(2,0),(0,1)}")]
    [TestCase(3, 1, "{(1,0,0),(0,1,0),(0,0,1)}")]
    [TestCase(3, 2, "{(2,0,0),(0,2,0),(0,0,1)}")]
    [TestCase(4, 1, "{(1,0,0,0),(0,1,0,0),(0,0,1,0),(0,0,0,1)}")]
    [TestCase(4, 2, "{(2,0,0,0),(0,2,0,0),(0,0,2,0),(0,0,0,1)}")]
    public void Identity_08_BuildFromGivenMatrixSize_Ok(int matrixSize, int scale, string expectedResult)
    {
        // Arrange & Act
        var matrix = MatrixImmutable.Identity(matrixSize, scale);
        
        // Assert
        Assert.That(matrix.ToString(), Is.EqualTo(expectedResult));
    }

    [Test]
    public void Add_01_0D_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable();
        var vector2 = new VectorImmutable();
        var vector3 = new VectorImmutable();
        var vector4 = new VectorImmutable();
        var left = new MatrixImmutable(vector1, vector2);
        var right = new MatrixImmutable(vector3, vector4);

        // Act
        var result = left + right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{}"));
    }

    [Test]
    public void Add_02_1D_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(3);
        var vector2 = new VectorImmutable(1);
        var vector3 = new VectorImmutable(5);
        var vector4 = new VectorImmutable(2);
        var left = new MatrixImmutable(vector1, vector2);
        var right = new MatrixImmutable(vector3, vector4);

        // Act
        var result = left + right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(8),(3)}"));
    }

    [Test]
    public void Add_03_2D_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(3, 2);
        var vector2 = new VectorImmutable(1, 0);
        var vector3 = new VectorImmutable(2, -3);
        var vector4 = new VectorImmutable(2, -5);
        var left = new MatrixImmutable(vector1, vector2);
        var right = new MatrixImmutable(vector3, vector4);

        // Act
        var result = left + right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(5,-1),(3,-5)}"));
    }

    [Test]
    public void Add_04_3D_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(3, 2, 4);
        var vector2 = new VectorImmutable(1, 0, 5);
        var vector3 = new VectorImmutable(2, -3, 2);
        var vector4 = new VectorImmutable(2, -5, 0);
        var left = new MatrixImmutable(vector1, vector2);
        var right = new MatrixImmutable(vector3, vector4);

        // Act
        var result = left + right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(5,-1,6),(3,-5,5)}"));
    }

    [Test]
    public void Add_05_ThrowsOnDifferentMatricesLength()
    {
        // Arrange
        var vector1 = new VectorImmutable();
        var vector2 = new VectorImmutable();
        var vector3 = new VectorImmutable();
        var left = new MatrixImmutable(vector1, vector2);
        var right = new MatrixImmutable(vector3);

        // Act & assert
        Assert.Throws<MatrixVectorsLengthNotEqualException>(() =>
        {
            var result = left + right;
        });
    }

    [Test]
    public void Add_06_ThrowsOnDifferentVectorDimensions()
    {
        // Arrange
        var vector1 = new VectorImmutable(1, 2);
        var vector2 = new VectorImmutable(3, 4, 5);
        var left = new MatrixImmutable(vector1);
        var right = new MatrixImmutable(vector2);

        // Act & assert
        Assert.Throws<MatrixDifferentVectorsDimensionsException>(() =>
        {
            var result = left + right;
        });
    }

    [Test]
    public void Subtract_01_0D_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable();
        var vector2 = new VectorImmutable();
        var vector3 = new VectorImmutable();
        var vector4 = new VectorImmutable();
        var left = new MatrixImmutable(vector1, vector2);
        var right = new MatrixImmutable(vector3, vector4);

        // Act
        var result = left - right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{}"));
    }

    [Test]
    public void Subtract_02_1D_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(3);
        var vector2 = new VectorImmutable(1);
        var vector3 = new VectorImmutable(2);
        var vector4 = new VectorImmutable(2);
        var left = new MatrixImmutable(vector1, vector2);
        var right = new MatrixImmutable(vector3, vector4);

        // Act
        var result = left - right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(1),(-1)}"));
    }

    [Test]
    public void Subtract_03_2D_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(3, 2);
        var vector2 = new VectorImmutable(1, 0);
        var vector3 = new VectorImmutable(2, -3);
        var vector4 = new VectorImmutable(2, -5);
        var left = new MatrixImmutable(vector1, vector2);
        var right = new MatrixImmutable(vector3, vector4);

        // Act
        var result = left - right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(1,5),(-1,5)}"));
    }

    [Test]
    public void Subtract_04_3D_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(3, 2, 4);
        var vector2 = new VectorImmutable(1, 0, 2);
        var vector3 = new VectorImmutable(2, -3, 7);
        var vector4 = new VectorImmutable(2, -5, 1);
        var left = new MatrixImmutable(vector1, vector2);
        var right = new MatrixImmutable(vector3, vector4);

        // Act
        var result = left - right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(1,5,-3),(-1,5,1)}"));
    }

    [Test]
    public void Subtract_05_ThrowsOnDifferentMatricesLength()
    {
        // Arrange
        var vector1 = new VectorImmutable();
        var vector2 = new VectorImmutable();
        var vector3 = new VectorImmutable();
        var left = new MatrixImmutable(vector1, vector2);
        var right = new MatrixImmutable(vector3);

        // Act & assert
        Assert.Throws<MatrixVectorsLengthNotEqualException>(() =>
        {
            var result = left - right;
        });
    }

    [Test]
    public void Subtract_06_ThrowsOnDifferentVectorDimensions()
    {
        // Arrange
        var vector1 = new VectorImmutable(1, 2);
        var vector2 = new VectorImmutable(3, 4, 5);
        var left = new MatrixImmutable(vector1);
        var right = new MatrixImmutable(vector2);

        // Act & assert
        Assert.Throws<MatrixDifferentVectorsDimensionsException>(() =>
        {
            var result = left - right;
        });
    }

    [Test]
    public void MultiplyMatrixWithValue_01_0DVectors_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable();
        var vector2 = new VectorImmutable();
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act
        var result = matrix * 2;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{}"));
    }

    [Test]
    public void MultiplyMatrixWithValue_01_1DVectors_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(2);
        var vector2 = new VectorImmutable(-1);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act
        var result = matrix * 2;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(4),(-2)}"));
    }

    [Test]
    public void MultiplyMatrixWithValue_01_2DVectors_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(2, 4);
        var vector2 = new VectorImmutable(-1, 3);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act
        var result = matrix * 2;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(4,8),(-2,6)}"));
    }

    [Test]
    public void MultiplyValueWithMatrix_01_0DVectors_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable();
        var vector2 = new VectorImmutable();
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act
        var result = 2 * matrix;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{}"));
    }

    [Test]
    public void MultiplyValueWithMatrix_02_1DVectors_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(2);
        var vector2 = new VectorImmutable(-1);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act
        var result = 2 * matrix;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(4),(-2)}"));
    }

    [Test]
    public void MultiplyValueWithMatrix_03_2DVectors_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(2, 4);
        var vector2 = new VectorImmutable(-1, 3);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act
        var result = 2 * matrix;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(4,8),(-2,6)}"));
    }

    [Test]
    public void MultiplyMatrixWithMatrix_01_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(1, 2);
        var vector2 = new VectorImmutable(3, 4);
        var vector3 = new VectorImmutable(5, 6);
        var vector4 = new VectorImmutable(7, 8);
        var left = new MatrixImmutable(vector1, vector2);
        var right = new MatrixImmutable(vector3, vector4);

        // Act
        var result = left * right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(19,22),(43,50)}"));
    }

    [Test]
    public void MultiplyMatrixWithMatrix_02_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(2, 4);
        var vector2 = new VectorImmutable(-1, 3);
        var vector3 = new VectorImmutable(2, 4);
        var vector4 = new VectorImmutable(-1, 3);
        var left = new MatrixImmutable(vector1, vector2);
        var right = new MatrixImmutable(vector3, vector4);

        // Act
        var result = left * right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(0,20),(-5,5)}"));
    }

    [Test]
    public void MultiplyMatrixWithMatrix_03_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(1, 3);
        var vector2 = new VectorImmutable(2, 1);
        var right = new MatrixImmutable(vector1, vector2);
        var vector3 = new VectorImmutable(2, 4);
        var vector4 = new VectorImmutable(-1, 3);
        var left = new MatrixImmutable(vector3, vector4);

        // Act
        var result = left * right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(10,10),(5,0)}"));
    }

    [Test]
    public void MultiplyMatrixWithMatrix_04_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(1, 3);
        var vector2 = new VectorImmutable(2, 1);
        var left = new MatrixImmutable(vector1, vector2);
        var vector3 = new VectorImmutable(2, 4);
        var vector4 = new VectorImmutable(-1, 3);
        var right = new MatrixImmutable(vector3, vector4);

        // Act
        var result = left * right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(-1,13),(3,11)}"));
    }

    [Test]
    public void MultiplyMatrixWithMatrix_05_ThrowsOnLeftColumnsNotEqualToRightRows()
    {
        // Arrange
        var vector1 = new VectorImmutable(1, 3);
        var vector2 = new VectorImmutable(2, 1);
        var left = new MatrixImmutable(vector1, vector2);
        var vector3 = new VectorImmutable(2, 4);
        var right = new MatrixImmutable(vector3);

        // Act & assert
        Assert.Throws<MatrixLeftColumnsAreNotEqualToMatrixRightRowsException>(() =>
        {
            var result = left * right;
        });
    }

    [Test]
    public void MultiplyMatrixWithMatrix_06_2x2DWith2x3D_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(1, 8);
        var vector2 = new VectorImmutable(2, -3);
        var left = new MatrixImmutable(vector1, vector2);
        var vector3 = new VectorImmutable(2, 7, -2);
        var vector4 = new VectorImmutable(3, -1, 5);
        var right = new MatrixImmutable(vector3, vector4);

        // Act
        var result = left * right;

        Assert.That(result.ToString(), Is.EqualTo("{(26,-1,38),(-5,17,-19)}"));
    }

    [Test]
    public void MultiplyMatrixWithVector_01_Ok()
    {
        // Arrange
        var vector1 = new VectorImmutable(2, 4);
        var vector2 = new VectorImmutable(-1, 3);
        var matrix = new MatrixImmutable(vector1, vector2);
        var vector = new VectorImmutable(2, 6);

        // Act
        var result = matrix * vector;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("(28,16)"));
    }

    [Test]
    public void MultiplyVectorWithMatrix_01_Ok()
    {
        // Arrange
        var vector = new VectorImmutable(4, -1);
        var vector1 = new VectorImmutable(2, 4);
        var vector2 = new VectorImmutable(-1, 3);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act
        var result = vector * matrix;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(9,13)}"));
    }

    [TestCase(0, "{}")]
    [TestCase(1, "{(1)}")]
    [TestCase(2, "{(2,0),(0,2)}")]
    [TestCase(3, "{(3,0,0),(0,3,0),(0,0,1)}")]
    [TestCase(4, "{(4,0,0,0),(0,4,0,0),(0,0,4,0),(0,0,0,1)}")]
    public void ScalingMatrix_01_0D_Ok(float scale, string expectedResult)
    {
        // Arrange
        var vectorsLength = (int)scale;
        var vectors = new VectorImmutable[vectorsLength];
        for (var vectorIndex = 0; vectorIndex < vectorsLength; vectorIndex++)
        {
            var positions = new float[vectorsLength];
            for (var positionIndex = 0; positionIndex < positions.Length; positionIndex++)
            {
                positions[positionIndex] = (new Random()).Next();
            }

            vectors[vectorIndex] = new VectorImmutable(positions);
        }

        var matrix = new MatrixImmutable(vectors);

        // Act
        var result = MatrixImmutable.ScalingMatrix(matrix, scale);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { }, new float[] { }, 0, "{}")]
    [TestCase(new float[] { }, new float[] { }, 1, "{}")]
    [TestCase(new float[] { }, new float[] { }, 2, "{}")]
    public void ScaleMatrixByValue_01_0D_Ok(float[] leftPositions, float[] rightPositions, float scale, string expectedResult)
    {
        // Arrange
        var vector1 = new VectorImmutable(leftPositions);
        var vector2 = new VectorImmutable(rightPositions);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act
        var result = MatrixImmutable.Scale(matrix, scale);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { 3 }, 0, "{(3)}")]
    [TestCase(new float[] { 3 }, 1, "{(3)}")]
    [TestCase(new float[] { 3 }, 2, "{(3)}")]
    public void ScaleMatrixByValue_01_1D_Ok(float[] leftPositions, float scale, string expectedResult)
    {
        // Arrange
        var vector1 = new VectorImmutable(leftPositions);
        var matrix = new MatrixImmutable(vector1);

        // Act
        var result = MatrixImmutable.Scale(matrix, scale);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { 3, 2 }, new float[] { 6, -1 }, 0, "{(0,2),(0,-1)}")]
    [TestCase(new float[] { 3, 2 }, new float[] { 6, -1 }, 1, "{(3,2),(6,-1)}")]
    [TestCase(new float[] { 3, 2 }, new float[] { 6, -1 }, 2, "{(6,2),(12,-1)}")]
    [TestCase(new float[] { 3, 2 }, new float[] { 6, -1 }, 4, "{(12,2),(24,-1)}")]
    public void ScaleMatrixByValue_01_2D_Ok(float[] leftPositions, float[] rightPositions, float scale, string expectedResult)
    {
        // Arrange
        var vector1 = new VectorImmutable(leftPositions);
        var vector2 = new VectorImmutable(rightPositions);
        var matrix = new MatrixImmutable(vector1, vector2);

        // Act
        var result = MatrixImmutable.Scale(matrix, scale);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { 3, 2, 7 }, new float[] { 6, -1, 9 }, new float[] { 3, 6, 8 }, 0, "{(0,0,7),(0,0,9),(0,0,8)}")]
    [TestCase(new float[] { 3, 2, 7 }, new float[] { 6, -1, 9 }, new float[] { 3, 6, 8 }, 1, "{(3,2,7),(6,-1,9),(3,6,8)}")]
    [TestCase(new float[] { 3, 2, 7 }, new float[] { 6, -1, 9 }, new float[] { 3, 6, 8 }, 2, "{(6,4,7),(12,-2,9),(6,12,8)}")]
    [TestCase(new float[] { 3, 2, 7 }, new float[] { 6, -1, 9 }, new float[] { 3, 6, 8 }, 4, "{(12,8,7),(24,-4,9),(12,24,8)}")]
    public void ScaleMatrixByValue_01_3D_Ok(float[] positions1, float[] positions2, float[] positions3, float scale, string expectedResult)
    {
        // Arrange
        var vector1 = new VectorImmutable(positions1);
        var vector2 = new VectorImmutable(positions2);
        var vector3 = new VectorImmutable(positions3);
        var matrix = new MatrixImmutable(vector1, vector2, vector3);

        // Act
        var result = MatrixImmutable.Scale(matrix, scale);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [Test]
    public void ScaleMatrixByValue_02_4x2D_Ok()
    {
        // Mocked values
        const int Size = 100;
        const float Scale = 1.5F;

        // Arrange
        var matrix = new MatrixImmutable(
            new VectorImmutable(-Size, -Size),
            new VectorImmutable(Size, -Size),
            new VectorImmutable(Size, Size),
            new VectorImmutable(-Size, Size)
        );

        // Act
        var result = MatrixImmutable.Scale(matrix, Scale);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(-150,-100),(150,-100),(150,100),(-150,100)}"));
    }

    [TestCase(new float[] { 2, -1 }, 0, "(2,-1)")]
    [TestCase(new float[] { 2, -1 }, 15, "(2.19,-0.45)")]
    [TestCase(new float[] { 2, -1 }, 30, "(2.23,0.13)")]
    [TestCase(new float[] { 2, -1 }, 45, "(2.12,0.71)")]
    [TestCase(new float[] { 2, -1 }, 90, "(1,2)")]
    [TestCase(new float[] { 2, -1 }, 180, "(-2,1)")]
    [TestCase(new float[] { 2, -1 }, 360, "(2,-1)")]
    public void RotateVectorByDegrees_01_1x1D_Ok(float[] positions, float degrees, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(positions);

        // Act
        var result = MatrixImmutable.RotateVector2D(vector, degrees);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(0, "{(1,-0),(0,1)}")]
    [TestCase(15, "{(0.97,-0.26),(0.26,0.97)}")]
    [TestCase(30, "{(0.87,-0.5),(0.5,0.87)}")]
    [TestCase(45, "{(0.71,-0.71),(0.71,0.71)}")]
    [TestCase(90, "{(0,-1),(1,0)}")]
    [TestCase(180, "{(-1,-0),(0,-1)}")]
    [TestCase(360, "{(1,0),(-0,1)}")]
    public void DegreesToRotateMatrix_01_Ok(float degrees, string expectedResult)
    {
        // Act
        var result = MatrixImmutable.DegreesToRotationMatrix2D(degrees);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { 0, 0 }, new float[] { 200, 0 }, 0, "{(0,0),(200,0)}")]
    [TestCase(new float[] { 0, 0 }, new float[] { 200, 0 }, 15, "{(0,0),(193.19,51.76)}")]
    [TestCase(new float[] { 32, 4 }, new float[] { 4, 8 }, 15, "{(29.87,12.15),(1.79,8.76)}")]
    [TestCase(new float[] { 0, 0 }, new float[] { 200, 0 }, 30, "{(0,0),(173.21,100)}")]
    [TestCase(new float[] { 32, 9 }, new float[] { 200, 18 }, 30, "{(23.21,23.79),(164.21,115.59)}")]
    [TestCase(new float[] { 0, 0 }, new float[] { 200, 0 }, 45, "{(0,0),(141.42,141.42)}")]
    [TestCase(new float[] { 0, 0 }, new float[] { 200, 0 }, 90, "{(0,0),(0,200)}")]
    [TestCase(new float[] { 0, 0 }, new float[] { 200, 0 }, 180, "{(0,0),(-200,0)}")]
    [TestCase(new float[] { 0, 0 }, new float[] { 200, 0 }, 360, "{(0,0),(200,-0)}")]
    public void RotateMatrixByDegrees_01_2x2D_Ok(float[] leftPositions, float[] rightPositions, float degrees, string expectedResult)
    {
        // Arrange
        var matrix = new MatrixImmutable(
            new VectorImmutable(leftPositions),
            new VectorImmutable(rightPositions)
        );

        // Act
        var result = MatrixImmutable.Rotate2D(matrix, degrees);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { 0 }, new float[] { 200, 0 })]
    [TestCase(new float[] { 0, 2 }, new float[] { })]
    [TestCase(new float[] { }, new float[] { })]
    public void RotateMatrixByDegrees_01_2x2D_Ok(float[] leftPositions, float[] rightPositions)
    {
        // Arrange
        var matrix = new MatrixImmutable(
            new VectorImmutable(leftPositions),
            new VectorImmutable(rightPositions)
        );

        // Act & assert
        Assert.Throws<MatrixVectorsNot2DException>(() => MatrixImmutable.Rotate2D(matrix, 0));
    }

    [TestCase(Axis.X, 0, "{(1,0,0),(0,1,-0),(0,0,1)}")]
    [TestCase(Axis.Y, 0, "{(1,0,0),(0,1,0),(-0,0,1)}")]
    [TestCase(Axis.Z, 0, "{(1,-0,0),(0,1,0),(0,0,1)}")]
    [TestCase(Axis.X, 15, "{(1,0,0),(0,0.97,-0.26),(0,0.26,0.97)}")]
    [TestCase(Axis.Y, 15, "{(0.97,0,0.26),(0,1,0),(-0.26,0,0.97)}")]
    [TestCase(Axis.Z, 15, "{(0.97,-0.26,0),(0.26,0.97,0),(0,0,1)}")]
    [TestCase(Axis.X, 30, "{(1,0,0),(0,0.87,-0.5),(0,0.5,0.87)}")]
    [TestCase(Axis.Y, 30, "{(0.87,0,0.5),(0,1,0),(-0.5,0,0.87)}")]
    [TestCase(Axis.Z, 30, "{(0.87,-0.5,0),(0.5,0.87,0),(0,0,1)}")]
    [TestCase(Axis.X, 45, "{(1,0,0),(0,0.71,-0.71),(0,0.71,0.71)}")]
    [TestCase(Axis.Y, 45, "{(0.71,0,0.71),(0,1,0),(-0.71,0,0.71)}")]
    [TestCase(Axis.Z, 45, "{(0.71,-0.71,0),(0.71,0.71,0),(0,0,1)}")]
    [TestCase(Axis.X, 90, "{(1,0,0),(0,0,-1),(0,1,0)}")]
    [TestCase(Axis.Y, 90, "{(0,0,1),(0,1,0),(-1,0,0)}")]
    [TestCase(Axis.Z, 90, "{(0,-1,0),(1,0,0),(0,0,1)}")]
    [TestCase(Axis.X, 180, "{(1,0,0),(0,-1,-0),(0,0,-1)}")]
    [TestCase(Axis.Y, 180, "{(-1,0,0),(0,1,0),(-0,0,-1)}")]
    [TestCase(Axis.Z, 180, "{(-1,-0,0),(0,-1,0),(0,0,1)}")]
    [TestCase(Axis.X, 360, "{(1,0,0),(0,1,0),(0,-0,1)}")]
    [TestCase(Axis.Y, 360, "{(1,0,-0),(0,1,0),(0,0,1)}")]
    [TestCase(Axis.Z, 360, "{(1,0,0),(-0,1,0),(0,0,1)}")]
    public void DegreesToRotateMatrix_01_3D_Ok(Axis axis, float degrees, string expectedResult)
    {
        // Act
        var result = MatrixImmutable.DegreesToRotationMatrix3D(axis, degrees);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(Axis.X, new float[] { 2, -1, 4 }, 0, "(2,-1,4)")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4 }, 0, "(2,-1,4)")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4 }, 0, "(2,-1,4)")]
    [TestCase(Axis.X, new float[] { 2, -1, 4 }, 15, "(2,-2,3.6)")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4 }, 15, "(2.97,-1,3.35)")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4 }, 15, "(2.19,-0.45,4)")]
    [TestCase(Axis.X, new float[] { 2, -1, 4 }, 30, "(2,-2.87,2.96)")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4 }, 30, "(3.73,-1,2.46)")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4 }, 30, "(2.23,0.13,4)")]
    [TestCase(Axis.X, new float[] { 2, -1, 4 }, 45, "(2,-3.54,2.12)")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4 }, 45, "(4.24,-1,1.41)")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4 }, 45, "(2.12,0.71,4)")]
    [TestCase(Axis.X, new float[] { 2, -1, 4 }, 90, "(2,-4,-1)")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4 }, 90, "(4,-1,-2)")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4 }, 90, "(1,2,4)")]
    [TestCase(Axis.X, new float[] { 2, -1, 4 }, 180, "(2,1,-4)")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4 }, 180, "(-2,-1,-4)")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4 }, 180, "(-2,1,4)")]
    [TestCase(Axis.X, new float[] { 2, -1, 4 }, 360, "(2,-1,4)")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4 }, 360, "(2,-1,4)")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4 }, 360, "(2,-1,4)")]
    public void RotateVectorByDegrees_01_3D_Ok(Axis axis, float[] positions, float degrees, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(positions);

        // Act
        var result = MatrixImmutable.RotateVector3D(axis, vector, degrees);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(Axis.X, new float[] { 2, -1, 4 }, new float[] { 3, 8, 5 }, new float[] { 6, 1, 7 }, 0, "{(2,-1,4),(3,8,5),(6,1,7)}")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4 }, new float[] { 3, 8, 5 }, new float[] { 6, 1, 7 }, 0, "{(2,-1,4),(3,8,5),(6,1,7)}")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4 }, new float[] { 3, 8, 5 }, new float[] { 6, 1, 7 }, 0, "{(2,-1,4),(3,8,5),(6,1,7)}")]
    [TestCase(Axis.X, new float[] { 2, -1, 4 }, new float[] { 3, 8, 5 }, new float[] { 6, 1, 7 }, 15, "{(2,-2,3.6),(3,6.43,6.9),(6,-0.85,7.02)}")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4 }, new float[] { 3, 8, 5 }, new float[] { 6, 1, 7 }, 15, "{(2.97,-1,3.35),(4.19,8,4.05),(7.61,1,5.21)}")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4 }, new float[] { 3, 8, 5 }, new float[] { 6, 1, 7 }, 15, "{(2.19,-0.45,4),(0.83,8.5,5),(5.54,2.52,7)}")]
    [TestCase(Axis.X, new float[] { 2, -1, 4 }, new float[] { 3, 8, 5 }, new float[] { 6, 1, 7 }, 45, "{(2,-3.54,2.12),(3,2.12,9.19),(6,-4.24,5.66)}")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4 }, new float[] { 3, 8, 5 }, new float[] { 6, 1, 7 }, 45, "{(4.24,-1,1.41),(5.66,8,1.41),(9.19,1,0.71)}")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4 }, new float[] { 3, 8, 5 }, new float[] { 6, 1, 7 }, 45, "{(2.12,0.71,4),(-3.54,7.78,5),(3.54,4.95,7)}")]
    [TestCase(Axis.X, new float[] { 2, -1, 4 }, new float[] { 3, 8, 5 }, new float[] { 6, 1, 7 }, 90, "{(2,-4,-1),(3,-5,8),(6,-7,1)}")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4 }, new float[] { 3, 8, 5 }, new float[] { 6, 1, 7 }, 90, "{(4,-1,-2),(5,8,-3),(7,1,-6)}")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4 }, new float[] { 3, 8, 5 }, new float[] { 6, 1, 7 }, 90, "{(1,2,4),(-8,3,5),(-1,6,7)}")]
    public void RotateMatrixByDegrees_01_3D_Ok(Axis axis, float[] positions1, float[] positions2, float[] positions3, float degrees, string expectedResult)
    {
        // Arrange
        var matrix = new MatrixImmutable(
            new VectorImmutable(positions1),
            new VectorImmutable(positions2),
            new VectorImmutable(positions3)
        );

        // Act
        var result = MatrixImmutable.Rotate3D(axis, matrix, degrees);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { 2, -1 }, new float[] { 3, 8, 5 }, new float[] { 6, 1, 7 })]
    [TestCase(new float[] { 2, -1, 3 }, new float[] { 3 }, new float[] { 6, 1, 7 })]
    [TestCase(new float[] { 2, -1, 3 }, new float[] { 3, 8, 5 }, new float[] { })]
    [TestCase(new float[] { }, new float[] { }, new float[] { })]
    public void RotateMatrixByDegrees_01_3D_ThrowsOnNon3DVectors(float[] positions1, float[] positions2, float[] positions3)
    {
        // Arrange
        var matrix = new MatrixImmutable(
            new VectorImmutable(positions1),
            new VectorImmutable(positions2),
            new VectorImmutable(positions3)
        );

        // Act & assert
        Assert.Throws<MatrixVectorsNot3DException>(() => MatrixImmutable.Rotate3D(Axis.X, matrix, 0));
    }

    [TestCase(Axis.X, 0, "{(1,0,0,0),(0,1,-0,0),(0,0,1,0),(0,0,0,1)}")]
    [TestCase(Axis.Y, 0, "{(1,0,0,0),(0,1,0,0),(-0,0,1,0),(0,0,0,1)}")]
    [TestCase(Axis.Z, 0, "{(1,-0,0,0),(0,1,0,0),(0,0,1,0),(0,0,0,1)}")]
    [TestCase(Axis.X, 15, "{(1,0,0,0),(0,0.97,-0.26,0),(0,0.26,0.97,0),(0,0,0,1)}")]
    [TestCase(Axis.Y, 15, "{(0.97,0,0.26,0),(0,1,0,0),(-0.26,0,0.97,0),(0,0,0,1)}")]
    [TestCase(Axis.Z, 15, "{(0.97,-0.26,0,0),(0.26,0.97,0,0),(0,0,1,0),(0,0,0,1)}")]
    [TestCase(Axis.X, 30, "{(1,0,0,0),(0,0.87,-0.5,0),(0,0.5,0.87,0),(0,0,0,1)}")]
    [TestCase(Axis.Y, 30, "{(0.87,0,0.5,0),(0,1,0,0),(-0.5,0,0.87,0),(0,0,0,1)}")]
    [TestCase(Axis.Z, 30, "{(0.87,-0.5,0,0),(0.5,0.87,0,0),(0,0,1,0),(0,0,0,1)}")]
    [TestCase(Axis.X, 45, "{(1,0,0,0),(0,0.71,-0.71,0),(0,0.71,0.71,0),(0,0,0,1)}")]
    [TestCase(Axis.Y, 45, "{(0.71,0,0.71,0),(0,1,0,0),(-0.71,0,0.71,0),(0,0,0,1)}")]
    [TestCase(Axis.Z, 45, "{(0.71,-0.71,0,0),(0.71,0.71,0,0),(0,0,1,0),(0,0,0,1)}")]
    [TestCase(Axis.X, 90, "{(1,0,0,0),(0,0,-1,0),(0,1,0,0),(0,0,0,1)}")]
    [TestCase(Axis.Y, 90, "{(0,0,1,0),(0,1,0,0),(-1,0,0,0),(0,0,0,1)}")]
    [TestCase(Axis.Z, 90, "{(0,-1,0,0),(1,0,0,0),(0,0,1,0),(0,0,0,1)}")]
    [TestCase(Axis.X, 180, "{(1,0,0,0),(0,-1,-0,0),(0,0,-1,0),(0,0,0,1)}")]
    [TestCase(Axis.Y, 180, "{(-1,0,0,0),(0,1,0,0),(-0,0,-1,0),(0,0,0,1)}")]
    [TestCase(Axis.Z, 180, "{(-1,-0,0,0),(0,-1,0,0),(0,0,1,0),(0,0,0,1)}")]
    [TestCase(Axis.X, 360, "{(1,0,0,0),(0,1,0,0),(0,-0,1,0),(0,0,0,1)}")]
    [TestCase(Axis.Y, 360, "{(1,0,-0,0),(0,1,0,0),(0,0,1,0),(0,0,0,1)}")]
    [TestCase(Axis.Z, 360, "{(1,0,0,0),(-0,1,0,0),(0,0,1,0),(0,0,0,1)}")]
    public void DegreesToRotateMatrix_01_4D_Ok(Axis axis, float degrees, string expectedResult)
    {
        // Act
        var result = MatrixImmutable.DegreesToRotationMatrix4D(axis, degrees);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(Axis.X, new float[] { 2, -1, 4, 5 }, 0, "(2,-1,4,5)")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4, 5 }, 0, "(2,-1,4,5)")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4, 5 }, 0, "(2,-1,4,5)")]
    [TestCase(Axis.X, new float[] { 2, -1, 4, 5 }, 15, "(2,-2,3.6,5)")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4, 5 }, 15, "(2.97,-1,3.35,5)")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4, 5 }, 15, "(2.19,-0.45,4,5)")]
    [TestCase(Axis.X, new float[] { 2, -1, 4, 5 }, 30, "(2,-2.87,2.96,5)")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4, 5 }, 30, "(3.73,-1,2.46,5)")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4, 5 }, 30, "(2.23,0.13,4,5)")]
    [TestCase(Axis.X, new float[] { 2, -1, 4, 5 }, 45, "(2,-3.54,2.12,5)")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4, 5 }, 45, "(4.24,-1,1.41,5)")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4, 5 }, 45, "(2.12,0.71,4,5)")]
    [TestCase(Axis.X, new float[] { 2, -1, 4, 5 }, 90, "(2,-4,-1,5)")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4, 5 }, 90, "(4,-1,-2,5)")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4, 5 }, 90, "(1,2,4,5)")]
    [TestCase(Axis.X, new float[] { 2, -1, 4, 5 }, 180, "(2,1,-4,5)")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4, 5 }, 180, "(-2,-1,-4,5)")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4, 5 }, 180, "(-2,1,4,5)")]
    [TestCase(Axis.X, new float[] { 2, -1, 4, 5 }, 360, "(2,-1,4,5)")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4, 5 }, 360, "(2,-1,4,5)")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4, 5 }, 360, "(2,-1,4,5)")]
    public void RotateVectorByDegrees_01_4D_Ok(Axis axis, float[] positions, float degrees, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(positions);

        // Act
        var result = MatrixImmutable.RotateVector4D(axis, vector, degrees);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(Axis.X, new float[] { 2, -1, 4, 3 }, new float[] { 3, 8, 5, 2 }, new float[] { 6, 1, 7, 3 }, new float[] { 2, 1, 4, 9 }, 0, "{(2,-1,4,3),(3,8,5,2),(6,1,7,3),(2,1,4,9)}")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4, 3 }, new float[] { 3, 8, 5, 2 }, new float[] { 6, 1, 7, 3 }, new float[] { 2, 1, 4, 9 }, 0, "{(2,-1,4,3),(3,8,5,2),(6,1,7,3),(2,1,4,9)}")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4, 3 }, new float[] { 3, 8, 5, 2 }, new float[] { 6, 1, 7, 3 }, new float[] { 2, 1, 4, 9 }, 0, "{(2,-1,4,3),(3,8,5,2),(6,1,7,3),(2,1,4,9)}")]
    [TestCase(Axis.X, new float[] { 2, -1, 4, 3 }, new float[] { 3, 8, 5, 2 }, new float[] { 6, 1, 7, 3 }, new float[] { 2, 1, 4, 9 }, 15, "{(2,-2,3.6,3),(3,6.43,6.9,2),(6,-0.85,7.02,3),(2,-0.07,4.12,9)}")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4, 3 }, new float[] { 3, 8, 5, 2 }, new float[] { 6, 1, 7, 3 }, new float[] { 2, 1, 4, 9 }, 15, "{(2.97,-1,3.35,3),(4.19,8,4.05,2),(7.61,1,5.21,3),(2.97,1,3.35,9)}")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4, 3 }, new float[] { 3, 8, 5, 2 }, new float[] { 6, 1, 7, 3 }, new float[] { 2, 1, 4, 9 }, 15, "{(2.19,-0.45,4,3),(0.83,8.5,5,2),(5.54,2.52,7,3),(1.67,1.48,4,9)}")]
    [TestCase(Axis.X, new float[] { 2, -1, 4, 3 }, new float[] { 3, 8, 5, 2 }, new float[] { 6, 1, 7, 3 }, new float[] { 2, 1, 4, 9 }, 45, "{(2,-3.54,2.12,3),(3,2.12,9.19,2),(6,-4.24,5.66,3),(2,-2.12,3.54,9)}")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4, 3 }, new float[] { 3, 8, 5, 2 }, new float[] { 6, 1, 7, 3 }, new float[] { 2, 1, 4, 9 }, 45, "{(4.24,-1,1.41,3),(5.66,8,1.41,2),(9.19,1,0.71,3),(4.24,1,1.41,9)}")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4, 3 }, new float[] { 3, 8, 5, 2 }, new float[] { 6, 1, 7, 3 }, new float[] { 2, 1, 4, 9 }, 45, "{(2.12,0.71,4,3),(-3.54,7.78,5,2),(3.54,4.95,7,3),(0.71,2.12,4,9)}")]
    [TestCase(Axis.X, new float[] { 2, -1, 4, 3 }, new float[] { 3, 8, 5, 2 }, new float[] { 6, 1, 7, 3 }, new float[] { 2, 1, 4, 9 }, 90, "{(2,-4,-1,3),(3,-5,8,2),(6,-7,1,3),(2,-4,1,9)}")]
    [TestCase(Axis.Y, new float[] { 2, -1, 4, 3 }, new float[] { 3, 8, 5, 2 }, new float[] { 6, 1, 7, 3 }, new float[] { 2, 1, 4, 9 }, 90, "{(4,-1,-2,3),(5,8,-3,2),(7,1,-6,3),(4,1,-2,9)}")]
    [TestCase(Axis.Z, new float[] { 2, -1, 4, 3 }, new float[] { 3, 8, 5, 2 }, new float[] { 6, 1, 7, 3 }, new float[] { 2, 1, 4, 9 }, 90, "{(1,2,4,3),(-8,3,5,2),(-1,6,7,3),(-1,2,4,9)}")]
    public void RotateMatrixByDegrees_01_4D_Ok(Axis axis, float[] positions1, float[] positions2, float[] positions3, float[] positions4, float degrees, string expectedResult)
    {
        // Arrange
        var matrix = new MatrixImmutable(
            new VectorImmutable(positions1),
            new VectorImmutable(positions2),
            new VectorImmutable(positions3),
            new VectorImmutable(positions4)
        );

        // Act
        var result = MatrixImmutable.Rotate4D(axis, matrix, degrees);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { 2, -1 }, new float[] { 3, 8, 5 }, new float[] { 6, 1, 7 }, new float[] { })]
    [TestCase(new float[] { 2, -1, 3 }, new float[] { 3 }, new float[] { 6, 1, 7 }, new float[] { })]
    [TestCase(new float[] { 2, -1, 3 }, new float[] { 3, 8, 5 }, new float[] { }, new float[] { })]
    [TestCase(new float[] { 2, -1, 3, 4 }, new float[] { 3, 8, 5, 6 }, new float[] { 3, 8, 9, 10 }, new float[] { })]
    [TestCase(new float[] { }, new float[] { }, new float[] { }, new float[] { })]
    public void RotateMatrixByDegrees_01_4D_ThrowsOnNon4DVectors(float[] positions1, float[] positions2, float[] positions3, float[] positions4)
    {
        // Arrange
        var matrix = new MatrixImmutable(
            new VectorImmutable(positions1),
            new VectorImmutable(positions2),
            new VectorImmutable(positions3),
            new VectorImmutable(positions4)
        );

        // Act & assert
        Assert.Throws<MatrixVectorsNot4DException>(() => MatrixImmutable.Rotate4D(Axis.X, matrix, 0));
    }

    [TestCase(new float[] { }, "{}")]
    [TestCase(new float[] { 0 }, "{(1,0),(0,1)}")]
    [TestCase(new float[] { 1 }, "{(1,1),(0,1)}")]
    [TestCase(new float[] { 75 }, "{(1,75),(0,1)}")]
    public void VectorToTranslationMatrix_01_1D_and_2D_Ok(float[] vectorPositions, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(vectorPositions);

        // Act
        var result = MatrixImmutable.VectorToTranslationMatrix(vector);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { 0, 0 }, "{(1,0,0),(0,1,0),(0,0,1)}")]
    [TestCase(new float[] { 1, 2 }, "{(1,0,1),(0,1,2),(0,0,1)}")]
    [TestCase(new float[] { 75, -25 }, "{(1,0,75),(0,1,-25),(0,0,1)}")]
    public void VectorToTranslationMatrix_01_3D_Ok(float[] vectorPositions, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(vectorPositions);

        // Act
        var result = MatrixImmutable.VectorToTranslationMatrix(vector);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { 0, 0, 0 }, "{(1,0,0,0),(0,1,0,0),(0,0,1,0),(0,0,0,1)}")]
    [TestCase(new float[] { 1, 2, 3 }, "{(1,0,0,1),(0,1,0,2),(0,0,1,3),(0,0,0,1)}")]
    [TestCase(new float[] { 75, -25, 1 }, "{(1,0,0,75),(0,1,0,-25),(0,0,1,1),(0,0,0,1)}")]
    [TestCase(new float[] { 75, -25, 34 }, "{(1,0,0,75),(0,1,0,-25),(0,0,1,34),(0,0,0,1)}")]
    public void VectorToTranslationMatrix_01_4D_Ok(float[] vectorPositions, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(vectorPositions);

        // Act
        var result = MatrixImmutable.VectorToTranslationMatrix(vector);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { 0, 0, 0, 0 }, "{(1,0,0,0,0),(0,1,0,0,0),(0,0,1,0,0),(0,0,0,1,0),(0,0,0,0,1)}")]
    [TestCase(new float[] { 1, 2, 3, 4 }, "{(1,0,0,0,1),(0,1,0,0,2),(0,0,1,0,3),(0,0,0,1,4),(0,0,0,0,1)}")]
    [TestCase(new float[] { 75, -25, 1, 34 }, "{(1,0,0,0,75),(0,1,0,0,-25),(0,0,1,0,1),(0,0,0,1,34),(0,0,0,0,1)}")]
    public void VectorToTranslationMatrix_01_5D_Ok(float[] vectorPositions, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(vectorPositions);

        // Act
        var result = MatrixImmutable.VectorToTranslationMatrix(vector);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { 0, 0 }, "{(-100,-100,1),(100,-100,1),(100,100,1),(-100,100,1)}")]
    [TestCase(new float[] { 1, 2 }, "{(-99,-98,1),(101,-98,1),(101,102,1),(-99,102,1)}")]
    [TestCase(new float[] { 75, -25 }, "{(-25,-125,1),(175,-125,1),(175,75,1),(-25,75,1)}")]
    public void TranslateMatrix_01_3D_Ok(float[] vectorPositions, string expectedResult)
    {
        // Mocked values
        const int Size = 100;

        // Arrange
        var vector = new VectorImmutable(vectorPositions);
        var matrix = new MatrixImmutable(
            new VectorImmutable(-Size, -Size, 1),
            new VectorImmutable(Size, -Size, 1),
            new VectorImmutable(Size, Size, 1),
            new VectorImmutable(-Size, Size, 1)
        );

        // Act
        var result = MatrixImmutable.Translate(matrix, vector);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(new float[] { 0, 0 }, new float[] { 0, 1, 3, 4, 5 }, new float[] { }, new float[] { }, new float[] { })]
    [TestCase(new float[] { 0 }, new float[] { 0, 1, 3 }, new float[] { 0, 1, 3 }, new float[] { 0, 1, 3 }, new float[] { 0, 1, 3 })]
    [TestCase(new float[] { 0, 0, 0 }, new float[] { 0, 1, 3 }, new float[] { 0, 1, 3 }, new float[] { 0, 1, 3 }, new float[] { 0, 1, 3 })]
    [TestCase(new float[] { 0, 0 }, new float[] { 0, 1, 3 }, new float[] { 0, 1, 3 }, new float[] { 0, 1 }, new float[] { 0, 1, 3 })]
    public void TranslateMatrix_02_ThrowsOnTranslationMatrixNotEqualToInputMatrix(float[] vectorPositions, float[] matrixVectorPositions1, float[] matrixVectorPositions2, float[] matrixVectorPositions3, float[] matrixVectorPositions4)
    {
        // Arrange
        var vector = new VectorImmutable(vectorPositions);
        var matrix = new MatrixImmutable(
            new VectorImmutable(matrixVectorPositions1),
            new VectorImmutable(matrixVectorPositions2),
            new VectorImmutable(matrixVectorPositions3),
            new VectorImmutable(matrixVectorPositions4)
        );

        // Act & assert
        Assert.Throws<MatrixVectorColumnsAreNotEqualToTranslationMatrixException>(() => MatrixImmutable.Translate(matrix, vector));
    }

    [TestCase(new float[] { 0, 0, 0 }, "{(-100,-100,1,1),(100,-100,1,1),(100,100,1,1),(-100,100,1,1)}")]
    [TestCase(new float[] { 1, 2, 3 }, "{(-99,-98,4,1),(101,-98,4,1),(101,102,4,1),(-99,102,4,1)}")]
    [TestCase(new float[] { 75, -25, 1 }, "{(-25,-125,2,1),(175,-125,2,1),(175,75,2,1),(-25,75,2,1)}")]
    public void TranslateMatrix_03_4D_Ok(float[] vectorPositions, string expectedResult)
    {
        // Mocked values
        const int Size = 100;

        // Arrange
        var vector = new VectorImmutable(vectorPositions);
        var matrix = new MatrixImmutable(
            new VectorImmutable(-Size, -Size, 1, 1),
            new VectorImmutable(Size, -Size, 1, 1),
            new VectorImmutable(Size, Size, 1, 1),
            new VectorImmutable(-Size, Size, 1, 1)
        );

        // Act
        var result = MatrixImmutable.Translate(matrix, vector);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(0, 0, 0, "{(-0,1,0,0),(-1,-0,0,0),(0,0,1,-0),(0,0,0,1)}")]
    [TestCase(10, -100, -10, "{(0.98,-0.17,0,0),(0.17,0.97,-0.17,0),(0.03,0.17,0.98,-10),(0,0,0,1)}")]
    [TestCase(33, 50, 65, "{(-0.77,0.64,0,0),(-0.27,-0.32,0.91,0),(0.58,0.69,0.42,-33),(0,0,0,1)}")]
    public void ViewMatrix_01_4D_Ok(float radians, float theta, float phi, string expectedResult)
    {
        // Act
        var result = MatrixImmutable.ViewMatrix4D(radians, theta, phi);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(0, new float[] { 3, 4, 5 }, "{(-0,0,0,0),(0,-0,0,0),(0,0,1,0),(0,0,0,1)}")]
    [TestCase(10, new float[] { 3, 4, 5 }, "{(-2,0,0,0),(0,-2,0,0),(0,0,1,0),(0,0,0,1)}")]
    [TestCase(33, new float[] { 3, 4, 5 }, "{(-6.6,0,0,0),(0,-6.6,0,0),(0,0,1,0),(0,0,0,1)}")]
    public void ProjectionMatrix_01_4D_Ok(float distance, float[] distancePositions, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(distancePositions);

        // Act
        var result = MatrixImmutable.ProjectionMatrix4D(distance, vector);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }

    [TestCase(0, 0, 0, 0, "{(0,0,1,1),(0,0,1,1),(0,0,1,1),(0,0,1,1)}")]
    [TestCase(10, 10, -100, -10, "{(-27.84,-39.22,-29.13,1),(50.15,-34.66,-23.1,1),(-73.07,-102.61,11.1,1),(228.47,-157.21,5.07,1)}")]
    [TestCase(33, 33, 50, 65, "{(2.54,12.45,-160.26,1),(-106.27,4.61,-43.75,1),(4.28,20.34,95.11,1),(217.18,-6.63,-21.41,1)}")]
    public void ViewingPipelineMatrix_01_4D_Ok(float distance, float radians, float theta, float phi, string expectedResult)
    {
        // Mocked values
        const int Size = 100;

        // Arrange
        var matrix = new MatrixImmutable(
            new(-Size, -Size, 1, 1),
            new(Size, -Size, 1, 1),
            new(Size, Size, 1, 1),
            new(-Size, Size, 1, 1)
        );

        // Act
        var result = MatrixImmutable.ViewingPipeline4D(matrix, distance, radians, theta, phi);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }
}
