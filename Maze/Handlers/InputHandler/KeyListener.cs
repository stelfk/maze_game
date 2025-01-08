namespace Maze {
    class KeyListener {
        public static void inGameListener() {
            if (Console.KeyAvailable) {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.Key) {
                    
                    // PLAYER MOVEMENT
                    case ConsoleKey.S: // Down
                        // Check if player can move
                        if (Program.currentMap[Program.plrHandler.players[0].X + 1, Program.plrHandler.players[0].Y] == " ") {
                            // Move player
                            Program.currentMap[Program.plrHandler.players[0].X, Program.plrHandler.players[0].Y] = " ";
                            Program.plrHandler.players[0].X++;
                        }
                    break;
                    case ConsoleKey.W: // Up
                        // Check if player can move
                        if (Program.currentMap[Program.plrHandler.players[0].X - 1, Program.plrHandler.players[0].Y] == " ") {
                            // Move player
                            Program.currentMap[Program.plrHandler.players[0].X, Program.plrHandler.players[0].Y] = " ";
                            Program.plrHandler.players[0].X--;
                        }
                    break;
                    case ConsoleKey.D: // Right
                        // Check if player can move
                        if (Program.currentMap[Program.plrHandler.players[0].X , Program.plrHandler.players[0].Y + 1] == " ") {
                            // Move player
                            Program.currentMap[Program.plrHandler.players[0].X, Program.plrHandler.players[0].Y] = " ";
                            Program.plrHandler.players[0].Y++;
                        }
                    break;
                    case ConsoleKey.A: // Left
                        // Check if player can move
                        if (Program.currentMap[Program.plrHandler.players[0].X , Program.plrHandler.players[0].Y - 1] == " ") {
                            // Move player
                            Program.currentMap[Program.plrHandler.players[0].X, Program.plrHandler.players[0].Y] = " ";
                            Program.plrHandler.players[0].Y--;
                        }
                    break;

                    // Misc.
                    case ConsoleKey.P:
                        Program.optionSelected = 0;
                        Program.gameState = 2;
                    break;


                    default: break;
                }
            }
        }

        public static void startMenu() {
            if (Console.KeyAvailable) {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.Key){
                    case ConsoleKey.UpArrow:
                        if (Program.optionSelected > 0) Program.optionSelected--;
                        else Program.optionSelected = 2;
                    break;

                    case ConsoleKey.DownArrow:
                        if (Program.optionSelected < 2) Program.optionSelected++;
                        else Program.optionSelected = 0;
                    break;

                    case ConsoleKey.Enter:
                        if (Program.optionSelected == 1) Program.gameState = 1;
                        if (Program.optionSelected == 2) {
                            Program.quit = true;
                        }
                    break;

                    default:
                    break;
                }
            }
        }
    }
}