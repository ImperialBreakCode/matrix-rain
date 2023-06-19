using MatrixRain.Services.Matrix;

namespace MatrixRain.Services.Interfaces
{
    public interface IMatrixService
    {
        public IMatrix MatrixRain { get; }
        public IMatrix MatrixAnimation { get; }
        public void RunMatrixRain();
        public Task RunMatrixAnimation();
    }
}
