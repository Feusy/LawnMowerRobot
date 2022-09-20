using Controllers;

namespace ViewModels
{
    public interface IRobot
    {
        public void OnMovingEvent(object sender, CoordinatesEventArgs e);
        public void GetMap();
        public void GetObstracles();
        public void GetStartPosition();
        public void StartMower();
        public void GoLeftToRight();
        public void GoRigthToLeft();
        public void GoHome();

    }
}
