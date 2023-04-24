namespace mis_221_pa_5_jirafay
{
    public class MenuController
    {
        private int ItemsX, ItemsY;
            private int[]position = new int[2];
            private ConsoleKey key;

        public MenuController(int ItemsX, int ItemsY, int[] position, ConsoleKey key)
        {
            this.ItemsX = ItemsX;
            this.ItemsY = ItemsY;
            this.position = position;
            this.key = ConsoleKey.F1;
        }

    }
}