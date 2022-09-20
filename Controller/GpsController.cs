using Models;

namespace Controllers
{
    public class GpsController
    {
        Gps gps = new Gps();
        public int[] HomePosition { get; set; }
        public int[] LastPosition { get; set; }
        public int[] GenerateStartPosition()
        {
            Random rnd = new Random();
            return  HomePosition =gps.CurrentPosition = gps.StartPosition = new int[] { rnd.Next(3, 39), rnd.Next(3, 32) };
        }
        public int[] CurrentPosition()
        {
            try
            {
                return gps.CurrentPosition;
            }
            catch (NullReferenceException e)
            {
                Console.Write("GPS connection lost: " + e.Message);
                return gps.StartPosition;
            }
        }
        public void PositionChanged(int[] movingPosition)
        {
            LastPosition = gps.CurrentPosition;
            gps.CurrentPosition = movingPosition;
        }     
    }
}
