using Models;

namespace Controllers
{
    public class GpsController
    {
        Gps gps = new Gps();

        public int[] GenerateStartPosition()
        {
            Random rnd = new Random();
            return gps.CurrentPosition = gps.StartPosition = new int[] { rnd.Next(3, 39), rnd.Next(3, 32) };
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
            gps.LastPosition = gps.CurrentPosition;
            gps.CurrentPosition = movingPosition;
        }

       
    }
}
