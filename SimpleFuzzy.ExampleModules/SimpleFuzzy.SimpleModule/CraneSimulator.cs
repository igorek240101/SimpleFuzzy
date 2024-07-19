using SimpleFuzzy.Abstract;
using SimpleFuzzy.View;
using System.Windows.Forms;

namespace SimpleFuzzy.SimpleModule
{
    public class CraneSimulator : ISimulator
    {
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


        private System.Windows.Forms.Timer timer;
        public VisualCrane crane;
        public CraneSimulator()
        {
            crane = new VisualCrane { craneSimulator = this };
            timer = new System.Windows.Forms.Timer { Interval = 16 }; // ~60 FPS
            timer.Tick += (s, e) => Step();
        }
        public UserControl GetVisualObject() => crane;

        public void SetBeamSize(double size) => beamSize = size;

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

            crane.Invalidate();
        }

        private bool cargoLoaded = false;
        private DateTime lastLoadTime = DateTime.MinValue;

        private void CheckEmergencySituation()
        {
            if (x < 0 || x >= beamSize || Math.Abs(y) >= MAX_ANGLE) EmergencyStop();


            // проверка на загрузку платформы
            double containerBottom = y + l * Math.Cos(y);
            double platformHeight = 0.5; // Примерная высота платформы в метрах

            if (!cargoLoaded &&
                Math.Abs(containerBottom - platformHeight) < 0.1 && // Проверка по вертикали
                x >= platformPosition && x <= platformPosition + 5 && // Проверка по горизонтали
                Math.Abs(y) < 0.1 && // Проверка вертикальности груза
                Math.Abs(dx) < 0.1 && Math.Abs(dy) < 0.1) // Проверка на малую скорость
            {
                MessageBox.Show("Груз успешно установлен на платформу!", "Успешная загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }


        }

        private void EmergencyStop()
        {
            string message = (x < 0 || x >= beamSize) ? "Каретка достигла края платформы!" : "Контейнер запрокинулся!";
            Reset();
            MessageBox.Show(message, "Аварийная ситуация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Start() => timer.Start();
        public void Pause() => timer.Stop();
        public void Reset()
        {
            platformPosition = (double)((SimpleFuzzy.View.VisualCrane)Application.OpenForms[0]).numPlatformPosition.Value;
            x = (double)((SimpleFuzzy.View.VisualCrane)Application.OpenForms[0]).numInitialPosition.Value;
            y = (double)((SimpleFuzzy.View.VisualCrane)Application.OpenForms[0]).numInitialAngle.Value * Math.PI / 180;
            dx = dy = f = 0;
            ((SimpleFuzzy.View.VisualCrane)Application.OpenForms[0]).forceTrackBar.Value = 0;
            crane.Invalidate();
        }

        public void ApplyForce(double force) => f = force;

        public double GetNormalizedPosition() { return x / beamSize; }
    }
}
