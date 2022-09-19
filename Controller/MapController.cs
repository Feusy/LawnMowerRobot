using Models;

namespace Controllers
{
    public class MapController
    {
        Map map = new Map();
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
    
    }
}
