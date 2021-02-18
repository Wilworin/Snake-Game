using System;
using System.Threading;

namespace Snake_Game
{
    class Program
    {
        /// <summary>
        /// Checks Console to see if a keyboard key has been pressed, if so returns it as uppercase, otherwise returns '\0'.
        /// </summary>
        static char ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key.ToString().ToUpper()[0] : '\0';

        static void Loop()
        {
            // Initialisera spelet
            const int frameRate = 5;
            GameWorld world = new GameWorld();
            ConsoleRenderer renderer = new ConsoleRenderer(world);

            // TODO Skapa spelare och andra objekt etc. genom korrekta anrop till vår GameWorld-instans
            // ...
            // Huvudloopen
            bool isRunning = true;
            while (isRunning)
            {
                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;

                // Hantera knapptryckningar från användaren
                char key = ReadKeyIfExists();
                switch (key)
                {
                    case 'Q':
                        isRunning = false;
                        break;

                    // TODO Lägg till logik för andra knapptryckningar
                    // ...
                }

                // Uppdatera världen och rendera om
                world.Update();
                renderer.Render();

                // Mät hur lång tid det tog
                double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                if (frameTime > 0)
                {
                    // Vänta rätt antal millisekunder innan loopens nästa varv
                    Thread.Sleep((int)frameTime);
                }
            }
        }

        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;
            var a = new Player();

            Console.WriteLine(a.Look);
            //PrintMenu();
            // Vi kan ev. ha någon meny här, men annars börjar vi bara spelet direkt
            Loop();
            Console.WriteLine(DateTime.Now - startTime);
        }

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
            Console.WriteLine("");
        }
    }
}
