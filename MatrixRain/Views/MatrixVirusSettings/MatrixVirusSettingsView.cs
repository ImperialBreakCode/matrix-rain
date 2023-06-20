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
        private bool inMenu = false;
        private bool goBackInputMatch = false;

        protected override void BeforeNav()
        {
            goBackInputMatch = false;

            if (!inMenu)
            {
                WriteLine("Matrix-virus animation settings".ToUpper());
                WriteLine();

                WriteLine("Type the number of the setting you want to change and then ENTER");
                WriteLine("1. Matrix color");
                WriteLine("2. Broken matrix color");
                WriteLine("3. Text color");
                WriteLine("4. Just the text");
                WriteLine("5. Skull color");

                WriteLine("type anything else to go back");

                Console.CursorVisible = true;
                var input = Console.ReadLine()?.Trim();
                Console.CursorVisible = false;

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
                        goBackInputMatch = true;
                        break;
                }

                Console.Clear();   
            }

            WriteLine();
        }

        protected override void DisplayView()
        {
            if (goBackInputMatch)
            {
                InvokeSignal("GoBack", null);
                return;
            }

            if (settings != MatrixVirusSettings.Text 
                && settings != MatrixVirusSettings.MatrixColor 
                && settings != MatrixVirusSettings.BrokenMatrixColor)
            {
                inMenu = true;
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

            if (key == ConsoleKey.UpArrow)
            {
                NavSection.Up();
            }
            else if (key == ConsoleKey.DownArrow)
            {
                NavSection.Down();
            }
            else if (key == ConsoleKey.Enter)
            {
                inMenu = false;
                InvokeSignal("ChangeSettings", $"{settings}-{NavSection.CurrentItemName()}");
            }
        }

        private void ChangeText()
        {
            Console.Clear();
            WriteLine();
            WriteLine("Type the text you want to be displayed during the virus animation:");

            Console.CursorVisible = true;
            string text = Console.ReadLine() ?? "";
            Console.CursorVisible = false;

            InvokeSignal("ChangeText", text);
        }
    }
}
