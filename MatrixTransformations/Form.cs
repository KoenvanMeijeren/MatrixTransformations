using System.Drawing.Drawing2D;
using Src;

namespace MatrixTransformations;

public partial class Form : System.Windows.Forms.Form
{
    // Window dimensions
    public const int FormWidth = 800;
    public const int FormHeight = 600;

    // Axes
    private readonly AxisX _xAxis;
    private readonly AxisY _yAxis;

    // Objects
    private readonly Square _square;
        
    public Form()
    {
        InitializeComponent();

        Width = FormWidth;
        Height = FormHeight;
        DoubleBuffered = true;

        var vector1 = new VectorImmutable();
        Console.WriteLine(vector1);
        var vector2 = new VectorImmutable(1, 2);
        Console.WriteLine(vector2);
        var vector3 = new VectorImmutable(2, 6);
        Console.WriteLine(vector3);
        var vector4 = vector2 + vector3;
        Console.WriteLine(vector4); // 3, 8

        var vector5 = new VectorImmutable(2, 2);
        var matrix1 = new MatrixImmutable(vector5, vector5);
        var matrixIdentity = MatrixImmutable.Identity(matrix1);
        Console.WriteLine(matrixIdentity); // 1, 0, 0, 1

        var vector6 = new VectorImmutable(2, 4);
        var vector7 = new VectorImmutable(-1, 3);
        var matrix2 = new MatrixImmutable(vector6, vector7);
        Console.WriteLine(matrix2);
        Console.WriteLine(matrixIdentity + matrix2); // 3, 4, -1, 4
        Console.WriteLine(matrixIdentity - matrix2); // -1, -4, 1, -2
        Console.WriteLine(matrix2 * matrix2); // 0, 20, -5, 5

        Console.WriteLine(matrix2 * vector3); // 28, 16
        
        // Define axes
        _xAxis = new AxisX(200); 
        _yAxis = new AxisY(200);

        // Create objects
        _square = new Square(Color.Purple);
    }

    protected override void OnPaint(PaintEventArgs eventArgs)
    {
        base.OnPaint(eventArgs);

        var graphics = new GraphicsHelper(eventArgs.Graphics);
        
        AxisX.Draw(graphics, _xAxis.VertexBuffer);
        AxisY.Draw(graphics, _yAxis.VertexBuffer);
        _square.Draw(graphics, _square.VertexBuffer);
    }

    private void Form1_KeyDown(object sender, KeyEventArgs eventArgs)
    {
        if (eventArgs.KeyCode == Keys.Escape)
        {
            Application.Exit();
        }
    }
}
