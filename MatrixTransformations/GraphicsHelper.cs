using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace MatrixTransformations
{
    [ExcludeFromCodeCoverage]
    public class GraphicsHelper
    {
        private readonly int _width;
        private readonly int _height;
        public readonly Graphics Graphics;

        public GraphicsHelper(Graphics graphics, int width = MatrixForm.DefaultFormWidth, int height = MatrixForm.DefaultFormHeight)
        {
            _width = width;
            _height = height;
            Graphics = graphics;
        }

        public void DrawLine(Pen pen, float x1, float y1, float x2, float y2)
        {
            x1 = TranslateX(x1);
            x2 = TranslateX(x2);
            y1 = TranslateY(y1);
            y2 = TranslateY(y2);

            Graphics.DrawLine(pen, x1, y1, x2, y2);
        }

        public float TranslateX(float x)
        {
            return x + (_width / 2);
        }

        public float TranslateY(float y)
        {
            return (_height / 2) - y;
        }
    }
}
