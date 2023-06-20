using QJect;
using MatrixRain.Configs;
using QJect.Core;

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
            catch (NullReferenceException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}