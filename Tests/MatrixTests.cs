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
        Assert.That(result.ToString(), Is.EqualTo("{}"));
    }
    
    [Test]
    public void Create_02_1D_Ok()
    {
        // Act
        var vector1 = new VectorImmutable(3);
        var vector2 = new VectorImmutable(1);
        var result = new MatrixImmutable(vector1, vector2);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(3),(1)}"));
    }
    
    [Test]
    public void Create_02_2D_Ok()
    {
        // Act
        var vector1 = new VectorImmutable(3, 4);
        var vector2 = new VectorImmutable(1, 6);
        var result = new MatrixImmutable(vector1, vector2);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(3,4),(1,6)}"));
    }
    
    [Test]
    public void Create_03_3D_Ok()
    {
        // Act
        var vector1 = new VectorImmutable(3, 2, 4);
        var vector2 = new VectorImmutable(1, 0, 4);
        var vector3 = new VectorImmutable(1, 3, 4);
        var result = new MatrixImmutable(vector1, vector2,vector3);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(3,2,4),(1,0,4),(1,3,4)}"));
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
        Assert.Throws<MatrixVectorsLengthNotEqualToVectorDimensionsException>(() =>
        {
            var result = MatrixImmutable.Identity(matrix);
        });
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
        Assert.That(result.ToString(), Is.EqualTo("{(),()}"));
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
        Assert.That(result.ToString(), Is.EqualTo("{(),()}"));
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
        Assert.Throws<MatrixLeftColumnsAreNotEqualToMatrixRightRows>(() =>
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

    [TestCase(new float[]{}, new float[]{}, 0, "{(),()}")]
    [TestCase(new float[]{}, new float[]{}, 1, "{(),()}")]
    [TestCase(new float[]{}, new float[]{}, 2, "{(),()}")]
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
    
    [TestCase(new float[]{3}, 0, "{(0)}")]
    [TestCase(new float[]{3}, 1, "{(3)}")]
    [TestCase(new float[]{3}, 2, "{(6)}")]
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
    
    [TestCase(new float[]{3,2}, new float[]{6,-1}, 0, "{(0,0),(0,0)}")]
    [TestCase(new float[]{3,2}, new float[]{6,-1}, 1, "{(3,2),(6,-1)}")]
    [TestCase(new float[]{3,2}, new float[]{6,-1}, 2, "{(6,4),(12,-2)}")]
    [TestCase(new float[]{3,2}, new float[]{6,-1}, 4, "{(12,8),(24,-4)}")]
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
    
    [TestCase(new float[]{3,2,7}, new float[]{6,-1,8}, new float[]{3,6,8}, 0, "{(0,0,0),(0,0,0),(0,0,0)}")]
    [TestCase(new float[]{3,2,6}, new float[]{6,-1,3}, new float[]{3,6,8}, 1, "{(3,2,6),(6,-1,3),(3,6,8)}")]
    [TestCase(new float[]{3,2,5}, new float[]{6,-1,9}, new float[]{3,6,8}, 2, "{(6,4,10),(12,-2,18),(6,12,16)}")]
    [TestCase(new float[]{3,2,4}, new float[]{6,-1,9}, new float[]{3,6,8}, 4, "{(12,8,16),(24,-4,36),(12,24,32)}")]
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
        var size = 100;
        var scale = 1.5;
        
        // Arrange
        var matrix = new MatrixImmutable(
            new(-size, -size),
            new(size, -size),
            new(size, size),
            new(-size, size)
        );

        // Act
        var result = MatrixImmutable.Scale(matrix, scale);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(-150,-150),(150,-150),(150,150),(-150,150)}"));
    }
    
    [TestCase(new float[]{2,-1}, 0, "(2,-1)")]
    [TestCase(new float[]{2,-1}, 15, "(2.19,-0.45)")]
    [TestCase(new float[]{2,-1}, 30, "(2.23,0.13)")]
    [TestCase(new float[]{2,-1}, 45, "(2.12,0.71)")]
    [TestCase(new float[]{2,-1}, 90, "(1,2)")]
    [TestCase(new float[]{2,-1}, 180, "(-2,1)")]
    [TestCase(new float[]{2,-1}, 360, "(2,-1)")]
    public void RotateVectorByDegrees_01_1x1D_Ok(float[] positions, float degrees, string expectedResult)
    {
        // Arrange
        var vector = new VectorImmutable(positions);

        // Act
        var result = MatrixImmutable.RotateVector(vector, degrees);

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
        var result = MatrixImmutable.DegreesToRotationMatrix(degrees);
        
        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }
    
    [TestCase(new float[]{0,0}, new float[]{200,0}, 0, "{(0,0),(200,0)}")]
    [TestCase(new float[]{0,0}, new float[]{200,0}, 15, "{(0,0),(193.19,51.76)}")]
    [TestCase(new float[]{32,4}, new float[]{4,8}, 15, "{(29.87,12.15),(1.79,8.76)}")]
    [TestCase(new float[]{0,0}, new float[]{200,0}, 30, "{(0,0),(173.21,100)}")]
    [TestCase(new float[]{32,9}, new float[]{200,18}, 30, "{(23.21,23.79),(164.21,115.59)}")]
    [TestCase(new float[]{0,0}, new float[]{200,0}, 45, "{(0,0),(141.42,141.42)}")]
    [TestCase(new float[]{0,0}, new float[]{200,0}, 90, "{(0,0),(0,200)}")]
    [TestCase(new float[]{0,0}, new float[]{200,0}, 180, "{(0,0),(-200,0)}")]
    [TestCase(new float[]{0,0}, new float[]{200,0}, 360, "{(0,0),(200,-0)}")]
    public void RotateMatrixByDegrees_01_2x2D_Ok(float[] leftPositions, float[] rightPositions, float degrees, string expectedResult)
    {
        // Arrange
        var matrix = new MatrixImmutable(
            new(leftPositions),
            new(rightPositions)
        );

        // Act
        var result = MatrixImmutable.Rotate2D(matrix, degrees);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo(expectedResult));
    }
}

public class MatrixImmutable2DTests
{
    [Test]
    public void CreateEmpty_01_Ok()
    {
        // Act
        var result = new MatrixImmutable2D();

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(0,0),(0,0)}"));
    }
    
    [Test]
    public void CreateNotEmpty_02_Ok()
    {
        // Act
        var result = new MatrixImmutable2D(3, 2, 1, 0);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(3,2),(1,0)}"));
    }
    
    [Test]
    public void Add_01_Ok()
    {
        // Arrange
        var left = new MatrixImmutable2D(3, 2, 1, 0);
        var right = new MatrixImmutable2D(2, -3, 2, -5);
        
        // Act
        var result = left + right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(5,-1),(3,-5)}"));
    }
    
    [Test]
    public void Subtract_01_Ok()
    {
        // Arrange
        var left = new MatrixImmutable2D(3, 2, 1, 0);
        var right = new MatrixImmutable2D(2, -3, 2, -5);
        
        // Act
        var result = left - right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(1,5),(-1,5)}"));
    }
    
    [Test]
    public void Multiply_01_Ok()
    {
        // Arrange
        var left = new MatrixImmutable2D(2, 4, -1, 3);
        var right = new MatrixImmutable2D(2, 4, -1, 3);
        
        // Act
        var result = left * right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(0,20),(-5,5)}"));
    }
    
    [Test]
    public void Multiply_02_Ok()
    {
        // Arrange
        var left = new MatrixImmutable2D(2, 4, -1, 3);
        var right = new MatrixImmutable2D(1, 3, 2, 1);
        
        // Act
        var result = left * right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(10,10),(5,0)}"));
    }
    
    [Test]
    public void Multiply_03_Ok()
    {
        // Arrange
        var left = new MatrixImmutable2D(1, 3, 2, 1);
        var right = new MatrixImmutable2D(2, 4, -1, 3);
        
        // Act
        var result = left * right;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(-1,13),(3,11)}"));
    }
    
    [Test]
    public void Multiply_04_Ok()
    {
        // Arrange
        var matrix = new MatrixImmutable2D(2, 4, -1, 3);
        var vector = new VectorImmutable2D(2, 6);
        
        // Act
        var result = matrix * vector;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("(28,16)"));
    }
    
    [Test]
    public void Multiply_05_Ok()
    {
        // Arrange
        var matrix = new MatrixImmutable2D(2, 4, -1, 3);
        
        // Act
        var result = matrix * 2;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(4,8),(-2,6)}"));
    }
    
    [Test]
    public void Multiply_06_Ok()
    {
        // Arrange
        var matrix = new MatrixImmutable2D(2, 4, -1, 3);
        
        // Act
        var result = 2 * matrix;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(4,8),(-2,6)}"));
    }
    
    [Test]
    public void ToVectorLeft_01_Ok()
    {
        // Arrange
        var matrix = new MatrixImmutable2D(2, 4, -1, 3);
        
        // Act
        var result = matrix.ToVectorLeft();

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("(2,-1)"));
    }
    
    [Test]
    public void ToVectorRight_01_Ok()
    {
        // Arrange
        var matrix = new MatrixImmutable2D(2, 4, -1, 3);
        
        // Act
        var result = matrix.ToVectorRight();

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("(4,3)"));
    }
    
    [Test]
    public void ToVector_01_Ok()
    {
        // Arrange
        var matrix = new MatrixImmutable2D(2, 4, -1, 3);
        var vector = new VectorImmutable2D(2, 6);
        
        // Act
        var result = matrix * vector;

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("(28,16)"));
    }
    
    [Test]
    public void Identity_01_Ok()
    {
        // Arrange
        var matrix = new MatrixImmutable2D(2, 4, -1, 3);
        
        // Act
        var result = MatrixImmutable2D.Identity(matrix);

        // Assert
        Assert.That(result.ToString(), Is.EqualTo("{(1,0),(0,1)}"));
    }
}
