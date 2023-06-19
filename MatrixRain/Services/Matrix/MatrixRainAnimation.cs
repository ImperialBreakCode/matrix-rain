namespace MatrixRain.Services.Matrix
{
    public struct DropLine
    {
        public int PosY;
        public int Length;
    }

    public class MatrixRainAnimation : IMatrix
    {
        private readonly Random random;

        private bool canWriteHighlight;
        private bool canWriteMain;

        private ConsoleColor mainColor;
        private ConsoleColor highlightColor;
        private ConsoleColor brightColor;

        private int speed;

        private int height;
        private int width;

        private DropLine[] drops;

        private char Char => (char)random.Next(33, 127);

        public MatrixRainAnimation(Random random)
        {
            this.random = random;

            mainColor = ConsoleColor.DarkGreen;
            highlightColor = ConsoleColor.Green;
            brightColor = ConsoleColor.White;

            speed = 100;

            SetWidthHeight();
        }

        public async Task RunAnimation(CancellationTokenSource tokenSource)
        {
            SetDropLines();

            Console.CursorVisible = false;
            Console.Clear();

            await Task.Factory.StartNew(() => AnimationLoop(tokenSource.Token), tokenSource.Token);
        }

        private void AnimationLoop(CancellationToken token)
        {
            int i = 0;

            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    Console.Clear();
                    break;
                }

                if (i < 4)
                {

                    if (i == 1)
                    {
                        canWriteHighlight = true;
                    }
                    else if (i == 3)
                    {
                        canWriteMain = true;
                    }

                    i++;
                }

                try
                {
                    Update();
                    Thread.Sleep(speed);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Error occured after the window was resized");
                    Console.WriteLine("Restarting after:");

                    for (int c = 0; c < 4; c++)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine(3 - c);
                    }

                    SetDropLines();
                    i = 0;
                }
                
            }
        }

        private void Update()
        {
            for (int x = 0; x < width; x++)
            {
                // Writing leading char in the drop line (white color)
                Console.ForegroundColor = brightColor;
                Console.SetCursorPosition(x, drops[x].PosY);
                Console.Write(Char);

                // Writing the preceeding char (highlighted color)
                if (canWriteHighlight)
                {
                    int highlightPos = drops[x].PosY - 1;
                    GetProperCoord(ref highlightPos);

                    Console.ForegroundColor = highlightColor;
                    Console.SetCursorPosition(x, highlightPos);
                    Console.Write(Char);
                }

                // Writing after the higlighted area (main color)
                if (canWriteMain)
                {
                    int mainPos = drops[x].PosY - 3;
                    GetProperCoord(ref mainPos);

                    Console.ForegroundColor = mainColor;
                    Console.SetCursorPosition(x, mainPos);
                    Console.Write(Char);
                }

                // Removing characters from the end of the line
                int delCharPos = drops[x].PosY - drops[x].Length;

                GetProperCoord(ref delCharPos);

                Console.SetCursorPosition(x, delCharPos);
                Console.Write(' ');

                // updating the position of the drop line (main char + 1)
                UpdateDropCoord(ref drops[x].PosY);
            }
        }

        private void GetProperCoord(ref int x)
        {
            if (x < 0)
            {
                x = height + x;

                if (x < 0)
                {
                    x = 0;
                }
            }
            else if (x > height - 1)
            {
                x -= height;
            }
        }

        private void UpdateDropCoord(ref int x)
        {
            x++;

            if (x > height - 1)
            {
                x = 0;
            }
        }

        private void SetDropLines()
        {
            SetWidthHeight();
            canWriteMain = false;
            canWriteHighlight = false;

            for (int i = 0; i < width; i++)
            {
                drops[i] = new DropLine
                {
                    PosY = random.Next(height - 5),
                    Length = random.Next(5, 40)
                };
            }
        }

        private void SetWidthHeight()
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth;

            drops = new DropLine[width];
        }  
    }
}
