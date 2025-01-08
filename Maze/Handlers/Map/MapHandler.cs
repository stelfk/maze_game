using System.Reflection;

namespace Maze {
    class MapHandler {
        public string[,] chooseMap(string level="m0") {
            if (level == "m0") return Maps.maze00;
            return Maps.maze00;
        }

        public void drawMap(string[,] maze) {
            for (int y = 0; y < maze.GetLength(0); y++) {
                for (int x = 0; x < maze.GetLength(1); x++) Console.Write(maze[y, x]);
                Console.WriteLine();
            }
        }

        public void updateMap(string[,] maze, List<Player> players) {
            // Put the player(s) in the map
            foreach (Player player in players) {
                maze[player.X, player.Y] = player.Icon;
            }
        }
    }
}