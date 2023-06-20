namespace MatrixRain.Models
{
    public class Settings
    {
        // ui
        public ConsoleColor InterfaceColor { get; set; }
        public ConsoleColor SelectionColor { get; set; }

        // matrix rain
        public ConsoleColor MatrixColor { get; set; }
        public int MatrixRainSpeed { get; set; }

        // matrix virus
        public ConsoleColor MatrixVirusColor { get; set; }
        public ConsoleColor BrokenMatrixColor { get; set; }
        public ConsoleColor TextColor { get; set; }
        public ConsoleColor SkullColor { get; set; }
        public string Text { get; set; }
    }
}
