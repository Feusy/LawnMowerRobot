using Models;

namespace Controllers
{
    public class MotorController
    {
        StepperMotor motor = new StepperMotor();

        //Moving Event
        public event EventHandler<CoordinatesEventArgs>? Moving;
        protected virtual void OnMovingEvent()
        {
            if (Moving != null)
            {
                Moving(this, new CoordinatesEventArgs() { Coordinates = new int[] { motor.Xcoordinate, motor.Ycoordinate } });
            }
        }

        public void MoveXPlus(int[] coordinates)
        {
            motor.Xcoordinate = coordinates[0]++;
            motor.Ycoordinate = coordinates[1];
            OnMovingEvent();
        }
        public int MoveXMinus(int x)
        {
            return x--;
        }

        public int MoveYPlus(int y)
        {
            return y++;
        }

        public int MoveYMinus(int y)
        {
            return y--;
        }
        public void DodgeObstacle()
        {

        }
        public void GoToStartPosition()
        {

        }
    }
}
