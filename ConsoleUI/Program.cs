using ConsoleUI;
using ConsoleUI.ViewModels;
using Controllers;

//Starting the program
Console.CursorVisible = false;
DrawHelper draw = new DrawHelper();
RobotViewModel rvm = new RobotViewModel();


//Map setup
draw.DrawMap(rvm.GetMap());
draw.DrawObstacles(rvm.GetObstracles());

//Robot setup
draw.DrawHomePosition(rvm.GetStartPosition());
Console.SetCursorPosition(0, 0);
Console.ForegroundColor = ConsoleColor.Red;
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("Press any key to start the robot");
//Console.ReadKey();

//Start process

rvm.Drawing += draw.OnDrawCurrentPos;

for (int i = 0; i < 4; i++)
{
    rvm.StartMower();
}

//Finish mower
rvm.GoHome();

// End of law mower algorithm
Console.SetCursorPosition(0, 45);
Console.ForegroundColor = ConsoleColor.Red;
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("Press any key to exit");
Console.ReadKey();



