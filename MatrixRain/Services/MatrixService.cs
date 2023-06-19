using MatrixRain.Services.Interfaces;
using MatrixRain.Services.Matrix;

namespace MatrixRain.Services
{
    public class MatrixService : IMatrixService
    {
        private readonly Random random;
        private IMatrix matrixRain;

        public MatrixService(Random random)
        {
            this.random = random;
        }

        public IMatrix MatrixRain 
        { 
            get => matrixRain ??= new MatrixRainAnimation(random);
        }

        public IMatrix MatrixAnimation => throw new NotImplementedException();

        public Task RunMatrixAnimation()
        {
            throw new NotImplementedException();
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
