using ViewModels;
using Controllers;

namespace ConsoleUI
{
    public class DrawHelper : IVisualizer
    {
        private int[] HomePoint = new int[2];

        public void DrawMap(List<int[]> mapCoordinates)
        {
            foreach (var item in mapCoordinates)
            {
                Console.SetCursorPosition(item[0], item[1]);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("█");
            }
        }
        public void DrawObstacles(List<int[]> obstracles)
        {
            foreach (var item in obstracles)
            {
                Console.SetCursorPosition(item[0], item[1]);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write("O");
            }

        }
        public void DrawHomePosition(int[] coordinates)
        {
            HomePoint = coordinates;
            int xcoord = coordinates[0];
            xcoord++;
            Console.SetCursorPosition(xcoord, coordinates[1]);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("H");
        }
        public void DrawCurrentPosition(int x, int y)
        {
            if (HomePoint[0] != x || HomePoint[1] != y)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("R");
                Thread.Sleep(15);
            }

        }
        public void DrawLastPosition(int x, int y)
        {
            if (HomePoint[0] != x || HomePoint[1] != y)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("█");
            }


        }


        //Event subscribers
        public void OnDrawCurrentPos(object sender, CoordinatesEventArgs e)
        {
            DrawCurrentPosition(e.Coordinates[0], e.Coordinates[1]);
        }

        public void OnDrawLastPost(object sender, CoordinatesEventArgs e)
        {
            DrawLastPosition(e.Coordinates[0], e.Coordinates[1]);
        }
    }

}
