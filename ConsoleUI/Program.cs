using ConsoleUI;
using ViewModels;


//Starting the program
Start:
Console.CursorVisible = false;
Console.Clear();

IRobot rvm = new RobotViewModel(new DrawHelper());

//Map setup
rvm.GetMap();
rvm.GetObstracles();

//Robot setup
rvm.GetStartPosition();

Console.SetCursorPosition(0, 0);
Console.ForegroundColor = ConsoleColor.Red;
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("Press any key to start the robot or press R to restart the process");

//Restart the program
ConsoleKey key = ConsoleKey.R;
if (key == Console.ReadKey().Key)
{
    goto Start;
}

Console.SetCursorPosition(0, 0);
Console.WriteLine("                                                                       ");

//Start process
rvm.StartMower();


// End of law mower algorithm
Console.SetCursorPosition(0, 45);
Console.ForegroundColor = ConsoleColor.Red;
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("Press any key to exit");
Console.ReadKey();
Console.Clear();


