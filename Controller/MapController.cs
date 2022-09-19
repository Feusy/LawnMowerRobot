using Models;

namespace Controllers
{
    public class MapController
    {
        Map map = new Map();
        public List<int[]> GenerateMap()
        {
            //Simulate map
            map.MapCoordiantes = new List<int[]>();
            map.Width = 42;
            map.Height = 42;
            map.Margin = 2;

            for (int i = map.Margin; i < map.Width; i++)
            {
                for (int j = map.Margin; j < map.Height; j++)
                {
                    map.MapCoordiantes.Add(new int[] { i, j });
                }
            }
            map.MoweredArea = map.MapCoordiantes;
            return map.MapCoordiantes;
        }
        
        public int[] GetMapEdges()
        {
           //Margin -> Start , Width -> Max , Height -> Max
            return new int[] {map.Margin, map.Width, map.Height};
        }

        public List<int[]> MowerArea()
        {
            return map.MoweredArea;
        }
    }
}
