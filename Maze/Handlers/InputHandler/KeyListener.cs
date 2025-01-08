namespace Maze {
    class KeyListener {
        public static void inGameListener() {
            if (Console.KeyAvailable) {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.Key) {
                    
                    // PLAYER MOVEMENT
                    case ConsoleKey.S:
                        if (Program.plrHandler.players[0] != null) {
                            Program.currentMap[Program.plrHandler.players[0].X, Program.plrHandler.players[0].Y] = " ";
                            Program.plrHandler.players[0].X++;
                        }
                    break;

                    default: break;
                }
            }
        }
    }
}