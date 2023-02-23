using Src;

namespace MatrixTransformations;

public class AxisX
{
    private int _size;
    public readonly List<VectorImmutable> VertexBuffer;

    public AxisX(int size = 100)
    {
        _size = size;
        VertexBuffer = new List<VectorImmutable>
        {
            new(0, 0),
            new(size, 0)
        };
    }

    public static void Draw(Graphics graphics, List<VectorImmutable> vectors)
    {
        var pen = new Pen(Color.Red, 2f);
        graphics.DrawLine(pen, vectors[0].X, vectors[0].Y, vectors[1].X, vectors[1].Y);
        var font = new Font("Arial", 10);
        var pointF = new PointF(vectors[1].X, vectors[1].Y);
        graphics.DrawString("x", font, Brushes.Red, pointF);
    }
}
