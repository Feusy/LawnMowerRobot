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

        public bool MoveXPlus(int[] coordinates, SensorController sensor)
        {
            coordinates[0]++;

            //Check sensor before moving
            if (!sensor.ObstacleAhead(coordinates))
            {
                motor.Xcoordinate = coordinates[0];
                motor.Ycoordinate = coordinates[1];
                OnMovingEvent();
                motor.MovedDirection.XDirection = Directions.XPlus;
                return true;
            }
            else
            {
                coordinates[0]--;
                DodgeObstacle(coordinates, sensor);
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
                motor.MovedDirection.XDirection = Directions.XMinus;
                return true;
            }
            else
            {
                coordinates[0]++;
                DodgeObstacle(coordinates, sensor);
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
                motor.MovedDirection.YDirection = Directions.YPlus;
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
                motor.MovedDirection.YDirection = Directions.YMinus;
                return true;
            }
            else
            {
                coordinates[1]++;
                return false;
            }

        }
        public bool DodgeObstacle(int[] coordinates, SensorController sensor)
        {
            
            if (motor.MovedDirection.XDirection == Directions.XPlus && motor.MovedDirection.YDirection == Directions.YPlus)
            {
                MoveYPlus(coordinates, sensor);
                MoveXPlus(coordinates, sensor);
                MoveXPlus(coordinates, sensor);
                return MoveYMinus(coordinates, sensor);
            }
            else if (motor.MovedDirection.XDirection == Directions.XMinus && motor.MovedDirection.YDirection == Directions.YPlus)
            {
                MoveYPlus(coordinates, sensor);
                MoveXMinus(coordinates, sensor);
                MoveXMinus(coordinates, sensor);
                return MoveYMinus(coordinates, sensor);
            }
            else if (motor.MovedDirection.XDirection == Directions.XPlus && motor.MovedDirection.YDirection == Directions.YMinus)
            {
                MoveYMinus(coordinates, sensor);
                MoveXPlus(coordinates, sensor);
                MoveXPlus(coordinates, sensor);
                return MoveYPlus(coordinates, sensor);
            }
            else if (motor.MovedDirection.XDirection == Directions.XMinus && motor.MovedDirection.YDirection == Directions.YMinus)
            {
                MoveYMinus(coordinates, sensor);
                MoveXMinus(coordinates, sensor);
                MoveXMinus(coordinates, sensor);
                return MoveYPlus(coordinates, sensor);
            }
            else if (motor.MovedDirection.YDirection == Directions.YMinus)
            {
                if (MoveXMinus(coordinates, sensor))
                {
                    MoveXPlus(coordinates, sensor);
                    MoveYMinus(coordinates, sensor);
                    MoveYMinus(coordinates, sensor);
                    return MoveXMinus(coordinates, sensor);
                }
                else
                {
                    MoveYMinus(coordinates, sensor);
                    MoveYMinus(coordinates, sensor);
                    return MoveXPlus(coordinates, sensor);
                }
            }
            else if (motor.MovedDirection.YDirection == Directions.YPlus)
            {
                if (MoveXMinus(coordinates, sensor))
                {
                    MoveXPlus(coordinates, sensor);
                    MoveYPlus(coordinates, sensor);
                    MoveYPlus(coordinates, sensor);
                    return MoveXMinus(coordinates, sensor);
                }
                else
                {
                    MoveYPlus(coordinates, sensor);
                    MoveYPlus(coordinates, sensor);
                    return MoveXPlus(coordinates, sensor);
                }
            }
            else
            {
                return false;
            }
        }
        public void GoToStartPosition(int[] currentPosition, int[] homePosition, SensorController sensor)
        {

            //Bottom to top loop
            if (currentPosition[0] > homePosition[0])
            {
                while (currentPosition[0] > homePosition[0])
                {
                    MoveXMinus(currentPosition, sensor);
                }
            }
            else if (currentPosition[0] < homePosition[0])
            {
                while (currentPosition[0] < homePosition[0])
                {
                    MoveXPlus(currentPosition, sensor);
                }
            }

            //Top to bottom loop
            if (currentPosition[1] > homePosition[1])
            {
                while (currentPosition[1] > homePosition[1])
                {
                    MoveYMinus(currentPosition, sensor);
                }
            }
            else if (currentPosition[1] < homePosition[1])
            {
                while (currentPosition[1] < homePosition[1])
                {
                    MoveYPlus(currentPosition, sensor);
                }
            }
        }
    }
}
