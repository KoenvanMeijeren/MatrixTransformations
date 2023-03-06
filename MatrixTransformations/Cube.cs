using Src;

namespace MatrixTransformations
{
    public class Cube
    {

        //          7----------4
        //         /|         /|
        //        / |        / |                y
        //       /  6-------/--5                |
        //      3----------0  /                 ----x
        //      | /        | /                 /
        //      |/         |/                  z
        //      2----------1

        private const int Size = 1;
        public MatrixImmutable Matrix { get; set; }

        private readonly Color _color;

        public Cube(Color color)
        {
            _color = color;
            Matrix = new MatrixImmutable(
                new VectorImmutable(1.0f, 1.0f, 1.0f, 1), //0
                new VectorImmutable(1.0f, -1.0f, 1.0f, 1), //1
                new VectorImmutable(-1.0f, -1.0f, 1.0f, 1), //2
                new VectorImmutable(-1.0f, 1.0f, 1.0f, 1), //3

                new VectorImmutable(1.0f, 1.0f, -1.0f, 1), //4
                new VectorImmutable(1.0f, -1.0f, -1.0f, 1), //5
                new VectorImmutable(-1.0f, -1.0f, -1.0f, 1), //6
                new VectorImmutable(-1.0f, 1.0f, -1.0f, 1), //7

                new VectorImmutable(1.2f, 1.2f, 1.2f, 1), //0
                new VectorImmutable(1.2f, -1.2f, 1.2f, 1), //1
                new VectorImmutable(-1.2f, -1.2f, 1.2f, 1), //2
                new VectorImmutable(-1.2f, 1.2f, 1.2f, 1), //3

                new VectorImmutable(1.2f, 1.2f, -1.2f, 1), //4
                new VectorImmutable(1.2f, -1.2f, -1.2f, 1), //5
                new VectorImmutable(-1.2f, -1.2f, -1.2f, 1), //6
                new VectorImmutable(-1.2f, 1.2f, -1.2f, 1) //7
            );

            Matrix *= Size;
        }

        public void Draw(GraphicsHelper graphicsHelper, MatrixImmutable matrix)
        {
            var vectors = matrix.Vectors;
            var graphics = graphicsHelper.Graphics;
            var pen = new Pen(_color, 2f);
            var brush = new SolidBrush(Color.Black);

            graphicsHelper.DrawLine(pen, vectors[0].X, vectors[0].Y, vectors[1].X, vectors[1].Y);    //0 -> 1
            graphicsHelper.DrawLine(pen, vectors[1].X, vectors[1].Y, vectors[2].X, vectors[2].Y);    //1 -> 2
            graphicsHelper.DrawLine(pen, vectors[2].X, vectors[2].Y, vectors[3].X, vectors[3].Y);    //2 -> 3
            graphicsHelper.DrawLine(pen, vectors[3].X, vectors[3].Y, vectors[0].X, vectors[0].Y);    //3 -> 0

            graphicsHelper.DrawLine(pen, vectors[4].X, vectors[4].Y, vectors[5].X, vectors[5].Y);    //4 -> 5
            graphicsHelper.DrawLine(pen, vectors[5].X, vectors[5].Y, vectors[6].X, vectors[6].Y);    //5 -> 6
            graphicsHelper.DrawLine(pen, vectors[6].X, vectors[6].Y, vectors[7].X, vectors[7].Y);    //6 -> 7
            graphicsHelper.DrawLine(pen, vectors[7].X, vectors[7].Y, vectors[4].X, vectors[4].Y);    //7 -> 4

            //pen.DashStyle = DashStyle.DashDot;
            graphicsHelper.DrawLine(pen, vectors[0].X, vectors[0].Y, vectors[4].X, vectors[4].Y);    //0 -> 4
            graphicsHelper.DrawLine(pen, vectors[1].X, vectors[1].Y, vectors[5].X, vectors[5].Y);    //1 -> 5
            graphicsHelper.DrawLine(pen, vectors[2].X, vectors[2].Y, vectors[6].X, vectors[6].Y);    //2 -> 6
            graphicsHelper.DrawLine(pen, vectors[3].X, vectors[3].Y, vectors[7].X, vectors[7].Y);    //3 -> 7

            var font = new Font("Arial", 12, FontStyle.Bold);
            for (var index = 0; index < 8; index++)
            {
                var pointF = new PointF(
                    graphicsHelper.TranslateX(vectors[index + 8].X),
                    graphicsHelper.TranslateY(vectors[index + 8].Y)
                );
                graphics.DrawString(index.ToString(), font, brush, pointF);
            }
        }
    }
}
