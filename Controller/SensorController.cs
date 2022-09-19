using Models;

namespace Controllers
{
    public class SensorController
    {
        Sensor sensor = new Sensor();
        public List<int[]> GenerateObstacles()
        {
            sensor.Obstacles = new List<int[]>()
            {
                new int[] { 4, 7 },
                new int[] { 14, 21 },
                new int[] { 22, 10 },
                new int[] { 22, 11 },
                new int[] { 30, 16 },
                new int[] { 31, 16 },
                new int[] { 32, 25 },
                new int[] { 31, 26 },
                new int[] { 33, 26 },
                new int[] { 6, 33 },
                new int[] { 6, 34 },
                new int[] { 7, 34 },
                new int[] { 7, 33 }
            };

            return sensor.Obstacles;
        }

        //Sensor check
        public bool ObstacleAhead(int x, int y)
        {
            foreach (var item in sensor.Obstacles)
            {
                if (item[0] == x && item[1] == y)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
