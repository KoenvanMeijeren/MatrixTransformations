using System.Diagnostics.CodeAnalysis;
using Src;

namespace MatrixTransformations;

[ExcludeFromCodeCoverage]
public partial class MatrixForm : Form
{
    // Window dimensions
    public const int DefaultFormWidth = 800, DefaultFormHeight = 600;
    private int _formWidth = DefaultFormWidth,
        _formWidthMaximum = DefaultFormWidth / 2,
        _formHeight = DefaultFormHeight,
        _formHeightMaximum = DefaultFormHeight / 2;
    private const int DefaultAxisSize = 200;

    // Object position settings
    private const double DefaultSquareScale = 1.5,
        DefaultSquareRotationDegrees = 20,
        DefaultSquareTranslationX = 75,
        DefaultSquareTranslationY = -25;

    private double _squareScale = DefaultSquareScale,
        _squareRotationDegrees = DefaultSquareRotationDegrees,
        _squareTranslationX = DefaultSquareTranslationX,
        _squareTranslationY = DefaultSquareTranslationY;

    // Axes
    private readonly AxisX _axisX;
    private readonly AxisY _axisY;
    private readonly AxisZ _axisZ;

    // Objects
    private readonly Square _square, _squareBackup,
        _squareScaled, _squareScaledBackup,
        _squareRotated, _squareRotatedBackup,
        _squareTranslated, _squareTranslatedBackup;

    private readonly Cube _cube, _cubeBackup;

    public MatrixForm()
    {
        InitializeComponent();

        Width = _formWidth;
        Height = _formHeight;
        DoubleBuffered = true;
        SizeChanged += (sender, args) =>
        {
            _formWidth = Width;
            _formWidthMaximum = Width / 2;
            _formHeight = Height;
            _formHeightMaximum = Height / 2;
            Refresh();
        };

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
        _axisX = new AxisX(DefaultAxisSize);
        _axisY = new AxisY(DefaultAxisSize);
        _axisZ = new AxisZ(DefaultAxisSize);

        // Create objects
        _square = new Square(Color.Purple);
        _squareBackup = new Square(Color.Purple);
        _squareScaled = new Square(Color.Cyan);
        _squareScaledBackup = new Square(Color.Cyan);
        _squareRotated = new Square(Color.Orange);
        _squareRotatedBackup = new Square(Color.Orange);
        _squareTranslated = new Square(Color.DarkBlue);
        _squareTranslatedBackup = new Square(Color.DarkBlue);
        _cube = new Cube(Color.Purple);
        _cubeBackup = new Cube(Color.Purple);
    }

    protected override void OnPaint(PaintEventArgs eventArgs)
    {
        base.OnPaint(eventArgs);

        var graphics = new GraphicsHelper(eventArgs.Graphics, _formWidth, _formHeight);

        AxisX.Draw(graphics, _axisX.Matrix);
        AxisY.Draw(graphics, _axisY.Matrix);
        AxisZ.Draw(graphics, _axisZ.Matrix);

        _square.Draw(graphics, _square.Matrix);

        _squareScaled.Matrix = MatrixImmutable.Scale(_squareScaledBackup.Matrix, _squareScale);
        _squareScaled.Draw(graphics, _squareScaled.Matrix);

        _squareRotated.Matrix = MatrixImmutable.Rotate3D(Axis.Z, _squareRotatedBackup.Matrix, _squareRotationDegrees);
        _squareRotated.Draw(graphics, _squareRotated.Matrix);

        _squareTranslated.Matrix = MatrixImmutable.Translate3D(
            _squareTranslatedBackup.Matrix,
            new VectorImmutable((float)_squareTranslationX, (float)_squareTranslationY)
        );
        _squareTranslated.Draw(graphics, _squareTranslated.Matrix);

        _cube.Draw(graphics, _cube.Matrix);
    }

    private void Form_KeyDown(object sender, KeyEventArgs eventArgs)
    {
        if (eventArgs.KeyCode == Keys.Escape)
        {
            Application.Exit();
            return;
        }

        switch (eventArgs.KeyCode)
        {
            case Keys.Add:
                _squareRotationDegrees += 5;
                Refresh();
                break;
            case Keys.Subtract:
                _squareRotationDegrees -= 5;
                Refresh();
                break;
            case Keys.S:
                if (eventArgs.Modifiers == Keys.Control)
                {
                    _squareScale -= 0.2;
                    if (_squareScale <= 0)
                    {
                        _squareScale = DefaultSquareScale;
                    }
                    Refresh();
                    break;
                }

                _squareScale += 0.2;
                if (_squareScale >= 3)
                {
                    _squareScale = DefaultSquareScale;
                }

                Refresh();
                break;
            case Keys.Up:
                _squareTranslationY += 2;
                if (_squareTranslationY > _formHeightMaximum)
                {
                    _squareTranslationY = DefaultSquareTranslationY;
                }
                Refresh();
                break;
            case Keys.Down:
                _squareTranslationY -= 2;
                if (_squareTranslationY <= -_formHeightMaximum)
                {
                    _squareTranslationY = DefaultSquareTranslationY;
                }
                Refresh();
                break;
            case Keys.Right:
                _squareTranslationX += 2;
                if (_squareTranslationX > _formWidthMaximum)
                {
                    _squareTranslationX = DefaultSquareTranslationX;
                }
                Refresh();
                break;
            case Keys.Left:
                _squareTranslationX -= 2;
                if (_squareTranslationX <= -_formWidthMaximum)
                {
                    _squareTranslationX = DefaultSquareTranslationX;
                }
                Refresh();
                break;
            default:
                break;
        }
    }
}
