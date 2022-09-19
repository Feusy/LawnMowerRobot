
namespace Models
{
    public class StepperMotor
    {
        public int MoveXPlus(int x)
        {
            return x++;
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

       
    }
}
