namespace MatrixRain.Services.Matrix
{
    public interface IMatrix
    {
        public int Speed { get; set; }
        public Task RunAnimation(CancellationTokenSource token);
        public void SetColors(ConsoleColor main, ConsoleColor highlight, ConsoleColor leading);
    }
}
