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
        public static int refreshDelay = 16;
        public static Boolean quit = false;
        public const int maxPlayers = 2;
        public static int plrCount = 1;

        // Game stage
        public static int gameState = 0; 
        // 0 = menu; 1 = in game; 2 = paused
        public static int optionSelected = 0;
        public static string currentLevel = "m0";
        public static string[,] currentMap = Maps.maze00;

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
            while (gameState == 0 && !quit) {
                Console.WriteLine("\n");
                Console.WriteLine("      ╔═════════════════╗");
                Console.WriteLine(optionSelected == 0 ?
                                        "      ║  OPTIONS        ║" :
                                        "      ║OPTIONS          ║"
                );
                Console.WriteLine(optionSelected == 1 ?
                                        "      ║  PLAY           ║" :
                                        "      ║PLAY             ║"
                );
                Console.WriteLine(optionSelected == 2 ?
                                        "      ║  QUIT           ║" :
                                        "      ║QUIT             ║"
                );
                Console.WriteLine("      ╚═════════════════╝");
                Console.WriteLine("\n");

                inputHandler.update(0);

                sleep(refreshDelay);
                Console.Clear();
            }

            // Initial setup
            setup();

            // FPS - Yes, ChatGPT
            Stopwatch stopwatch = new Stopwatch();
            double frameTime = 0;                       // Time taken for the last frame in ms
            double fps = 0;                             // Frames Per Second

            // Game loop
            while (!quit) {
                if (showfps) Console.WriteLine($"FPS: {Math.Round(fps)} \n");
                else Console.WriteLine("\n");
                
                // Start timing frame
                stopwatch.Restart();
                
                if (gameState == 1) { // In game
                    // Listen to keyboard
                    inputHandler.update(1);

                    // Update maze
                    mapHandler.updateMap(
                        currentMap == null ? Maps.maze00 : currentMap,
                        plrHandler.players
                    );

                    // Draw maze
                    mapHandler.drawMap(
                        currentMap == null ? Maps.maze00 : currentMap
                    );
                } else if (gameState == 2) { // Paused
                    Console.WriteLine("\n");
                    Console.WriteLine("      ╔═════════════════╗");
                    Console.WriteLine(optionSelected == 0 ?
                                            "      ║  OPTIONS        ║" :
                                            "      ║OPTIONS          ║"
                    );
                    Console.WriteLine(optionSelected == 1 ?
                                            "      ║  RESUME         ║" :
                                            "      ║RESUME           ║"
                    );
                    Console.WriteLine(optionSelected == 2 ?
                                            "      ║  QUIT           ║" :
                                            "      ║QUIT             ║"
                    );
                    Console.WriteLine("      ╚═════════════════╝");
                    Console.WriteLine("\n");

                    inputHandler.update(0);
                }
                
                Console.WriteLine("\n");
                if (gameState == 1) Console.WriteLine("Press p to pause the game");

                // Calculate and show fps
                stopwatch.Stop();
                frameTime = stopwatch.Elapsed.TotalMilliseconds + refreshDelay;
                fps = frameTime > 0 ? 1000 / frameTime : 0;
                //if (showfps) Console.WriteLine($"FPS: {Math.Round(fps)}");

                // Clear screen
                sleep(refreshDelay);
                Console.Clear();
            }
        }
    }
}