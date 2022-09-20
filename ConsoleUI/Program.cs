using ConsoleUI.Config;
using ConsoleUI.ViewModels;

//Starting the program
Console.CursorVisible = false;

IVisualizer draw = new DrawHelper();
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
Console.ReadKey();

//Start process

rvm.DrawCurrentPos += draw.OnDrawCurrentPos;
rvm.DrawCurrentPos += draw.OnDrawLastPost;

rvm.StartMower();


// End of law mower algorithm
Console.SetCursorPosition(0, 45);
Console.ForegroundColor = ConsoleColor.Red;
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("Press any key to exit");
Console.ReadKey();



