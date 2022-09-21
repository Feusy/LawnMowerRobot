using ViewModels;
using ConsoleUI;
using Models;
using Controllers;

namespace LawnMowerRobotUnitTest
{
    public class MapTest
    {
        [Fact]
        public void MapGenerated()
        {
            //Arrange
            MapController controller = new MapController();
            
            //Act
            List<int[]> IntArrayList = controller.GenerateMap();

            //ASSERT
            Assert.True(IntArrayList.Count > 0);
        }

    }
}