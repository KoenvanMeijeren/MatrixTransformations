using System.Globalization;
using System.Text;

namespace Src;

public class VectorImmutable
{
    public readonly float[] Positions;

    public float X => Positions[0];
    public float Y => Positions[1];
    public float Z => Positions[2];
    public float W => Positions[3];

    public VectorImmutable(params float[] positions)
    {
        Positions = positions;
    }

    public static VectorImmutable operator + (VectorImmutable left, VectorImmutable right)
    {
        EnsureVectorsAreEqual(left, right);

        var newPositions = new float[left.Positions.Length];
        for (var index = 0; index < newPositions.Length; index++)
        {
            newPositions[index] = left.Positions[index] + right.Positions[index];
        }
        
        return new VectorImmutable(newPositions);
    }

    public static VectorImmutable operator +(VectorImmutable vector, float value)
    {
        var newPositions = new float[vector.Positions.Length];
        for (var index = 0; index < newPositions.Length; index++)
        {
            newPositions[index] = vector.Positions[index] + value;
        }
        
        return new VectorImmutable(newPositions);
    }

    public static VectorImmutable operator +(float value, VectorImmutable vector)
    {
        return vector + value;
    }
    
    public static VectorImmutable operator - (VectorImmutable left, VectorImmutable right)
    {
        EnsureVectorsAreEqual(left, right);

        var newPositions = new float[left.Positions.Length];
        for (var index = 0; index < newPositions.Length; index++)
        {
            newPositions[index] = left.Positions[index] - right.Positions[index];
        }
        
        return new VectorImmutable(newPositions);
    }
    
    public static VectorImmutable operator -(VectorImmutable vector, float value)
    {
        var newPositions = new float[vector.Positions.Length];
        for (var index = 0; index < newPositions.Length; index++)
        {
            newPositions[index] = vector.Positions[index] - value;
        }
        
        return new VectorImmutable(newPositions);
    }

    public static VectorImmutable operator -(float value, VectorImmutable vector)
    {
        return vector - value;
    }
    
    public static VectorImmutable operator * (VectorImmutable left, VectorImmutable right)
    {
        EnsureVectorsAreEqual(left, right);

        var newPositions = new float[left.Positions.Length];
        for (var index = 0; index < newPositions.Length; index++)
        {
            newPositions[index] = left.Positions[index] * right.Positions[index];
        }
        
        return new VectorImmutable(newPositions);
    }
    
    public static VectorImmutable operator * (VectorImmutable vector, float multiply)
    {
        var newPositions = new float[vector.Positions.Length];
        for (var index = 0; index < newPositions.Length; index++)
        {
            newPositions[index] = vector.Positions[index] * multiply;
        }
        
        return new VectorImmutable(newPositions);
    }
    
    public static VectorImmutable operator * (float multiply, VectorImmutable vector)
    {
        return vector * multiply;
    }

    public static VectorImmutable operator / (VectorImmutable left, VectorImmutable right)
    {
        EnsureVectorsAreEqual(left, right);

        var newPositions = new float[left.Positions.Length];
        for (var index = 0; index < newPositions.Length; index++)
        {
            if (left.Positions[index] == 0 || right.Positions[index] == 0)
            {
                newPositions[index] = 0;
                continue;
            }
            
            newPositions[index] = left.Positions[index] / right.Positions[index];
        }
        
        return new VectorImmutable(newPositions);
    }
    
    public static VectorImmutable operator / (VectorImmutable vector, float divider)
    {
        if (divider == 0 || divider == 0.0)
        {
            throw new ArithmeticException("Cannot divide vector by zero!");
        }
        
        var newPositions = new float[vector.Positions.Length];
        for (var index = 0; index < newPositions.Length; index++)
        {
            newPositions[index] = vector.Positions[index] / divider;
        }
        
        return new VectorImmutable(newPositions);
    }
    
    public static VectorImmutable operator / (float divider, VectorImmutable vector)
    {
        if (divider == 0 || divider == 0.0)
        {
            throw new ArithmeticException("Cannot divide vector by zero!");
        }
        
        var newPositions = new float[vector.Positions.Length];
        for (var index = 0; index < newPositions.Length; index++)
        {
            newPositions[index] = divider / vector.Positions[index];
        }
        
        return new VectorImmutable(newPositions);
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        var delimiter = "";
        foreach (var position in Positions)
        {
            result.Append(delimiter);
            result.Append(Math.Round(position, 2).ToString(CultureInfo.InvariantCulture));
            delimiter = ",";
        }
        
        return $"({result})";
    }

    public int Length()
    {
        return Positions.Length;
    }

    public bool IsEmpty()
    {
        return Length() < 1;
    }

    private static void EnsureVectorsAreEqual(VectorImmutable left, VectorImmutable right) {
        if (left.Positions.Length == right.Positions.Length)
        {
            return;
        }
        
        throw new VectorsAreNotEqualException();
    }
}

public class VectorsAreNotEqualException : Exception
{
    
}