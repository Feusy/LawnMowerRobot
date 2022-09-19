using Controllers;

namespace ConsoleUI.ViewModels
{
    public class RobotViewModel
    {
        public List<int[]>? MoweredCoordinates { get; private set; }

        RobotController controller = new RobotController();
        public List<int[]> GetMap()
        {
            return MoweredCoordinates = controller.GenerateMap();
        }
        public List<int[]> GetObstracles()
        {
            return controller.GenerateObstacles();
        }
        public int[] GetStartPosition()
        {
            return controller.GenerateStartPosition();
        }

        public void StartMower()
        {
            controller.StartMower();
        }

        public int[] CurrentPosition()
        {
            return controller.CurrentPosition();
        }
        public int[] LastPosition()
        {
            return controller.LastPosition();
        }

        public void GoHome()
        {
            controller.GoToStartPosition();
        }

    }
}
