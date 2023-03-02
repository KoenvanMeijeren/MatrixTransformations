using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Src;

namespace MatrixTransformations;

[ExcludeFromCodeCoverage]
public partial class MatrixForm : Form
{
    // Window dimensions
    public const int DefaultFormWidth = 800, DefaultFormHeight = 600;
    private int _formWidth = DefaultFormWidth, _formHeight = DefaultFormHeight;
    private const int DefaultAxisSize = 200;

    // Object position settings
    private const double DefaultTranslateX = 0, DefaultTranslateY = 0, DefaultTranslateZ = 0;

    private const int DefaultScale = 1,
        DefaultRotateX = 30, DefaultRotateY = 10, DefaultRotateZ = 0,
        DefaultRadius = 10,
        DefaultDistance = 800,
        DefaultPhi = 10,
        DefaultTheta = 100,
        DefaultStepSize = 1,
        DefaultPhase = 0;

    private const double ScaleStepSize = 0.1,
        TranslateStepSize = 0.1;

    private const int RotateStepSize = DefaultStepSize,
        RadiusStepSize = DefaultStepSize,
        DistanceStepSize = DefaultStepSize,
        PhiStepSize = DefaultStepSize,
        ThetaStepSize = DefaultStepSize;

    private double _scale = DefaultScale,
        _translateX = DefaultTranslateX, _translateY = DefaultTranslateY, _translateZ = DefaultTranslateZ;
    private int _phase = DefaultPhase,
        _rotateX = DefaultRotateX, _rotateY = DefaultRotateY, _rotateZ = DefaultRotateZ,
        _radius = DefaultRadius,
        _distance = DefaultDistance,
        _phi = DefaultPhi,
        _theta = DefaultTheta;

    // Axes
    private readonly AxisX _axisX, _axisXBackup;
    private readonly AxisY _axisY, _axisYBackup;

    // Objects
    private readonly Cube _cube, _cubeBackup;

    public MatrixForm()
    {
        InitializeComponent();
        SetInitialValuesToControls();

        Width = _formWidth;
        Height = _formHeight;
        DoubleBuffered = true;
        SizeChanged += (sender, args) =>
        {
            _formWidth = Width;
            _formHeight = Height;
            Refresh();
        };

        // Define axes
        _axisX = new AxisX(DefaultAxisSize);
        _axisXBackup = new AxisX(DefaultAxisSize);
        _axisY = new AxisY(DefaultAxisSize);
        _axisYBackup = new AxisY(DefaultAxisSize);

        // Create objects
        _cube = new Cube(Color.Purple);
        _cubeBackup = new Cube(Color.Purple);
    }

    protected override void OnPaint(PaintEventArgs eventArgs)
    {
        base.OnPaint(eventArgs);

        var graphics = new GraphicsHelper(eventArgs.Graphics, _formWidth, _formHeight);

        AxisX.Draw(graphics, _axisX.Matrix);
        AxisY.Draw(graphics, _axisY.Matrix);

        _cube.Matrix = MatrixImmutable.Scale(_cubeBackup.Matrix, _scale);
        _cube.Matrix = MatrixImmutable.Rotate4D(Axis.X, _cube.Matrix, _rotateX);
        _cube.Matrix = MatrixImmutable.Rotate4D(Axis.Y, _cube.Matrix, _rotateY);
        _cube.Matrix = MatrixImmutable.Rotate4D(Axis.Z, _cube.Matrix, _rotateZ);
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
            case Keys.C:
                HandleReset();
                break;
            case Keys.S:
                HandleScaleControl(eventArgs);
                break;
            case Keys.Left:
            case Keys.Right:
                HandleTranslateControl(Axis.X, eventArgs);
                break;
            case Keys.Up:
            case Keys.Down:
                HandleTranslateControl(Axis.Y, eventArgs);
                break;
            case Keys.PageUp:
            case Keys.PageDown:
                HandleTranslateControl(Axis.Z, eventArgs);
                break;
            case Keys.X:
                HandleRotateControl(Axis.X, eventArgs);
                break;
            case Keys.Y:
                HandleRotateControl(Axis.Y, eventArgs);
                break;
            case Keys.Z:
                HandleRotateControl(Axis.Z, eventArgs);
                break;
            case Keys.R:
                HandleRadiusControl(eventArgs);
                break;
            case Keys.D:
                HandleDistanceControl(eventArgs);
                break;
            case Keys.P:
                HandlePhiControl(eventArgs);
                break;
            case Keys.T:
                HandleThetaControl(eventArgs);
                break;
            default:
                break;
        }
    }

    private void HandleReset()
    {
        _translateX = DefaultTranslateX;
        _translateY = DefaultTranslateY;
        _translateZ = DefaultTranslateZ;

        _scale = DefaultScale;
        _rotateX = DefaultRotateX;
        _rotateY = DefaultRotateY;
        _rotateZ = DefaultRotateZ;
        _radius = DefaultRadius;
        _distance = DefaultDistance;
        _phi = DefaultPhi;
        _theta = DefaultTheta;

        Refresh();
        SetInitialValuesToControls();
    }

    private void HandleScaleControl(KeyEventArgs eventArgs)
    {
        if (eventArgs.Modifiers == Keys.Shift)
        {
            _scale -= ScaleStepSize;
        }
        else
        {
            _scale += ScaleStepSize;
        }

        scaleValue.Text = Math.Round(_scale, 2).ToString(CultureInfo.InvariantCulture);
        Refresh();
    }

    private void HandleTranslateControl(Axis axis, KeyEventArgs eventArgs)
    {
        switch (axis)
        {
            case Axis.X:
                if (eventArgs.KeyCode == Keys.Left)
                {
                    _translateX -= TranslateStepSize;
                }
                else
                {
                    _translateX += TranslateStepSize;
                }

                translateXValue.Text = Math.Round(_translateX, 2).ToString(CultureInfo.InvariantCulture);
                break;
            case Axis.Y:
                if (eventArgs.KeyCode == Keys.Down)
                {
                    _translateY -= TranslateStepSize;
                }
                else
                {
                    _translateY += TranslateStepSize;
                }

                translateYValue.Text = Math.Round(_translateY, 2).ToString(CultureInfo.InvariantCulture);
                break;
            case Axis.Z:
                if (eventArgs.KeyCode == Keys.PageDown)
                {
                    _translateZ -= TranslateStepSize;
                }
                else
                {
                    _translateZ += TranslateStepSize;
                }

                translateZValue.Text = Math.Round(_translateZ, 2).ToString(CultureInfo.InvariantCulture);
                break;
        }

        Refresh();
    }

    private void HandleRotateControl(Axis axis, KeyEventArgs eventArgs)
    {
        switch (axis)
        {
            case Axis.X:
                if (eventArgs.Modifiers == Keys.Shift)
                {
                    _rotateX -= RotateStepSize;
                }
                else
                {
                    _rotateX += RotateStepSize;
                }

                rotateXValue.Text = _rotateX.ToString(CultureInfo.InvariantCulture);
                break;
            case Axis.Y:
                if (eventArgs.Modifiers == Keys.Shift)
                {
                    _rotateY -= RotateStepSize;
                }
                else
                {
                    _rotateY += RotateStepSize;
                }

                rotateYValue.Text = _rotateY.ToString(CultureInfo.InvariantCulture);
                break;
            case Axis.Z:
                if (eventArgs.Modifiers == Keys.Shift)
                {
                    _rotateZ -= RotateStepSize;
                }
                else
                {
                    _rotateZ += RotateStepSize;
                }

                rotateZValue.Text = _rotateZ.ToString(CultureInfo.InvariantCulture);
                break;
        }

        Refresh();
    }

    private void HandleRadiusControl(KeyEventArgs eventArgs)
    {
        if (eventArgs.Modifiers == Keys.Shift)
        {
            _radius -= RadiusStepSize;
        }
        else
        {
            _radius += RadiusStepSize;
        }

        radiusValue.Text = _radius.ToString(CultureInfo.InvariantCulture);
        Refresh();
    }

    private void HandleDistanceControl(KeyEventArgs eventArgs)
    {
        if (eventArgs.Modifiers == Keys.Shift)
        {
            _distance -= DistanceStepSize;
        }
        else
        {
            _distance += DistanceStepSize;
        }

        distanceValue.Text = _distance.ToString(CultureInfo.InvariantCulture);
        Refresh();
    }

    private void HandlePhiControl(KeyEventArgs eventArgs)
    {
        if (eventArgs.Modifiers == Keys.Shift)
        {
            _phi -= PhiStepSize;
        }
        else
        {
            _phi += PhiStepSize;
        }

        phiValue.Text = _phi.ToString(CultureInfo.InvariantCulture);
        Refresh();
    }

    private void HandleThetaControl(KeyEventArgs eventArgs)
    {
        if (eventArgs.Modifiers == Keys.Shift)
        {
            _theta -= ThetaStepSize;
        }
        else
        {
            _theta += ThetaStepSize;
        }

        thetaValue.Text = _theta.ToString(CultureInfo.InvariantCulture);
        Refresh();
    }

    private void SetInitialValuesToControls()
    {
        scaleValue.Text = Math.Round(_scale, 2).ToString(CultureInfo.InvariantCulture);
        translateXValue.Text = Math.Round(_translateX, 2).ToString(CultureInfo.InvariantCulture);
        translateYValue.Text = Math.Round(_translateY, 2).ToString(CultureInfo.InvariantCulture);
        translateZValue.Text = Math.Round(_translateZ, 2).ToString(CultureInfo.InvariantCulture);
        rotateXValue.Text = _rotateX.ToString(CultureInfo.InvariantCulture);
        rotateYValue.Text = _rotateY.ToString(CultureInfo.InvariantCulture);
        rotateZValue.Text = _rotateZ.ToString(CultureInfo.InvariantCulture);
        radiusValue.Text = _radius.ToString(CultureInfo.InvariantCulture);
        distanceValue.Text = _distance.ToString(CultureInfo.InvariantCulture);
        phiValue.Text = _phi.ToString(CultureInfo.InvariantCulture);
        thetaValue.Text = _theta.ToString(CultureInfo.InvariantCulture);
        phaseValue.Text = _phase.ToString(CultureInfo.InvariantCulture);
    }
}
