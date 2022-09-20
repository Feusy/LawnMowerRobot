using Controllers;

namespace ViewModels;

public class RobotViewModel : IRobot
{
    IVisualizer visualizer;
    GpsController gps = new GpsController();
    SensorController sensor = new SensorController();
    MapController map = new MapController();
    MotorController motor = new MotorController();

    //Moving Event Subscriber
    public void OnMovingEvent(object sender, CoordinatesEventArgs e)
    {
        gps.PositionChanged(e.Coordinates);
    }

    //ctor
    public RobotViewModel(IVisualizer visualizer)
    {
        this.visualizer = visualizer;
        motor.Moving += OnMovingEvent;
        motor.Moving += visualizer.OnDrawCurrentPos;
        motor.Moving += visualizer.OnDrawLastPost;
    }

    public void GetMap()
    {
        visualizer.DrawMap(map.GenerateMap());
    }

    public void GetObstracles()
    {
        int[] sides = map.GetMapEdges();
        int margin = sides[0];
        int width = sides[1];
        int height = sides[2];

        //Generate edges
        List<int[]> result = sensor.GenerateObstacles();
        for (int i = margin; i < width; i++)
        {
            result.Add(new int[] { i, margin });
            result.Add(new int[] { i, height });
        }

        //Shape sides
        for (int i = margin; i < height + 1; i++)
        {
            result.Add(new int[] { margin, i, });
            result.Add(new int[] { width, i });
        }

        visualizer.DrawObstacles(result);
    }
    public void GetStartPosition()
    {
        visualizer.DrawHomePosition(gps.GenerateStartPosition());
    }
    public void StartMower()
    {
        GoLeftToRight();
        GoHome();
        GoRigthToLeft();
        GoHome();
    }

    public void GoLeftToRight()
    {
        //Move left to rigth while no map edges
        bool bottom = false;
        while (!bottom)
        {
            while (gps.CurrentPosition()[0] < map.GetMapEdges()[1] - 1)
            {
                motor.MoveXPlus(gps.CurrentPosition(), sensor);
            }

            if (!motor.MoveYPlus(gps.CurrentPosition(), sensor))
            {
                bottom = true;
            }

            while (gps.CurrentPosition()[0] > map.GetMapEdges()[0] + 1 && !bottom)
            {
                motor.MoveXMinus(gps.CurrentPosition(), sensor);
            }

            if (!motor.MoveYPlus(gps.CurrentPosition(), sensor))
            {
                bottom = true;
            }
        }
    }
    public void GoRigthToLeft()
    {
        //Move right to left while no map edges
        bool top = false;
        while (!top)
        {
            while (gps.CurrentPosition()[0] > map.GetMapEdges()[0] + 1)
            {
                motor.MoveXMinus(gps.CurrentPosition(), sensor);
            }

            if (!motor.MoveYMinus(gps.CurrentPosition(), sensor))
            {
                top = true;
            }

            while (gps.CurrentPosition()[0] < map.GetMapEdges()[1] - 1 && !top)
            {
                motor.MoveXPlus(gps.CurrentPosition(), sensor);
            }

            if (!motor.MoveYMinus(gps.CurrentPosition(), sensor))
            {
                top = true;
            }
        }
    }
    public void GoHome()
    {
        motor.GoToStartPosition(gps.CurrentPosition(), gps.HomePosition, sensor);
    }
}
