using Src;

namespace MatrixTransformations;

public class Square
{
    private readonly Color _color;
    private int _size;
    private readonly float _weight;

    public MatrixImmutable Matrix { get; set; }

    public Square(Color color, int size = 100, float weight = 3)
    {
        _color = color;
        _size = size;
        _weight = weight;

        Matrix = new MatrixImmutable(
            new(-size, -size),
            new(size, -size),
            new(size, size),
            new(-size, size)
        );
    }

    public void Draw(GraphicsHelper graphics, MatrixImmutable matrix)
    {
        var vectors = matrix.Vectors;
        var pen = new Pen(_color, _weight);
        graphics.DrawLine(pen, vectors[0].X, vectors[0].Y, vectors[1].X, vectors[1].Y);
        graphics.DrawLine(pen, vectors[1].X, vectors[1].Y, vectors[2].X, vectors[2].Y);
        graphics.DrawLine(pen, vectors[2].X, vectors[2].Y, vectors[3].X, vectors[3].Y);
        graphics.DrawLine(pen, vectors[3].X, vectors[3].Y, vectors[0].X, vectors[0].Y);
    }
}
