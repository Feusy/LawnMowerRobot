using Controllers;

namespace ConsoleUI.ViewModels
{
    public class RobotViewModel
    {
        GpsController gps = new GpsController();
        SensorController sensor = new SensorController();
        MapController map = new MapController();
        MotorController motor = new MotorController();

        //Events
        public event EventHandler<CoordinatesEventArgs>? Drawing;
        protected virtual void OnDrawEvent()
        {
            if (Drawing != null)
            {
                Drawing(this, new CoordinatesEventArgs() { Coordinates = gps.CurrentPosition() });
            }
        }

        //Moving Event Subscriber
        public void OnMovingEvent(object sender, CoordinatesEventArgs e)
        {
            gps.PositionChanged(e.Coordinates);
            OnDrawEvent();
        }

        //ctor
        public RobotViewModel()
        {
            motor.Moving += OnMovingEvent;
        }

        public List<int[]> GetMap()
        {
            return map.GenerateMap();
        }

        public List<int[]> GetObstracles()
        {
            int[] sides = map.GetMapEdges();
            int margin = sides[0];
            int width = sides[1];
            int height = sides[2];

            //Generate edges
            List<int[]> result = sensor.GenerateObstacles();
            for (int i = margin; i < width; i++)
            {
                result.Add(new int[] { i, margin });
                result.Add(new int[] { i, height });
            }

            //Shape sides
            for (int i = margin; i < height + 1; i++)
            {
                result.Add(new int[] { margin, i, });
                result.Add(new int[] { width, i });
            }

            return result;
        }
        public int[] GetStartPosition()
        {
            return gps.GenerateStartPosition();
        }
        public void StartMower()
        {


            // Move left to right and down while map not ending

            bool move = true;
            bool bottom = false;

            while (!bottom)
            {
                while (move)
                {
                    move = motor.MoveXPlus(gps.CurrentPosition(), sensor);
                }

                motor.MoveYPlus(gps.CurrentPosition(), sensor);

                move = true;
                while (move)
                {
                    move = motor.MoveXMinus(gps.CurrentPosition(), sensor);
                }

                motor.MoveYPlus(gps.CurrentPosition(), sensor);
                move = true;
            }
        }
        public void GoHome()
        {
            motor.GoToStartPosition();
        }
    }
}
