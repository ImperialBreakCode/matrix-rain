using MatrixRain.Models;
using MatrixRain.Services.Matrix;

namespace MatrixRain.Services.Interfaces
{
    public interface IMatrixService
    {
        public IMatrix MatrixRain { get; }
        public IMatrix MatrixAnimation { get; }
        public void RunMatrixRain(Settings settings);
        public void RunMatrixAnimation();
    }
}
