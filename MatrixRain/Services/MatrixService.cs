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

        public IMatrix MatrixAnimation
        {
            get => matrixAnimation ??= new MatrixVirusAnimation(random);
        }

        public void RunMatrixAnimation()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();

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
