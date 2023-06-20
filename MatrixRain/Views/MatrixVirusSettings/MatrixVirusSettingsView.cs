using MatrixRain.Views.Common;

namespace MatrixRain.Views
{
    public enum MatrixVirusSettings
    {
        MatrixColor,
        BrokenMatrixColor,
        TextColor,
        Text,
        SkullColor    
    }

    public class MatrixVirusSettingsView : ChangeColorView
    {

        private MatrixVirusSettings settings;

        protected override void BeforeNav()
        {
            WriteLine();
            WriteLine("Matrix-virus animation settings".ToUpper());
            WriteLine();

            WriteLine("Type the number of the setting you want to change and then ENTER");
            WriteLine("1. Matrix color");
            WriteLine("2. Broken matrix color");
            WriteLine("3. Text color");
            WriteLine("4. Just the text");
            WriteLine("5. Skull color");

            WriteLine("type anything else to go back");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    settings = MatrixVirusSettings.MatrixColor;
                    break;

                case "2":
                    settings = MatrixVirusSettings.BrokenMatrixColor;
                    break;

                case "3":
                    settings = MatrixVirusSettings.TextColor;
                    break;

                case "4":
                    settings = MatrixVirusSettings.Text;
                    ChangeText();
                    break;

                case "5":
                    settings = MatrixVirusSettings.SkullColor;
                    break;

                default:
                    break;
            }

            Console.Clear();
        }

        protected override void DisplayView()
        {
            if (settings != MatrixVirusSettings.Text 
                && settings != MatrixVirusSettings.MatrixColor 
                && settings != MatrixVirusSettings.BrokenMatrixColor)
            {
                SelectColor();
            }
            else
            {
                InvokeSignal("nav", settings.ToString());
            }
        }

        private void SelectColor()
        {
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    NavSection.Up();
                    break;

                case ConsoleKey.DownArrow:
                    NavSection.Down();
                    break;

                case ConsoleKey.Enter:
                    InvokeSignal(settings.ToString(), NavSection.CurrentItemName());
                    break;

                default:
                    break;
            }
        }

        private void ChangeText()
        {
            Console.Clear();
            WriteLine();
            WriteLine("Type the text you want to be displayed during the virus animation:");

            string text = Console.ReadLine() ?? "";
            InvokeSignal(settings.ToString(), text);
        }
    }
}
