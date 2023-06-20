using MatrixRain.Models;
using MatrixRain.Services.Interfaces;
using MatrixRain.Services.Matrix;

namespace MatrixRain.Services
{
    public class MatrixService : IMatrixService
    {
        private readonly Random random;
        private IMatrix matrixRain;
        private IMatrixVirusAnimation matrixAnimation;

        public MatrixService(Random random)
        {
            this.random = random;
        }

        public IMatrix MatrixRain 
        { 
            get => matrixRain ??= new MatrixRainAnimation(random);
        }

        public IMatrixVirusAnimation MatrixAnimation
        {
            get => matrixAnimation ??= new MatrixVirusAnimation(random);
        }

        public void RunMatrixAnimation(Settings settings)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            MatrixAnimation.RegularMatrixColor = settings.MatrixVirusColor;
            MatrixAnimation.BrokenMatrixColor = settings.BrokenMatrixColor;
            MatrixAnimation.TextColor = settings.TextColor;
            MatrixAnimation.SkullColor = settings.SkullColor;
            MatrixAnimation.Text = settings.Text;
            MatrixAnimation.RunAnimation(tokenSource);

            Console.ReadKey();
            tokenSource.Cancel();
            Thread.Sleep(200);
        }

        public void RunMatrixRain(Settings settings)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            string highlightString = settings.MatrixColor.ToString().Remove(0, 4);
            ConsoleColor highlight;
            Enum.TryParse(highlightString, out highlight);

            MatrixRain.SetColors(settings.MatrixColor, highlight, ConsoleColor.White);
            MatrixRain.Speed = settings.MatrixRainSpeed;
            MatrixRain.RunAnimation(tokenSource);

            Console.ReadKey();
            tokenSource.Cancel();
            Thread.Sleep(600);
        }
    }
}
