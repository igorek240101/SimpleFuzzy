using SimpleFuzzy.Abstract;
using SimpleFuzzy.View;
using System.Windows.Forms;

namespace SimpleFuzzy.SimpleModule
{
    public class CraneSimulator : ISimulator
    {
        public event EventHandler<SimulatorEventArgs> StateChanged;
        public double m = 1; // Масса маятника (кг)
        public double M = 5; // Масса каретки (кг)
        public double l = 2; // Длина маятника (м)
        public const double g = 9.8; // Ускорение свободного падения (м/с^2)
        public double k1 = 0.1; // Коэффициент торможения каретки
        public double k2 = 0.1; // Коэффициент затухания колебаний
        public double x = 0; // Положение каретки (м)
        public double y = 0.1; // Угол отклонения маятника (рад)
        public double f = 0; // Сила, действующая на каретку (Н)
        public double dx = 0;
        public double dy = 0;
        public double t = 0.01;
        public double beamSize = 20; // по умолчанию размер балки 20
        public double platformPosition = 0;
        private const double MAX_ANGLE = Math.PI / 2;
        private bool cargoLoaded = false;

        private System.Windows.Forms.Timer timer;

        public UserControl GetVisualObject()
        {
            throw new NotImplementedException("GetVisualObject должен быть реализован в VisualCrane");
        }


        protected virtual void OnStateChanged(SimulatorEventArgs e) => StateChanged?.Invoke(this, e);
        public void SetBeamSize(double size) { beamSize = size; OnStateChanged(new SimulatorEventArgs()); }

        public void Step()
        {
            double ax = (m * l * l * dy * dy * Math.Sin(y) + l * f - m * g * l * Math.Sin(y) * Math.Cos(y) - (k1 * dx)) / (l * M + l * m * Math.Sin(y) * Math.Sin(y));
            double ay = (-(M + m) * g * Math.Sin(y) - m * l * dy * dy * Math.Sin(y) * Math.Cos(y) - f * Math.Cos(y) - (k2 * dy)) / (l * M + l * m * Math.Sin(y) * Math.Sin(y));
            dx += ax * t;
            dy += ay * t;
            x += dx * t;
            y += dy * t;

            // Ограничение движения каретки
            x = Math.Max(0, Math.Min(beamSize, x));

            CheckEmergencySituation();
            OnStateChanged(new SimulatorEventArgs());
        }

        private void CheckEmergencySituation()
        {
            if (x < 0 || x >= beamSize || Math.Abs(y) >= MAX_ANGLE) { EmergencyStop(); return; }
        }

        private void EmergencyStop()
        {
            string message = (x < 0 || x >= beamSize) ? "Каретка достигла края платформы!" : "Контейнер запрокинулся!";
            Reset();
            OnStateChanged(new SimulatorEventArgs(message, true));
        }

        public void Start() => timer.Start();
        public void Pause() => timer.Stop();
        public void Reset(double initialX = 0, double initialY = 0.1, double initialPlatformPosition = 0)
        {
            x = initialX;
            y = initialY;
            dx = dy = f = 0;
            platformPosition = initialPlatformPosition;
            OnStateChanged(new SimulatorEventArgs());
        }

        public void ApplyForce(double force) => f = force;

        public double GetNormalizedPosition() { return x / beamSize; }
    }
}

public class SimulatorEventArgs : EventArgs
{
    public string Message { get; }
    public bool IsEmergency { get; }

    public SimulatorEventArgs(string message = "", bool isEmergency = false)
    {
        Message = message;
        IsEmergency = isEmergency;
    }
}
