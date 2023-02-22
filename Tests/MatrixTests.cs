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
        Assert.Throws<MatrixDifferentVectorsDimensionsException>(() => MatrixImmutable.Identity(matrix));
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