using Models;

namespace Controllers
{
    public class SensorController
    {
        Sensor sensor = new Sensor();
        public List<int[]> GenerateObstacles()
        {  
            //Generate Random Shapes
            sensor.Obstacles = new List<int[]>()
            {
                new int[] { 9, 7 },
                new int[] { 14, 21 },
                new int[] { 22, 10 },
              //  new int[] { 22, 11 },
                new int[] { 30, 16 },
             //   new int[] { 31, 16 },
                new int[] { 32, 25 },
             //   new int[] { 31, 26 },
             //   new int[] { 33, 26 },
             //   new int[] { 6, 33 },
             //   new int[] { 6, 34 },
             //   new int[] { 7, 34 },
                new int[] { 7, 33 }
            };

            return sensor.Obstacles;
        }

        //Sensor check
        public bool ObstacleAhead(int[] position)
        {
            foreach (var item in sensor.Obstacles)
            {
                if (item[0] == position[0] && item[1] == position[1])
                {
                    return true;
                }
            }
            return false;
        }

    }
}
