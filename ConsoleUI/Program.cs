using ConsoleUI;
using ConsoleUI.ViewModels;

//Starting the program
Console.CursorVisible = false;
DrawHelper draw = new DrawHelper();
RobotViewModel rvm = new RobotViewModel();

//Map setup
draw.DrawMap(rvm.GetMap());
draw.DrawObstacles(rvm.GetObstracles());

//Robot setup
draw.DrawHomePosition(rvm.GetStartPosition()[0], rvm.GetStartPosition()[1]);
Console.SetCursorPosition(0, 0);
Console.ForegroundColor = ConsoleColor.Red;
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("Press any key to start the robot");
Console.ReadKey();

//Start process
rvm.StartMower();

if (rvm.MoweredCoordinates != null)
{
    while (rvm.MoweredCoordinates.Count > 0)
    {
        draw.DrawCurrentPosition(rvm.CurrentPosition()[0], rvm.CurrentPosition()[1]);
    }
}


//Finish mower
rvm.GoHome();

// End of law mower algorithm
Console.SetCursorPosition(0, 45);
Console.ForegroundColor = ConsoleColor.Red;
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("Press any key to exit");
Console.ReadKey();

