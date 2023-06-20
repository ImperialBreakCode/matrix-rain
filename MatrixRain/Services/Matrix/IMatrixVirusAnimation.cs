namespace MatrixRain.Services.Matrix
{
    public interface IMatrixVirusAnimation : IMatrix
    {
        public string Text { get; set; }
        public ConsoleColor RegularMatrixColor { get; set; }
        public ConsoleColor BrokenMatrixColor { get; set; }
        public ConsoleColor TextColor { get; set; }
        public ConsoleColor SkullColor { get; set; }
    }
}
