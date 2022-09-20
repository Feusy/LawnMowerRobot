
namespace Models
{
    public class StepperMotor
    {
        public int Xcoordinate { get; set; }
        public int Ycoordinate { get; set; }
        public MovingDirection MovedDirection = new MovingDirection() { XDirection = Directions.XPlus, YDirection = Directions.YPlus};
       
    }

    public partial class MovingDirection
    {
        public Directions XDirection { get; set; }
        public Directions YDirection { get; set; }
       

    }

    public enum Directions
    {
        XPlus,
        XMinus,
        YPlus,
        YMinus
    }

}
