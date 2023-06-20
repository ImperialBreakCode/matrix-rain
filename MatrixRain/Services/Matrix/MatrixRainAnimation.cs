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

        private ConsoleColor mainColor;
        private ConsoleColor highlightColor;
        private ConsoleColor brightColor;

        private char Char => (char)random.Next(33, 127);

        public MatrixRainAnimation(Random random)
        {
            this.random = random;

            mainColor = ConsoleColor.DarkGreen;
            highlightColor = ConsoleColor.Green;
            brightColor = ConsoleColor.White;

            Speed = 50;

            SetWidthHeight();
        }

        protected bool CanWriteHighlight { get; set; }
        protected bool CanWriteMain { get; set; }
        public int Speed { get; set; }
        protected int Height { get; private set; }
        protected int Width { get; private set; }
        protected DropLine[] Drops { get; private set; }

        public void SetColors(ConsoleColor main, ConsoleColor highlight, ConsoleColor leading)
        {
            mainColor = main;
            highlightColor = highlight;
            brightColor = leading;
        }

        public async Task RunAnimation(CancellationTokenSource tokenSource)
        {
            SetDropLines();

            Console.CursorVisible = false;
            Console.Clear();

            await Task.Factory.StartNew(() => AnimationLoop(tokenSource.Token), tokenSource.Token);
        }

        protected virtual void AnimationLoop(CancellationToken token)
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
                        CanWriteHighlight = true;
                    }
                    else if (i == 3)
                    {
                        CanWriteMain = true;
                    }

                    i++;
                }

                try
                {
                    Update(0);
                    Thread.Sleep(Speed);
                }
                catch (ArgumentOutOfRangeException)
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

        protected void Update(int space)
        {
            for (int x = 0; x < Width; x++)
            {
                // Writing leading char in the drop line (white color)
                Console.ForegroundColor = brightColor;
                Console.SetCursorPosition(x, Drops[x].PosY);
                Console.Write(Char);

                // Writing the preceeding char (highlighted color)
                if (CanWriteHighlight)
                {
                    int highlightPos = Drops[x].PosY - 1;
                    GetProperCoord(ref highlightPos);

                    Console.ForegroundColor = highlightColor;
                    Console.SetCursorPosition(x, highlightPos);
                    Console.Write(Char);
                }

                // Writing after the higlighted area (main color)
                if (CanWriteMain)
                {
                    int mainPos = Drops[x].PosY - 3;
                    GetProperCoord(ref mainPos);

                    Console.ForegroundColor = mainColor;
                    Console.SetCursorPosition(x, mainPos);
                    Console.Write(Char);
                }

                // Removing characters from the end of the line

                int delCharPos = Drops[x].PosY - ( Drops[x].Length + space );

                GetProperCoord(ref delCharPos);

                Console.SetCursorPosition(x, delCharPos);
                Console.Write(' ');

                // updating the position of the drop line (main char + 1)
                UpdateDropCoord(ref Drops[x].PosY);
            }
        }

        protected void GetProperCoord(ref int x)
        {
            if (x < 0)
            {
                x = Height + x;

                if (x < 0)
                {
                    x = 0;
                }
            }
            else if (x > Height - 1)
            {
                x -= Height;
            }
        }

        protected void UpdateDropCoord(ref int x)
        {
            x++;

            if (x > Height - 1)
            {
                x = 0;
            }
        }

        protected void SetDropLines()
        {
            SetWidthHeight();
            CanWriteMain = false;
            CanWriteHighlight = false;

            for (int i = 0; i < Width; i++)
            {
                Drops[i] = new DropLine
                {
                    PosY = random.Next(Height - 5),
                    Length = random.Next(5, 40)
                };
            }
        }

        private void SetWidthHeight()
        {
            Height = Console.WindowHeight;
            Width = Console.WindowWidth;

            Drops = new DropLine[Width];
        }
    }
}
