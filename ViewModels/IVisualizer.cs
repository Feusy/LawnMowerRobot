using Controllers;

namespace ViewModels
{
    
    public interface IVisualizer
    {
        public void DrawMap(List<int[]> mapCoordinates);
        public void DrawObstacles(List<int[]> obstracles);
        public void DrawHomePosition(int[] coordinates);
        public void DrawCurrentPosition(int x, int y);
        public void DrawLastPosition(int x, int y);
        public void OnDrawCurrentPos(object sender, CoordinatesEventArgs e);
        public void OnDrawLastPost(object sender, CoordinatesEventArgs e);
    }
}
