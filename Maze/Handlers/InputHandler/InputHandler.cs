namespace Maze {
    class InputHandler {

        public void update(int mode) {
            if (mode == 0) KeyListener.startMenu();
            if (mode == 1) KeyListener.inGameListener();
        }
    }
}