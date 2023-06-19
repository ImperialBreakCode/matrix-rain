namespace MatrixRain.Services.Matrix
{
    public interface IMatrix
    {
        public Task RunAnimation(CancellationTokenSource token);
    }
}
