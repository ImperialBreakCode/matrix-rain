namespace MatrixRain.Services.Matrix
{
    internal class MatrixVirusAnimation : MatrixRainAnimation, IMatrixVirusAnimation
    {
        public MatrixVirusAnimation(Random random) : base(random)
        {
            Text = "SYSTEM FAILURE";
        }

        protected int PositionSkull => Width / 2 - 13;

        public string Text { get; set; }

        protected override void AnimationLoop(CancellationToken token)
        {
            while (true)
            {
                try
                {
                    MultiPhaseLoop(token);
                    break;
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
                }
            }
            
        }

        private void MultiPhaseLoop(CancellationToken token)
        {
            int i = 0;

            while (true)
            {
                if (i == 1)
                {
                    CanWriteHighlight = true;
                }
                else if (i == 3)
                {
                    CanWriteMain = true;
                }

                if (i <= 100)
                {
                    Thread.Sleep(50);
                    Update(0);
                }
                else if (i > 100 && i <= 150)
                {
                    Thread.Sleep(50);
                    Update(80);
                }
                else if (i > 150 && i <= 220)
                {
                    Thread.Sleep(50);
                    UpdateTextPhase();
                }
                else if (i > 220 && i < 230)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Green;
                    if (i % 2 == 0)
                    {
                        WriteSkull();
                    }
                    else
                    {
                        WriteSecondSkull();
                    }

                    Thread.Sleep(500);
                }
                else
                {
                    i = 0;
                }

                i++;

                if (token.IsCancellationRequested)
                {
                    break;
                }
            }
        }

        private void UpdateTextPhase()
        {
            for (int x = 0; x < Width; x++)
            {
                int delCharPos = Drops[x].PosY - (Drops[x].Length);

                GetProperCoord(ref delCharPos);

                Console.SetCursorPosition(x, delCharPos);
                Console.Write(' ');

                UpdateDropCoord(ref Drops[x].PosY);
            }

            Console.SetCursorPosition(Width / 2 - Text.Length / 2, Height / 2);
            Console.WriteLine(Text);
        }

        private void WriteSecondSkull()
        {
            Console.SetCursorPosition(PositionSkull, Height / 2 - 9);
            Console.Write(@"          uuuuuuu             ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 8);
            Console.Write(@"      uu$$$$$$$$$$$uu         ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 7);
            Console.Write(@"   uu$$$$$$$$$$$$$$$$$uu      ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 6);
            Console.Write(@"  u$$$$$$$$$$$$$$$$$$$$$u     ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 5);
            Console.Write(@" u$$$$$$$$$$$$$$$$$$$$$$$u    ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 4);
            Console.Write(@"u$$$$$$$$$$$$$$$$$$$$$$$$$u   ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 3);
            Console.Write(@"u$$$$$$$$$$$$$$$$$$$$$$$$$u   ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 2);
            Console.Write(@"u$$$$$$     $$$     $$$$$$u   ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 1);
            Console.Write(@" $$$$       u$u       $$$$    ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 0);
            Console.Write(@" $$$u       u$u       u$$$    ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 1);
            Console.Write(@" $$$u      u$$$u      u$$$    ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 2);
            Console.Write(@"   $$$$uu$$$   $$$uu$$$$      ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 3);
            Console.Write(@"    $$$$$$$     $$$$$$$       ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 4);
            Console.Write(@"     u$$$$$$$u$$$$$$$u        ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 5);
            Console.Write(@"      u$ $ $ $ $ $ $u         ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 7);
            Console.Write(@"                              ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 8);
            Console.Write(@"      $$u$ $ $ $ $u$$         ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 9);
            Console.Write(@"       $$$$$u$u$u$$$          ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 10);
            Console.Write(@"         $$$$$$$$$            ");
        }

        private void WriteSkull()
        {
            Console.SetCursorPosition(PositionSkull, Height / 2 - 9);
            Console.Write(@"          uuuuuuu             ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 8);
            Console.Write(@"      uu$$$$$$$$$$$uu         ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 7);
            Console.Write(@"   uu$$$$$$$$$$$$$$$$$uu      ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 6);
            Console.Write(@"  u$$$$$$$$$$$$$$$$$$$$$u     ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 5);
            Console.Write(@" u$$$$$$$$$$$$$$$$$$$$$$$u    ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 4);
            Console.Write(@"u$$$$$$$$$$$$$$$$$$$$$$$$$u   ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 3);
            Console.Write(@"u$$$$$$$$$$$$$$$$$$$$$$$$$u   ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 2);
            Console.Write(@"u$$$$$$     $$$     $$$$$$u   ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 1);
            Console.Write(@" $$$$       u$u       $$$$    ");

            Console.SetCursorPosition(PositionSkull, Height / 2 - 0);
            Console.Write(@" $$$u       u$u       u$$$    ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 1);
            Console.Write(@" $$$u      u$$$u      u$$$    ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 2);
            Console.Write(@"   $$$$uu$$$   $$$uu$$$$      ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 3);
            Console.Write(@"    $$$$$$$     $$$$$$$       ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 4);
            Console.Write(@"     u$$$$$$$u$$$$$$$u        ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 5);
            Console.Write(@"      u$ $ $ $ $ $ $u         ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 6);
            Console.Write(@"      $$u$ $ $ $ $u$$         ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 7);
            Console.Write(@"       $$$$$u$u$u$$$          ");

            Console.SetCursorPosition(PositionSkull, Height / 2 + 8);
            Console.Write(@"         $$$$$$$$$            ");
        }
    }
}