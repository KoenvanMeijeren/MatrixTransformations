using System.Numerics;
using Src;

namespace MatrixTransformations;

public class AxisZ
{
    private int _size;
    public MatrixImmutable Matrix { get; set; }

    public AxisZ(int size = 100)
    {
        _size = size;

        Matrix = new MatrixImmutable(
            new VectorImmutable(0, 0, 1),
            new VectorImmutable(0, 0, size)
        );
    }

    public static void Draw(GraphicsHelper graphicsHelper, MatrixImmutable matrix)
    {
        var vectors = matrix.Vectors;
        var graphics = graphicsHelper.Graphics;
        var pen = new Pen(Color.Blue, 2f);
        graphicsHelper.DrawLine(pen, vectors[0].X, vectors[0].Y, vectors[1].X, vectors[1].Y);
        var font = new Font("Arial", 10);
        var pointF = new PointF(
            graphicsHelper.TranslateX(vectors[1].X),
            graphicsHelper.TranslateY(vectors[1].Y)
        );
        graphics.DrawString("z", font, Brushes.Blue, pointF);
    }
}
