using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Timers;
using Src;
using Timer = System.Timers.Timer;

namespace MatrixTransformations;

[ExcludeFromCodeCoverage]
public partial class MatrixForm : Form
{
    // Window dimensions
    public const int DefaultFormWidth = 800, DefaultFormHeight = 600;
    private int _formWidth = DefaultFormWidth, _formHeight = DefaultFormHeight;
    private const int DefaultAxisSize = 3;

    // Object position settings
    private const float DefaultTranslateX = 0F, DefaultTranslateY = 0F, DefaultTranslateZ = 0F;

    private const int DefaultScale = 1,
        DefaultRotateX = 0, DefaultRotateY = 0, DefaultRotateZ = 0,
        DefaultRadians = 10,
        DefaultDistance = 800,
        DefaultPhi = -10,
        DefaultTheta = -100,
        DefaultStepSize = 1;

    private const float ScaleStepSize = 0.1F,
        TranslateStepSize = 0.1F;

    private const int RotateStepSize = DefaultStepSize,
        RadiansStepSize = DefaultStepSize,
        DistanceStepSize = DefaultStepSize,
        PhiStepSize = DefaultStepSize,
        ThetaStepSize = DefaultStepSize;

    private float _scale = DefaultScale,
        _translateX = DefaultTranslateX, _translateY = DefaultTranslateY, _translateZ = DefaultTranslateZ;
    private int _rotateX = DefaultRotateX, _rotateY = DefaultRotateY, _rotateZ = DefaultRotateZ,
        _radians = DefaultRadians, // length of the vector
        _distance = DefaultDistance,
        _phi = DefaultPhi, // angle z-axis
        _theta = DefaultTheta; // angle y-axis

    // Axes
    private readonly AxisX _axisX, _axisXOriginal;
    private readonly AxisY _axisY, _axisYOriginal;
    private readonly AxisZ _axisZ, _axisZOriginal;

    // Objects
    private readonly Cube _cube, _cubeOriginal;
    
    // Animation
    private const Phase DefaultPhase = Phase.One;
    private Phase _phase = DefaultPhase;
    private readonly Timer _timer;
    private bool _shouldPlayAnimation, 
        _shouldPlayPhaseAnimationForward = true, 
        _shouldEndPhaseAnimation;

    private const float AnimationScaleStepSize = 0.01f;
    private const float MinimumAnimationScale = 1.0f, MaximumAnimationScale = 1.5f;
    private const int MinimumAnimationRotateX = 0, MaximumAnimationRotateX = 45;
    private const int MinimumAnimationRotateY = 0, MaximumAnimationRotateY = 45;

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
        _axisXOriginal = new AxisX(DefaultAxisSize);
        _axisY = new AxisY(DefaultAxisSize);
        _axisYOriginal = new AxisY(DefaultAxisSize);
        _axisZ = new AxisZ(DefaultAxisSize);
        _axisZOriginal = new AxisZ(DefaultAxisSize);

        // Create objects
        _cube = new Cube(Color.Purple);
        _cubeOriginal = new Cube(Color.Purple);
        
        // Initialize the timer and runs asn animation which ticks every 50 ms
        _timer = new Timer(50);
        _timer.AutoReset = true;
        _timer.Elapsed += CubeAnimation;
        _timer.Start();
    }

    protected override void OnPaint(PaintEventArgs eventArgs)
    {
        base.OnPaint(eventArgs);

        var graphics = new GraphicsHelper(eventArgs.Graphics, _formWidth, _formHeight);

        _axisX.Matrix = MatrixImmutable.Rotate4D(Axis.X, _axisXOriginal.Matrix, _rotateX);
        _axisX.Matrix = MatrixImmutable.Rotate4D(Axis.Y, _axisX.Matrix, _rotateY);
        _axisX.Matrix = MatrixImmutable.Rotate4D(Axis.Z, _axisX.Matrix, _rotateZ);
        _axisX.Matrix = MatrixImmutable.ViewingPipeline4D(_axisX.Matrix, _distance, _radians, _theta, _phi);
        AxisX.Draw(graphics, _axisX.Matrix);
        _axisY.Matrix = MatrixImmutable.Rotate4D(Axis.X, _axisYOriginal.Matrix, _rotateX);
        _axisY.Matrix = MatrixImmutable.Rotate4D(Axis.Y, _axisY.Matrix, _rotateY);
        _axisY.Matrix = MatrixImmutable.Rotate4D(Axis.Z, _axisY.Matrix, _rotateZ);
        _axisY.Matrix = MatrixImmutable.ViewingPipeline4D(_axisY.Matrix, _distance, _radians, _theta, _phi);
        AxisY.Draw(graphics, _axisY.Matrix);
        _axisZ.Matrix = MatrixImmutable.Rotate4D(Axis.X, _axisZOriginal.Matrix, _rotateX);
        _axisZ.Matrix = MatrixImmutable.Rotate4D(Axis.Y, _axisZ.Matrix, _rotateY);
        _axisZ.Matrix = MatrixImmutable.Rotate4D(Axis.Z, _axisZ.Matrix, _rotateZ);
        _axisZ.Matrix = MatrixImmutable.ViewingPipeline4D(_axisZ.Matrix, _distance, _radians, _theta, _phi);
        AxisZ.Draw(graphics, _axisZ.Matrix);

        _cube.Matrix = MatrixImmutable.Rotate4D(Axis.X, _cubeOriginal.Matrix, _rotateX);
        _cube.Matrix = MatrixImmutable.Rotate4D(Axis.Y, _cube.Matrix, _rotateY);
        _cube.Matrix = MatrixImmutable.Rotate4D(Axis.Z, _cube.Matrix, _rotateZ);
        _cube.Matrix = MatrixImmutable.Translate4D(_cube.Matrix, new VectorImmutable(_translateX, _translateY, _translateZ));
        _cube.Matrix = MatrixImmutable.ViewingPipeline4D(_cube.Matrix, _distance, _radians, _theta, _phi);
        _cube.Matrix = MatrixImmutable.Scale(_cube.Matrix, _scale);
        _cube.Draw(graphics, _cube.Matrix);
    }
    
    private void CubeAnimation(object? sender, ElapsedEventArgs eventArgs)
    {
        if (!_shouldPlayAnimation)
        {
            return;
        }

        switch (_phase)
        {
            case Phase.One:
                HandlePhaseOne();
                break;
            case Phase.Two:
                HandlePhaseTwo();
                break;
            case Phase.Three:
                HandlePhaseThree();
                break;
            case Phase.Four:
            default:
                HandlePhaseFour();
                break;
        }
        
        Invalidate();
    }

    private void HandlePhaseOne()
    {
        switch (_shouldPlayPhaseAnimationForward)
        {
            case false when _scale <= MinimumAnimationScale:
                _shouldEndPhaseAnimation = true;
                break;
            case true when _scale > MaximumAnimationScale:
                _shouldPlayPhaseAnimationForward = false;
                break;
        }

        if (_shouldEndPhaseAnimation)
        {
            _phase = Phase.Two;
            phaseValue.Invoke((MethodInvoker) (() => phaseValue.Text = _phase.ToString()));
            
            _shouldEndPhaseAnimation = false;
            _shouldPlayPhaseAnimationForward = true;
            return;
        }

        switch (_shouldPlayPhaseAnimationForward)
        {
            case true:
                _scale += AnimationScaleStepSize;
                break;
            case false:
                _scale -= AnimationScaleStepSize;
                break;
        }

        _theta -= ThetaStepSize;
        scaleValue.Invoke((MethodInvoker) (() => scaleValue.Text = Math.Round(_scale, 2).ToString(CultureInfo.InvariantCulture)));
        thetaValue.Invoke((MethodInvoker) (() => thetaValue.Text = _theta.ToString()));
    }
    
    private void HandlePhaseTwo()
    {
        switch (_shouldPlayPhaseAnimationForward)
        {
            case false when _rotateX <= MinimumAnimationRotateX:
                _shouldEndPhaseAnimation = true;
                break;
            case true when _rotateX > MaximumAnimationRotateX:
                _shouldPlayPhaseAnimationForward = false;
                break;
        }

        if (_shouldEndPhaseAnimation)
        {
            _phase = Phase.Three;
            phaseValue.Invoke((MethodInvoker) (() => phaseValue.Text = _phase.ToString()));
            
            _shouldEndPhaseAnimation = false;
            _shouldPlayPhaseAnimationForward = true;
            return;
        }

        switch (_shouldPlayPhaseAnimationForward)
        {
            case true:
                _rotateX += RotateStepSize;
                break;
            case false:
                _rotateX -= RotateStepSize;
                break;
        }

        _theta -= ThetaStepSize;
        rotateXValue.Invoke((MethodInvoker) (() => rotateXValue.Text = _rotateX.ToString(CultureInfo.InvariantCulture)));
        thetaValue.Invoke((MethodInvoker) (() => thetaValue.Text = _theta.ToString()));
    }
    
    private void HandlePhaseThree()
    {
        switch (_shouldPlayPhaseAnimationForward)
        {
            case false when _rotateY <= MinimumAnimationRotateY:
                _shouldEndPhaseAnimation = true;
                break;
            case true when _rotateY > MaximumAnimationRotateY:
                _shouldPlayPhaseAnimationForward = false;
                break;
        }

        if (_shouldEndPhaseAnimation)
        {
            _phase = Phase.Four;
            phaseValue.Invoke((MethodInvoker) (() => phaseValue.Text = _phase.ToString()));
            
            _shouldEndPhaseAnimation = false;
            _shouldPlayPhaseAnimationForward = true;
            return;
        }

        switch (_shouldPlayPhaseAnimationForward)
        {
            case true:
                _rotateY += RotateStepSize;
                break;
            case false:
                _rotateY -= RotateStepSize;
                break;
        }
        
        _phi += PhiStepSize;
        rotateYValue.Invoke((MethodInvoker) (() => rotateYValue.Text = _rotateY.ToString(CultureInfo.InvariantCulture)));
        phiValue.Invoke((MethodInvoker) (() => phiValue.Text = _phi.ToString()));
    }

    private void HandlePhaseFour()
    {
        if (_phi == DefaultPhi && _theta == DefaultTheta)
        {
            _phase = Phase.One;
            phaseValue.Invoke((MethodInvoker) (() => phaseValue.Text = _phase.ToString()));
            return;
        }

        if (_theta != DefaultTheta)
        {
            _theta += ThetaStepSize;
        }

        if (_phi != DefaultPhi)
        {
            _phi -= PhiStepSize;
        }
        
        phiValue.Invoke((MethodInvoker) (() => phiValue.Text = _phi.ToString()));
        thetaValue.Invoke((MethodInvoker) (() => thetaValue.Text = _theta.ToString()));
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
                HandleRadiansControl(eventArgs);
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
            case Keys.A:
                _shouldPlayAnimation = true;
                animationValue.Text = "Stop";
                Refresh();
                break;
            case Keys.O:
                _shouldPlayAnimation = false;
                animationValue.Text = "Play";
                Refresh();
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
        _radians = DefaultRadians;
        _distance = DefaultDistance;
        _phi = DefaultPhi;
        _theta = DefaultTheta;
        _phase = DefaultPhase;
        _shouldPlayAnimation = false;

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

    private void HandleRadiansControl(KeyEventArgs eventArgs)
    {
        if (eventArgs.Modifiers == Keys.Shift)
        {
            _radians -= RadiansStepSize;
        }
        else
        {
            _radians += RadiansStepSize;
        }

        radiansValue.Text = _radians.ToString(CultureInfo.InvariantCulture);
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
        radiansValue.Text = _radians.ToString(CultureInfo.InvariantCulture);
        distanceValue.Text = _distance.ToString(CultureInfo.InvariantCulture);
        phiValue.Text = _phi.ToString(CultureInfo.InvariantCulture);
        thetaValue.Text = _theta.ToString(CultureInfo.InvariantCulture);
        phaseValue.Text = _phase.ToString();
        animationValue.Text = "Play";
    }
}

public enum Phase
{
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
}
