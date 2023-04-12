using System.Drawing;
using Src;

namespace MatrixTransformations
{
    public class AxisY
    {
        private readonly int _size;
        public MatrixImmutable Matrix { get; set; }

        public AxisY(int size = 100)
        {
            _size = size;
            Matrix = new MatrixImmutable(
                new(0, 0, 0, 1),
                new(0, size, 0, 1),
                new(0, 0, 0, 1),
                new(0, 0, 0, 1)
            );
        }

        public static void Draw(GraphicsHelper graphicsHelper, MatrixImmutable matrix)
        {
            var vectors = matrix.Vectors;
            var pen = new Pen(Color.Green, 2f);
            graphicsHelper.DrawLine(pen, vectors[0].X, vectors[0].Y, vectors[1].X, vectors[1].Y);
            var font = new Font("Arial", 10);
            var pointF = new PointF(
                graphicsHelper.TranslateX(vectors[1].X),
                graphicsHelper.TranslateY(vectors[1].Y)
            );
            graphicsHelper.Graphics.DrawString("y", font, Brushes.Green, pointF);
        }
    }
}
