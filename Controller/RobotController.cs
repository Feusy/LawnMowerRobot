using Models;

namespace Controllers
{
    public class RobotController
    {
        Gps gps = new Gps();
        Map map = new Map();
        Sensor sensor = new Sensor();
        StepperMotor motor = new StepperMotor();

        public List<int[]> GenerateMap()
        {
            //Simulate map
            List<int[]> mapCooridnates = new List<int[]>();
            map.Width = 40;
            map.Height = 40;
            map.Margin = 2;

            for (int i = map.Margin; i < map.Width; i++)
            {
                for (int j = map.Margin; j < map.Height; j++)
                {
                    mapCooridnates.Add(new int[] { i, j });
                }
            }

            return mapCooridnates;
        }

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
        public int[] GenerateStartPosition()
        {
            Random rnd = new Random();
            return gps.StartPosition = new int[] { rnd.Next(3, 39), rnd.Next(3, 32) };
        }
        public void StartMower()
        {
            
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
        public int[] LastPosition()
        {
            try
            {
                return gps.LastPosition;
            }
            catch (NullReferenceException e)
            {
                Console.Write("GPS connection lost: " + e.Message);
                return gps.StartPosition;
            }
        }
        public void DodgeObstacle()
        {

        }
        public void GoToStartPosition()
        {
           
        }



    }
}
