namespace Src;

public class MatrixImmutable2D
{
    /// <summary>The first element of the first row.</summary>
    public float M11 { get; private init; }

    /// <summary>The second element of the first row.</summary>
    public float M12 { get; private init; }

    /// <summary>The first element of the second row.</summary>
    public float M21 { get; private init; }

    /// <summary>The second element of the second row.</summary>
    public float M22 { get; private init; }

    public MatrixImmutable2D() : this(0, 0, 0, 0)
    {

    }

    public MatrixImmutable2D(float m11, float m12, float m21, float m22)
    {
        M11 = m11;
        M12 = m12;
        M21 = m21;
        M22 = m22;
    }

    public MatrixImmutable2D(VectorImmutable2D vector)
    {
        M11 = (float)vector.XPosition;
        M21 = (float)vector.YPosition;
    }

    public static VectorImmutable2D ToVector(MatrixImmutable2D matrix)
    {
        // Always get the first row
        return new VectorImmutable2D(matrix.M11, matrix.M21);
    }

    public VectorImmutable2D ToVectorLeft()
    {
        return new VectorImmutable2D(M11, M21);
    }

    public VectorImmutable2D ToVectorRight()
    {
        return new VectorImmutable2D(M12, M22);
    }

    public static MatrixImmutable2D Identity(MatrixImmutable2D matrix)
    {
        return new MatrixImmutable2D(1, 0, 0, 1);
    }

    public static MatrixImmutable2D operator +(MatrixImmutable2D left, MatrixImmutable2D right)
    {
        return new MatrixImmutable2D(
            left.M11 + right.M11,
            left.M12 + right.M12,
            left.M21 + right.M21,
            left.M22 + right.M22
        );
    }

    public static MatrixImmutable2D operator -(MatrixImmutable2D left, MatrixImmutable2D right)
    {
        return new MatrixImmutable2D(
            left.M11 - right.M11,
            left.M12 - right.M12,
            left.M21 - right.M21,
            left.M22 - right.M22
        );
    }

    public static MatrixImmutable2D operator *(MatrixImmutable2D matrix, float multiply)
    {
        return new MatrixImmutable2D(
            matrix.M11 * multiply,
            matrix.M12 * multiply,
            matrix.M21 * multiply,
            matrix.M22 * multiply
        );
    }

    public static MatrixImmutable2D operator *(float multiply, MatrixImmutable2D matrix)
    {
        return new MatrixImmutable2D(
            matrix.M11 * multiply,
            matrix.M12 * multiply,
            matrix.M21 * multiply,
            matrix.M22 * multiply
        );
    }

    public static MatrixImmutable2D operator *(MatrixImmutable2D left, MatrixImmutable2D right)
    {
        return new MatrixImmutable2D(
            left.M11 * right.M11 + left.M12 * right.M21,
            left.M11 * right.M12 + left.M12 * right.M22,
            left.M21 * right.M11 + left.M22 * right.M21,
            left.M21 * right.M12 + left.M22 * right.M22
        );
    }

    public static VectorImmutable2D operator *(MatrixImmutable2D matrix, VectorImmutable2D vector)
    {
        var left = matrix;
        var right = new MatrixImmutable2D(vector);

        return ToVector(left * right);
    }

    public override string ToString()
    {
        return "{" + $"({M11},{M12})" + "," + $"({M21},{M22})" + "}";
    }
}
