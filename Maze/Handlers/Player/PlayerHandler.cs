using System.Collections;

namespace Maze {
    class PlayerHandler {
        public Player plrOne = new Player(1, 20, "☻");
        public Player plrTwo = new Player(1, 2, "*");
        
        //public Player[] players = new Player[]{};
        public List<Player> players = new List<Player>();

        public int maxPlayers = Maze.Program.maxPlayers;

        /*
        *
        * Important:
        *       Use this when starting the game/starting a new
        *   level. Two player *NOT* setup yet!
        *
        * Syntax:
        *       1 (default): Single player (wasd)
        *       2: Two players - arrow keys (arrow keys)
        *
        */
        public void gameMode(int plrCount = 1) {
            players.Clear();
            if (plrCount < 1 || plrCount > maxPlayers) {} else {
                players.Add(plrOne);
                if (plrCount == 2) {
                    players.Add(plrTwo);
                }
            }
        }
    }
}