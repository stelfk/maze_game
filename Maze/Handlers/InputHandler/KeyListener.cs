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


                    default: break;
                }
            }
        }
    }
}