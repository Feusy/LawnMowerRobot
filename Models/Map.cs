namespace Models
{
    public class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Margin { get; set; }
        public int[] MapEdges { get; set; }
        public List<int[]>? MapCoordiantes { get; set; }
        public List<int[]>? MoweredArea { get; set; }
    }
}

