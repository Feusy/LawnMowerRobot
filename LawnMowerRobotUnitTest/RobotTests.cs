using ViewModels;
using ConsoleUI;
using Models;
using Controllers;


namespace LawnMowerRobotUnitTest
{
    public class RobotTests
    {
        [Theory]
        [InlineData(2, 14)]
        [InlineData(4, 24)]
        public void RobotShouldMoveIfNoObstacleAhead(int x, int y)
        {
            //Arrange
            MotorController motorController = new MotorController();
            SensorController sensorController = new SensorController();

            //Act
            sensorController.GenerateObstacles();

            //Assert
            Assert.True(motorController.MoveXMinus(new int[] { x, y }, sensorController));
        
        }

        [Theory]
        [InlineData(new int[] { 8, 7 })]
        [InlineData(new int[] {31,25})]
        public void RobostShouldNotMoveIfObstacleAhead(int[] obstacles)
        {
            //Arrange
            MotorController motorController = new MotorController();
            SensorController sensorController = new SensorController();

            //Act
            sensorController.GenerateObstacles();

            //Assert
            Assert.False(motorController.MoveXPlus(obstacles, sensorController));


        }
    }
}

