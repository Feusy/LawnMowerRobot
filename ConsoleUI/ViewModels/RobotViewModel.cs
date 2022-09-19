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
            return sensor.GenerateObstacles();
        }
        public int[] GetStartPosition()
        {
            return gps.GenerateStartPosition();
        }
        public void StartMower()
        {
            motor.MoveXPlus(gps.CurrentPosition());

        }
        public void GoHome()
        {
            motor.GoToStartPosition();
        }

        
    }
}
