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

        public void RunMatrixRain()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            MatrixRain.RunAnimation(tokenSource);

            Console.ReadKey();
            tokenSource.Cancel();
            Thread.Sleep(200);
        }
    }
}
