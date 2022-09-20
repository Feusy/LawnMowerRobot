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
        public event EventHandler<CoordinatesEventArgs>? DrawCurrentPos;
        protected virtual void OnDrawCurremtPos()
        {
            if (DrawCurrentPos != null)
            {
                DrawCurrentPos(this, new CoordinatesEventArgs() { Coordinates = gps.CurrentPosition() });
            }
        }
        public event EventHandler<CoordinatesEventArgs>? DrawLastPos;
        protected virtual void OnDrawLastPos()
        {
            if (DrawLastPos != null)
            {
                DrawLastPos(this, new CoordinatesEventArgs() { Coordinates = gps.LastPosition });
            }
        }

        //Moving Event Subscriber
        public void OnMovingEvent(object sender, CoordinatesEventArgs e)
        {
            gps.PositionChanged(e.Coordinates);
            OnDrawLastPos();
            OnDrawCurremtPos();
            
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
            GoLeftToRight();
            GoHome();
            GoRigthToLeft();
            GoHome();


        }
    
        private void GoLeftToRight()
        {
            bool bottom = false;
            //Move left to rigth while no map edges
            while (!bottom)
            {
                while (gps.CurrentPosition()[0] < map.GetMapEdges()[1] - 1)
                {
                    motor.MoveXPlus(gps.CurrentPosition(), sensor);
                }
                motor.MoveYPlus(gps.CurrentPosition(), sensor);

                while (gps.CurrentPosition()[0] > map.GetMapEdges()[0] + 1)
                {
                    motor.MoveXMinus(gps.CurrentPosition(), sensor);
                }

                if (!motor.MoveYPlus(gps.CurrentPosition(), sensor))
                {
                    bottom = true;
                }
            }
        }

        private void GoRigthToLeft()
        {
            bool top = false;
            //Move right to left while no map edges
            while (!top)
            {
                while (gps.CurrentPosition()[0] > map.GetMapEdges()[0] + 1)
                {
                    motor.MoveXMinus(gps.CurrentPosition(), sensor);
                }
                motor.MoveYMinus(gps.CurrentPosition(), sensor);

                while (gps.CurrentPosition()[0] < map.GetMapEdges()[1] - 1)
                {
                    motor.MoveXPlus(gps.CurrentPosition(), sensor);
                }

                if (!motor.MoveYMinus(gps.CurrentPosition(), sensor))
                {
                    top = true;
                }
            }
        }
        private void GoHome()
        {
            motor.GoToStartPosition(gps.CurrentPosition(), gps.HomePosition, sensor);
        }


    }
}
