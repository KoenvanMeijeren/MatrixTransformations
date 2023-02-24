﻿using System.Text;

namespace Src;

public class MatrixImmutable
{
    public readonly VectorImmutable[] Vectors;

    public MatrixImmutable(params VectorImmutable[] vectors)
    {
        Vectors = vectors;
    }

    public static VectorImmutable ToVector(MatrixImmutable matrix, int column)
    {
        if (matrix.IsEmpty())
        {
            return new VectorImmutable();
        }

        var vectors = matrix.Vectors;
        var newPositions = new List<float>();
        VectorImmutable? previousVector = null;
        foreach (var vector in vectors)
        {
            if (previousVector != null)
            {
                EnsureVectorsHaveEqualDimensions(previousVector, vector);
            }

            var positions = vector.Positions;
            EnsureIndexWithinBounds(positions, column);
            newPositions.Add(positions[column]);
            previousVector = vector;
        }

        return new VectorImmutable(newPositions.ToArray());
    }

    public static MatrixImmutable Identity(MatrixImmutable matrix, double identity)
    {
        return Identity(matrix, (float)identity);
    }

    public static MatrixImmutable Identity(MatrixImmutable matrix, float identity = 1)
    {
        if (matrix.IsEmpty())
        {
            return new MatrixImmutable();
        }

        VectorImmutable? previousVector = null;
        var vectors = new VectorImmutable[matrix.Vectors.Length];
        var identityIndex = 0;
        var vectorIndex = 0;
        foreach (var vector in matrix.Vectors)
        {
            EnsureMatrixVectorsHaveEqualVectorDimensions(matrix.Vectors, vector);
            if (previousVector != null)
            {
                EnsureVectorsHaveEqualDimensions(previousVector, vector);
            }

            var positions = new float[vector.Length()];
            positions[identityIndex++] = identity;
            vectors[vectorIndex++] = new VectorImmutable(positions);
            previousVector = vector;
        }

        EnsureMatrixVectorsHaveEqualVectorDimensions(vectors, previousVector);

        return new MatrixImmutable(vectors);
    }

    public static MatrixImmutable operator +(MatrixImmutable left, MatrixImmutable right)
    {
        EnsureMatrixVectorsLengthEqual(left, right);
        if (left.IsEmpty() || right.IsEmpty())
        {
            return new MatrixImmutable();
        }

        var vectorsLength = left.Vectors.Length;
        var newVectors = new VectorImmutable[vectorsLength];
        for (var index = 0; index < vectorsLength; index++)
        {
            var vectorLeft = left.Vectors[index];
            var vectorRight = right.Vectors[index];

            EnsureVectorsHaveEqualDimensions(vectorLeft, vectorRight);
            newVectors[index] = vectorLeft + vectorRight;
        }

        return new MatrixImmutable(newVectors);
    }

    public static MatrixImmutable operator -(MatrixImmutable left, MatrixImmutable right)
    {
        EnsureMatrixVectorsLengthEqual(left, right);
        if (left.IsEmpty() || right.IsEmpty())
        {
            return new MatrixImmutable();
        }

        var vectorsLength = left.Vectors.Length;
        var newVectors = new VectorImmutable[vectorsLength];
        for (var index = 0; index < vectorsLength; index++)
        {
            var vectorLeft = left.Vectors[index];
            var vectorRight = right.Vectors[index];

            EnsureVectorsHaveEqualDimensions(vectorLeft, vectorRight);
            newVectors[index] = vectorLeft - vectorRight;
        }

        return new MatrixImmutable(newVectors);
    }

    public static MatrixImmutable operator *(MatrixImmutable matrix, float multiply)
    {
        var vectorsLength = matrix.Vectors.Length;
        var newVectors = new VectorImmutable[vectorsLength];
        for (var index = 0; index < vectorsLength; index++)
        {
            var vector = matrix.Vectors[index];
            newVectors[index] = vector * multiply;
        }

        return new MatrixImmutable(newVectors);
    }

    public static MatrixImmutable operator *(MatrixImmutable matrix, double multiply)
    {
        return matrix * (float)multiply;
    }

    public static MatrixImmutable operator *(float multiply, MatrixImmutable matrix)
    {
        return matrix * multiply;
    }

    public static MatrixImmutable operator *(double multiply, MatrixImmutable matrix)
    {
        return matrix * (float)multiply;
    }

    public static MatrixImmutable operator *(MatrixImmutable left, MatrixImmutable right)
    {
        var newMatrixLength = left.Length();
        if (right.Length() < newMatrixLength)
        {
            newMatrixLength = right.Length();
        }

        var newVectors = new VectorImmutable[newMatrixLength];
        for (var matrixLeftRow = 0; matrixLeftRow < newMatrixLength; matrixLeftRow++)
        {
            var leftVector = left.Vectors[matrixLeftRow];
            EnsureVectorLeftColumnsAreEqualToMatrixRightRows(leftVector, right);

            var rightColumnsLength = right.Vectors[0].Length();
            var newPositions = new float[rightColumnsLength];
            for (var matrixRightColumn = 0; matrixRightColumn < rightColumnsLength; matrixRightColumn++)
            {
                float result = 0;
                for (var matrixRightRow = 0; matrixRightRow < right.Length(); matrixRightRow++)
                {
                    var vectorLeftValue = leftVector.Positions[matrixRightRow];
                    var vectorRightValue = right.Vectors[matrixRightRow].Positions[matrixRightColumn];
                    result += vectorLeftValue * vectorRightValue;
                }

                newPositions[matrixRightColumn] = result;
            }

            newVectors[matrixLeftRow] = new VectorImmutable(newPositions);
        }

        return new MatrixImmutable(newVectors);
    }

    public static VectorImmutable operator *(MatrixImmutable matrix, VectorImmutable vector)
    {
        var vectors = new VectorImmutable[vector.Length()];
        for (var index = 0; index < vector.Length(); index++)
        {
            vectors[index] = new VectorImmutable(vector.Positions[index]);
        }

        var vectorMatrix = new MatrixImmutable(vectors);

        return ToVector(matrix * vectorMatrix, 0);
    }

    public static MatrixImmutable operator *(VectorImmutable vector, MatrixImmutable matrix)
    {
        var vectors = new[] { vector };
        var vectorMatrix = new MatrixImmutable(vectors);

        return vectorMatrix * matrix;
    }

    public static MatrixImmutable Scale(MatrixImmutable matrix, double scale)
    {
        return Scale(matrix, (float)scale);
    }

    public static MatrixImmutable Scale(MatrixImmutable matrix, float scale)
    {
        var firstVector = matrix.Vectors[0];
        if (firstVector.IsEmpty())
        {
            return matrix;
        }

        if (matrix.Length() != firstVector.Length())
        {
            return matrix * scale;
        }

        return Identity(matrix, scale) * matrix;
    }

    public static MatrixImmutable DegreesToRotationMatrix2D(float degrees)
    {
        var angle = Calculator.ConvertToRadians(degrees);
        var cosAlfa = (float)Math.Cos(angle);
        var sinALfa = (float)Math.Sin(angle);

        return new MatrixImmutable(
            new VectorImmutable(cosAlfa, -sinALfa),
            new VectorImmutable(sinALfa, cosAlfa)
        );
    }

    public static VectorImmutable RotateVector2D(VectorImmutable vector, float degrees)
    {
        return DegreesToRotationMatrix2D(degrees) * vector;
    }

    public static MatrixImmutable Rotate2D(MatrixImmutable matrix, double degrees)
    {
        return Rotate2D(matrix, (float)degrees);
    }

    public static MatrixImmutable Rotate2D(MatrixImmutable matrix, float degrees)
    {
        var vectorsLength = matrix.Vectors.Length;
        var newVectors = new VectorImmutable[vectorsLength];
        for (var index = 0; index < vectorsLength; index++)
        {
            var vector = matrix.Vectors[index];
            EnsureVectorIs2D(vector);
            newVectors[index] = RotateVector2D(vector, degrees);
        }

        return new MatrixImmutable(newVectors);
    }

    public static MatrixImmutable DegreesToRotationMatrix3D(Axis axis, float degrees)
    {
        var angle = Calculator.ConvertToRadians(degrees);
        var cosAlfa = (float)Math.Cos(angle);
        var sinALfa = (float)Math.Sin(angle);

        return axis switch
        {
            Axis.X => new MatrixImmutable(
                new VectorImmutable(1, 0, 0),
                new VectorImmutable(0, cosAlfa, -sinALfa),
                new VectorImmutable(0, sinALfa, cosAlfa)
            ),
            Axis.Y => new MatrixImmutable(
                new VectorImmutable(cosAlfa, 0, sinALfa),
                new VectorImmutable(0, 1, 0),
                new VectorImmutable(sinALfa, 0, cosAlfa)
            ),
            _ => new MatrixImmutable(
                new VectorImmutable(cosAlfa, -sinALfa, 0),
                new VectorImmutable(sinALfa, cosAlfa, 0),
                new VectorImmutable(0, 0, 1)
            )
        };
    }

    public static VectorImmutable RotateVector3D(Axis axis, VectorImmutable vector, float degrees)
    {
        return DegreesToRotationMatrix3D(axis, degrees) * vector;
    }

    public static MatrixImmutable Rotate3D(Axis axis, MatrixImmutable matrix, double degrees)
    {
        return Rotate3D(axis, matrix, (float)degrees);
    }

    public static MatrixImmutable Rotate3D(Axis axis, MatrixImmutable matrix, float degrees)
    {
        var vectorsLength = matrix.Vectors.Length;
        var newVectors = new VectorImmutable[vectorsLength];
        for (var index = 0; index < vectorsLength; index++)
        {
            var vector = matrix.Vectors[index];
            EnsureVectorIs3D(vector);
            newVectors[index] = RotateVector3D(axis, vector, degrees);
        }

        return new MatrixImmutable(newVectors);
    }
    
    public static MatrixImmutable VectorToTranslationMatrix3D(VectorImmutable vector)
    {
        EnsureVectorIs2D(vector);
        
        return new MatrixImmutable(
            new VectorImmutable(1, 0, vector.X),
            new VectorImmutable(0, 1, vector.Y),
            new VectorImmutable(0, 0, 1)
        );
    }

    public static MatrixImmutable Translate3D(MatrixImmutable matrix, VectorImmutable vector)
    {
        var translationMatrix = VectorToTranslationMatrix3D(vector);
        var vectorsLength = matrix.Vectors.Length;
        var newVectors = new VectorImmutable[vectorsLength];
        for (var index = 0; index < vectorsLength; index++)
        {
            var matrixVector = matrix.Vectors[index];
            EnsureVectorIs3D(matrixVector);
            newVectors[index] = translationMatrix * matrixVector;
        }

        return new MatrixImmutable(newVectors);
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        var delimiter = "";
        foreach (var vector in Vectors)
        {
            result.Append(delimiter);
            result.Append(vector);
            delimiter = ",";
        }

        return "{" + $"{result}" + "}";
    }

    public int Length()
    {
        return Vectors.Length;
    }

    public bool IsEmpty()
    {
        return Length() < 1 || Vectors[0].IsEmpty();
    }
    private static void EnsureIndexWithinBounds(IReadOnlyCollection<float> values, int index)
    {
        if (index >= values.Count || index < 0)
        {
            throw new MatrixIndexOutOfBoundsException();
        }
    }

    private static void EnsureVectorsHaveEqualDimensions(VectorImmutable left, VectorImmutable right)
    {
        if (left.Positions.Length != right.Positions.Length)
        {
            throw new MatrixDifferentVectorsDimensionsException();
        }
    }

    private static void EnsureMatrixVectorsHaveEqualVectorDimensions(IReadOnlyCollection<VectorImmutable> vectors, VectorImmutable? vector)
    {
        if (vectors.Count != vector?.Length())
        {
            throw new MatrixVectorsLengthNotEqualToVectorDimensionsException();
        }
    }

    private static void EnsureMatrixVectorsLengthEqual(MatrixImmutable left, MatrixImmutable right)
    {
        if (left.Vectors.Length != right.Vectors.Length)
        {
            throw new MatrixVectorsLengthNotEqualException();
        }
    }

    private static void EnsureVectorLeftColumnsAreEqualToMatrixRightRows(VectorImmutable left, MatrixImmutable right)
    {
        if (left.Length() != right.Length())
        {
            throw new MatrixLeftColumnsAreNotEqualToMatrixRightRows();
        }
    }

    private static void EnsureVectorIs2D(VectorImmutable vector)
    {
        if (vector.Length() == 2)
        {
            return;
        }

        throw new MatrixVectorsNot2DException();
    }

    private static void EnsureVectorIs3D(VectorImmutable vector)
    {
        if (vector.Length() == 3)
        {
            return;
        }

        throw new MatrixVectorsNot3DException();
    }
}

public enum Axis
{
    X,
    Y,
    Z
}

public class MatrixIndexOutOfBoundsException : Exception
{

}

public class MatrixDifferentVectorsDimensionsException : Exception
{

}

public class MatrixVectorsLengthNotEqualToVectorDimensionsException : Exception
{

}

public class MatrixVectorsLengthNotEqualException : Exception
{

}

public class MatrixLeftColumnsAreNotEqualToMatrixRightRows : Exception
{

}

public class MatrixVectorsNot2DException : Exception
{

}

public class MatrixVectorsNot3DException : Exception
{

}
