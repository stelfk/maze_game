using System.Diagnostics;
using System.Net.Quic;
using System.Runtime.CompilerServices;

namespace Maze {
    class Program {
        // Handlers
        public static PlayerHandler plrHandler = new PlayerHandler();
        public static InputHandler inputHandler = new InputHandler();
        public static MapHandler mapHandler = new MapHandler(); 

        // Game settings etc.
        public static Boolean showfps = true;
        public static int refreshDelay = 32;
        public static Boolean quit = false;
        public const int maxPlayers = 2;
        public static int plrCount = 1;

        // Game stage
        public static string currentLevel = "m0";
        //public static string[,]? currentMap;
        public static string[,] currentMap = Maps.maze00;

        public static int gameState = 1; // 0 = menu; 1 = in game; 2 = paused

        // Game functions
        static void sleep(int ms) {
            Thread.Sleep(ms);
        }

        static void setup() {
            // Create maze
            mapHandler.chooseMap(currentLevel);

            // Handle player(s)
            plrHandler.gameMode(plrCount);
        }

        // Main loop
        static void Main(String[] args) {
            // Game state handling
            while (gameState == 0) {
                /* 
                * 
                *   TODO:
                *       Make menu - starting screen 
                *
                */
            }

            // Initial setup
            setup();

            // FPS - Yes, ChatGPT
            Stopwatch stopwatch = new Stopwatch();
            double frameTime = 0;                       // Time taken for the last frame in ms
            double fps = 0;                             // Frames Per Second

            // Game loop
            while (!quit) {
                // Start timing frame
                stopwatch.Restart();

                // Listen to keyboard
                inputHandler.update();

                // Update maze
                mapHandler.updateMap(
                    currentMap == null ? Maps.maze00 : currentMap,
                    plrHandler.players
                );

                // Draw maze
                mapHandler.drawMap(
                    currentMap == null ? Maps.maze00 : currentMap
                );
                
                // Calculate and show fps
                stopwatch.Stop();
                frameTime = stopwatch.Elapsed.TotalMilliseconds + refreshDelay;
                fps = frameTime > 0 ? 1000 / frameTime : 0;
                if (showfps) Console.WriteLine($"FPS: {Math.Round(fps)}");

                // Clear screen
                sleep(refreshDelay);
                Console.Clear();
            }
        }
    }
}