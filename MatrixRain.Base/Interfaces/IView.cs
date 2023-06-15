namespace MatrixRain.Base.Interfaces
{
    public interface IView
    {
        public ConsoleColor BaseColor { get; set; }
        public void Display();
    }
}
