using QJect;
using MatrixRain.Configs;
using QJect.Core;
using MatrixRain.Base.Models.Exceptions;

namespace MatrixRain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartUp program = new StartUp();
                program.Start();
            }
            catch(MatrixRainException e)
            {
                Utils.PrintError(e.Message);
            }
            catch (Exception)
            {
                Utils.PrintError("Unknown exception occured.");
                Utils.PrintError("Close and start again the app.");
            }

        }
    }
}