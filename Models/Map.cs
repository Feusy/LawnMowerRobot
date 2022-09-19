
namespace Models
{
    public class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Margin { get; set; }
        public int[,]? MapCoordiantes { get; set; }
        public int[,]? MoweredArea { get; set; }
    }
}
