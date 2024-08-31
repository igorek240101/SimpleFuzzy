using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Models.SimulatorCrane
{
    public class CraneSimulator : ISimulator
    {
        public bool Active { get; set; }
        public string Name { get; } = "Портовый кран";

        public Func<List<object>, List<object>> GetFunc { get; set; }

        public double m = 1; // Масса маятника (кг)
        public double M = 5; // Масса каретки (кг)
        public double l = 2; // Длина маятника (м)
        public const double g = 9.8; // Ускорение свободного падения (м/с^2)
        public double k1 = 0.1; // Коэффициент торможения каретки
        public double k2 = 0.1; // Коэффициент затухания колебаний
        public double x = 0; // Положение каретки (м)
        public double y = 0; // Угол отклонения маятника (рад)
        public double f = 0; // Сила, действующая на каретку (Н)
        public double dx = 0;
        public double dy = 0;
        public double t = 0.01;
        public double beamSize = 100; // по умолчанию размер балки 20
        public double platformPosition = 20;
        public const double MAX_ANGLE = Math.PI / 2;
        private bool cargoLoaded = false;

        public object GetVisualObject() => new FromOfSimulator(this);

        public void Step()
        {
            double ax = (m * l * l * dy * dy * Math.Sin(y) + l * f - m * g * l * Math.Sin(y) * Math.Cos(y)) / (l * M + l * m * Math.Sin(y) * Math.Sin(y)) - (dx * k1);
            double ay = (-(M + m) * g * Math.Sin(y) - m * l * dy * dy * Math.Sin(y) * Math.Cos(y) - f * Math.Cos(y)) / (l * M + l * m * Math.Sin(y) * Math.Sin(y)) - (dy * k2);
            dx += ax * t;
            dy += ay * t;
            x += dx * t;
            y += dy * t;

            // Ограничение движения каретки
            x = Math.Max(0, Math.Min(beamSize, x));
        }

        public List<LinguisticVariableDto> GetLinguisticVariables()
            => new List<LinguisticVariableDto>()
            {
                new LinguisticVariableDto { Name = "Растояние до цели", BaseSet = typeof(Distance), IsInput = true },
                new LinguisticVariableDto { Name = "Угол отклонения груза", BaseSet = typeof(Angle), IsInput = true },
                new LinguisticVariableDto { Name = "Мощность двигателя", BaseSet = typeof(Power), IsInput = false },
            };

        public void SetController(Func<List<object>, List<object>> controller)
            => GetFunc = controller;
    }
}
