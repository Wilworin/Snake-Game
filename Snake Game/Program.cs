using System;
using System.Threading;

namespace Snake_Game
{
    class Program
    {
        public static int frameRate = 5; // Changed it to a non-const so I could change the fps during play.
        private static bool isRunning = true;

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
            Player player = new Player(ConsoleWidth / 2, ConsoleHeight / 2);
            GameWorld world = new GameWorld(ConsoleWidth, ConsoleHeight);
            world.SetPlayer(player); // This is mainly used to get access to the tail.
            ConsoleRenderer renderer = new ConsoleRenderer(world);


            // Main loop
            while (isRunning)
            {
                // Remember the time from the start of the frame.
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
                    default:
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
            DisplayGameOver(world.score, world.GameSeconds());
            Console.ReadKey();
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
            DisplayMenu();
            Console.ReadKey();

            Loop();
        }


        /// <summary>
        /// Prints out the Snake menu with short instructions.
        /// </summary>
        static void DisplayMenu()
        {
            Console.WriteLine("\n\n         WELCOME TO...\n\n");
            Console.WriteLine("             ███████   █     █      █       █    █    ████████ ");
            Console.WriteLine("            █          ██    █     █ █      █   █     █        ");
            Console.WriteLine("            █          █ █   █    █   █     █  █      █        ");
            Console.WriteLine("            █          █ █   █   █     █    █ █       █        ");
            Console.WriteLine("             ██████    █  █  █   ███████    ██        ██████   ");
            Console.WriteLine("                   █   █   █ █   █     █    █ █       █        ");
            Console.WriteLine("                   █   █   █ █   █     █    █  █      █        ");
            Console.WriteLine("                   █   █    ██   █     █    █   █     █        ");
            Console.WriteLine("            ███████    █     █   █     █    █    █    ████████ ");
            Console.WriteLine("\n\n\n\n               Move using the arrow keys. Press Q to Quit.");
            Console.WriteLine("\n             Food will teleport after 10 seconds if not eaten.");
            Console.WriteLine("\n\n\n                  KEEP AN EYE ON THE EAT OR DIE TIMER!!!");
            Console.WriteLine("\n\n\n                       Press any key to continue.");
        }


        /// <summary>
        /// Displays the Game Over text.
        /// </summary>
        /// <param name="score">Players score</param>
        /// <param name="timer">Elapsed time</param>
        static void DisplayGameOver(int score, int timer)
        {
            // This method is really only designed for 80 chars width so it looks fugly if I change the size to less. 
            Console.WriteLine("\n\n\n\n\n█   ████       █     █     █  ███████      ██     █     █  ███████  █████    █");
            Console.WriteLine("█ ██    ██    █ █    ██   ██  █          ██  ██   █     █  █        █    █   █");
            Console.WriteLine("█ █          █   █   █ █ █ █  █         █      █  █     █  █        █     █  █");
            Console.WriteLine("█ █         █     █  █  █  █  █         █      █  █     █  █        █    █   █");
            Console.WriteLine("█ █   ████  ███████  █     █  █████     █      █  █     █  █████    █████    █");
            Console.WriteLine("█ █      █  █     █  █     █  █         █      █   █   █   █        █   █    █");
            Console.WriteLine("█ █      █  █     █  █     █  █         █      █   █   █   █        █    █    ");
            Console.WriteLine("█  ██  ██   █     █  █     █  █          ██  ██     █ █    █        █     █  █");
            Console.WriteLine("█    ██     █     █  █     █  ███████      ██        █     ███████  █     █  █\n\n\n\n");
            Console.WriteLine($"█     Your score was: {score} and you played for: {timer} seconds.\n\n\n\n");
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


        /// <summary>
        /// Changes the isRunning to false, thus causing the main loop to stop.
        /// </summary>
        public static void SetGameOver()
        {
            isRunning = false;
        }
    }
}
