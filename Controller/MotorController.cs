using Models;
using Controllers;

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

        public bool MoveXPlus(int[] coordinates ,SensorController sensor)
        {
            coordinates[0]++;

            //Check sensor before moving
            if (!sensor.ObstacleAhead(coordinates))
            {
                motor.Xcoordinate = coordinates[0];
                motor.Ycoordinate = coordinates[1];
                OnMovingEvent();
                return true;
            }
            else
            {
                coordinates[0]--;
                return false;
            }
            
            
        }
        public bool MoveXMinus(int[] coordinates, SensorController sensor)
        {
            coordinates[0]--;

            //Check sensor before moving
            if (!sensor.ObstacleAhead(coordinates))
            {
                motor.Xcoordinate = coordinates[0];
                motor.Ycoordinate = coordinates[1];
                OnMovingEvent();
                return true;
            }
            else
            {
                coordinates[0]++;
                return false;
            }

        }

        public bool MoveYPlus(int[] coordinates, SensorController sensor)
        {
         
            coordinates[1]++;

            //Check sensor before moving
            if (!sensor.ObstacleAhead(coordinates))
            {
                motor.Xcoordinate = coordinates[0];
                motor.Ycoordinate = coordinates[1];
                OnMovingEvent();
                return true;
            }
            else
            {
                coordinates[1]--;
                return false;
            }

        }

        public bool MoveYMinus(int[] coordinates, SensorController sensor)
        {
            coordinates[1]--;

            //Check sensor before moving
            if (!sensor.ObstacleAhead(coordinates))
            {
                motor.Xcoordinate = coordinates[0];
                motor.Ycoordinate = coordinates[1];
                OnMovingEvent();
                return true;
            }
            else
            {
                coordinates[1]++;
                return false;
            }

        }
        public void DodgeObstacle()
        {

        }
        public void GoToStartPosition()
        {

        }
    }
}
