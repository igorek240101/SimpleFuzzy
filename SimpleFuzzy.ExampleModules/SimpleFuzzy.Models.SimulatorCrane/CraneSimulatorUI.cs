using System.Reflection;


namespace SimpleFuzzy.Models.SimulatorCrane
{
    public partial class VisualCrane : UserControl
    {
        public CraneSimulator craneSimulator;

        private BufferedGraphicsContext context;
        private BufferedGraphics grafx;
        private const double visualLength = 100; // в пикселях
        private System.Drawing.Image backgroundImage, cartImage, containerImage, constructImage, cargoImage, platformImage;

        public VisualCrane()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);

            context = BufferedGraphicsManager.Current;
            grafx = context.Allocate(CreateGraphics(), DisplayRectangle);
            var assembly = Assembly.GetExecutingAssembly();
            try
            {
                string spritesPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "assets", "sprites");
                backgroundImage = System.Drawing.Image.FromFile(Path.Combine(spritesPath, "port.png"));
                cartImage = System.Drawing.Image.FromFile(Path.Combine(spritesPath, "carriage.png"));
                containerImage = System.Drawing.Image.FromFile(Path.Combine(spritesPath, "cable and weight.png"));
                constructImage = System.Drawing.Image.FromFile(Path.Combine(spritesPath, "construct.png"));
                cargoImage = System.Drawing.Image.FromFile(Path.Combine(spritesPath, "cargo.png"));
                platformImage = System.Drawing.Image.FromFile(Path.Combine(spritesPath, "platform.png"));
            }
            catch { }
            Paint += OnPaint;
            Dock = DockStyle.Fill;
        }

        public VisualCrane(CraneSimulator crane) : this()
        {
            craneSimulator = crane;
        }

        protected void OnPaint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.FromArgb(135, 206, 235)); // Очищаем весь экран цветом неба

            // Фон (порт)
            g.DrawImage(backgroundImage, 0, 0, Width, Height);

            float leftBoundary = Width / 6;
            float rightBoundary = Width - Width / 20;
            float craneWidth = rightBoundary - leftBoundary;

            // Каретка
            float cartWidth = 40; // Ширина каретки
            float cartX = (float)(craneSimulator.x / craneSimulator.beamSize * (craneWidth - cartWidth) + leftBoundary);
            g.DrawImage(cartImage, cartX, 150, cartWidth, 30);

            // Кран
            g.DrawImage(constructImage, -130, -100, 800, 658);

            // Трос
            float ropeStartX = cartX + 20;
            float ropeStartY = 180;
            float ropeEndX = (float)(ropeStartX + Math.Sin(craneSimulator.y) * visualLength);
            float ropeEndY = (float)(ropeStartY + Math.Cos(craneSimulator.y) * visualLength);
            g.DrawLine(new Pen(Color.Black, 2), ropeStartX, ropeStartY, ropeEndX, ropeEndY);

            // Контейнер (груз)
            g.DrawImage(containerImage, ropeEndX - 20, ropeEndY - 15, 40, 30);

            // Грузовой корабль
            g.DrawImage(cargoImage, 440, 110, Width, Height);

            // Платформа
            float platformWidth = 70;
            float platformHeight = 25;
            float platformX = (float)(craneSimulator.platformPosition / craneSimulator.beamSize * craneWidth + leftBoundary+15);
            float platformY = Height - 45;
            g.DrawImage(platformImage, platformX, platformY, platformWidth, platformHeight);

            // Отображение текущих параметров
            using (Font font = new Font("Roboto", 10))
            {
                g.DrawString($"Позиция: {craneSimulator.x:F2} м", font, Brushes.Black, 10, 10);
                g.DrawString($"Угол: {craneSimulator.y * 180 / Math.PI:F2}°", font, Brushes.Black, 10, 30);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "VisualCrane";
            this.Size = new System.Drawing.Size(460, 330);
            this.ResumeLayout(false);

        }
    }

}
