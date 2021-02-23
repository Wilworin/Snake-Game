using System;
using System.Threading;

namespace Snake_Game
{
    class Program
    {
        public static int frameRate = 5; // Changed it to a non-const so I could change the fps during play.

        public static int ConsoleWidth { get; set; } = 80;
        public static int ConsoleHeight { get; set; } = 40;

        /// <summary>
        /// Checks Console to see if a keyboard key has been pressed, if so returns it as uppercase, otherwise returns '\0'.
        /// </summary>
        static char ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key.ToString().ToUpper()[0] : '\0';


        /// <summary>
        /// This method first initializes the game and then starts the main game loop.
        /// </summary>
        static void Loop()
        {
            GameWorld world = new GameWorld(ConsoleWidth, ConsoleHeight);
            ConsoleRenderer renderer = new ConsoleRenderer(world);

            Player player = new Player(ConsoleWidth / 2, ConsoleHeight / 2);
            world.AddToList(player);

            // Main loop
            bool isRunning = true;
            while (isRunning)
            {
                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;

                // Handle key presses from the user. The supplied method ReadKeyIfExists returns the letters
                // U, D, R and L instead of "Right Arrow" and so on. I didn't bother to re-write it though
                // so it actually works to play using those letters as well.
                char key = ReadKeyIfExists();
                switch (key)
                {
                    case 'Q': // Quit
                        isRunning = false;
                        break;
                    case 'U': // Up
                        player.Dir = Direction.Up;
                        break;
                    case 'D': //Down
                        player.Dir = Direction.Down;
                        break;
                    case 'R': // Right
                        player.Dir = Direction.Right;
                        break;
                    case 'L': // Left
                        player.Dir = Direction.Left;
                        break;
                }

                // Update the world and re-draw the objects on the screen (except the wall).
                renderer.RenderBlank();
                world.Update();
                renderer.Render();

                // Measure how long it took
                double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                if (frameTime > 0)
                {
                    // Sleep for the right amount of time to make the game run in the correct frame rate.
                    Thread.Sleep((int)frameTime);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(ConsoleWidth, ConsoleHeight);
            Console.SetBufferSize(ConsoleWidth, ConsoleHeight);
            Console.CursorVisible = false;
            Console.Title = "Snake the Next Generation";

            // This changes the font. I have copy/pasted the whole ConsoleHelper class from
            // internet but it doesn't affect the actual game. Just the font.
            // The grading should disregard this class since it's not mine.
            ConsoleHelper.SetCurrentFont("Lucida Console", 16);

            // Displays start menu and waits for a random key.
            PrintMenu();
            Console.ReadKey();

            DateTime startTime = DateTime.Now;
            Loop();
            //Console.WriteLine(DateTime.Now - startTime);
        }


        /// <summary>
        /// Prints out the Snake menu with short instructions.
        /// </summary>
        static void PrintMenu()
        {
            Console.WriteLine("\n\n     WELCOME TO...\n\n");
            Console.WriteLine("     QQQQQQQ   Q     Q      Q       Q    Q    QQQQQQQQ ");
            Console.WriteLine("    Q          QQ    Q     Q Q      Q   Q     Q        ");
            Console.WriteLine("    Q          Q Q   Q    Q   Q     Q  Q      Q        ");
            Console.WriteLine("    Q          Q Q   Q   Q     Q    Q Q       Q        ");
            Console.WriteLine("     QQQQQQ    Q  Q  Q   QQQQQQQ    QQ        QQQQQQ   ");
            Console.WriteLine("           Q   Q   Q Q   Q     Q    Q Q       Q        ");
            Console.WriteLine("           Q   Q   Q Q   Q     Q    Q  Q      Q        ");
            Console.WriteLine("           Q   Q    QQ   Q     Q    Q   Q     Q        ");
            Console.WriteLine("    QQQQQQQ    Q     Q   Q     Q    Q    Q    QQQQQQQQ ");
            Console.WriteLine("\n\n    Move using the arrow keys. Press Q to Quit.");
            Console.WriteLine("\n\n\n          Press any key to continue.");
        }


        /// <summary>
        /// This method changes the frame rate to the amount in the supplied int.
        /// </summary>
        /// <param name="fps">Between 1-30.</param>
        public static void ChangeFrameRate (int fps)
        {
            // Some simple error-checking.
            if (fps >= 1 && fps <= 30)
            {
                frameRate = fps;
            }
        }
    }
}
