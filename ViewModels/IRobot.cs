using Controllers;

namespace ViewModels
{
    public interface IRobot
    {
        public event EventHandler<CoordinatesEventArgs>? CurrentPosition;
        public event EventHandler<CoordinatesEventArgs>? LastPosition;
        public void OnMovingEvent(object sender, CoordinatesEventArgs e);
        public List<int[]> GetMap();
        public List<int[]> GetObstracles();
        public int[] GetStartPosition();
        public void StartMower();
        public void GoLeftToRight();
        public void GoRigthToLeft();
        public void GoHome();

    }
}
