using System.Text;

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

    public static MatrixImmutable Identity(MatrixImmutable matrix, float value = 1)
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
            positions[identityIndex++] = value;
            vectors[vectorIndex++] = new VectorImmutable(positions);
            previousVector = vector;
        }
        
        EnsureMatrixVectorsHaveEqualVectorDimensions(vectors, previousVector);

        return new MatrixImmutable(vectors);
    }

    public static MatrixImmutable operator + (MatrixImmutable left, MatrixImmutable right)
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
    
    public static MatrixImmutable operator - (MatrixImmutable left, MatrixImmutable right)
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
    
    public static MatrixImmutable operator * (MatrixImmutable matrix, float multiply)
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
    
    public static MatrixImmutable operator * (float multiply, MatrixImmutable matrix)
    {
        return matrix * multiply;
    }

    public static MatrixImmutable operator * (MatrixImmutable left, MatrixImmutable right)
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
    
    public static VectorImmutable operator * (MatrixImmutable matrix, VectorImmutable vector)
    {
        var vectors = new VectorImmutable[vector.Length()];
        for (var index = 0; index < vector.Length(); index++)
        {
            vectors[index] = new VectorImmutable(vector.Positions[index]);
        }
        
        var vectorMatrix = new MatrixImmutable(vectors);
        
        return ToVector(matrix * vectorMatrix, 0);
    }
    
    public static MatrixImmutable operator * (VectorImmutable vector, MatrixImmutable matrix)
    {
        var vectors = new[] {vector};
        var vectorMatrix = new MatrixImmutable(vectors);
        
        return vectorMatrix * matrix;
    }

    public static MatrixImmutable Scale(MatrixImmutable matrix, float scale)
    {
        return Identity(matrix, scale) * matrix;
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
