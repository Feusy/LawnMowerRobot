using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class DrawHelper
    {
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
                Console.Write("O");
            }
            
        }
        public void DrawHomePosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("H");
        }
        public void DrawCurrentPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("R");
            Thread.Sleep(20);
        }
        public void DrawLastPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("█");
        }
    }
}
