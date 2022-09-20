using ConsoleUI;
using ViewModels;

//Starting the program
Console.CursorVisible = false;

IRobot rvm = new RobotViewModel(new DrawHelper());

//Map setup
rvm.GetMap();
rvm.GetObstracles();

//Robot setup
rvm.GetStartPosition();

//Start process
rvm.StartMower();


// End of law mower algorithm
Console.SetCursorPosition(0, 45);
Console.ForegroundColor = ConsoleColor.Red;
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("Press any key to exit");
Console.ReadKey();



