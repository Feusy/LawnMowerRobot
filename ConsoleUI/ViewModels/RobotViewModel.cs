using Controllers;

namespace ConsoleUI.ViewModels
{
    public class RobotViewModel
    {
        RobotController controller = new RobotController();
        public void GetMap()
        {
            controller.GenerateMap();
        }
    }
}
