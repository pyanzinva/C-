using System;
using System.Threading;

public class Robot
{
    private int x;
    private int y;
    private int direction;
    private Random random;
    private bool isMoving;
    private string name;

    public Robot(string robotName, int initialX, int initialY)
    {
        name = robotName;
        x = initialX;
        y = initialY;
        random = new Random();
        direction = random.Next(4);
        isMoving = false;
    }

    public void Move()
    {
        while (isMoving)
        {
            switch (direction)
            {
                case 0:
                    y++;
                    break;
                case 1:
                    y--;
                    break;
                case 2:
                    x++;
                    break;
                case 3:
                    x--;
                    break;
            }

            direction = random.Next(4);
            Thread.Sleep(1000);
        }
    }

    public void StartMoving()
    {
        if (!isMoving)
        {
            isMoving = true;
            Thread moveThread = new Thread(Move);
            moveThread.Start();
        }
    }

    public void StopMoving()
    {
        isMoving = false;
    }

    public void DisplayInfo()
    {
        while (isMoving)
        {
            string directionStr = "";
            switch (direction)
            {
                case 0:
                    directionStr = "Вперед";
                    break;
                case 1:
                    directionStr = "Назад";
                    break;
                case 2:
                    directionStr = "Вправо";
                    break;
                case 3:
                    directionStr = "Влево";
                    break;
            }

            Console.WriteLine($"{name}: {directionStr} ({x}, {y})");
            Thread.Sleep(1000);
        }
    }

    public void StartDisplayingInfo()
    {
        Thread displayThread = new Thread(DisplayInfo);
        displayThread.Start();
    }

    static void Main(string[] args)
    {
        Robot robot1 = new Robot("MyRobot1", 0, 0);
        Robot robot2 = new Robot("MyRobot2", 0, 0);

        robot1.StartMoving();
        robot1.StartDisplayingInfo();

        robot2.StartMoving();
        robot2.StartDisplayingInfo();

        Thread.Sleep(5000);

        robot1.StopMoving();
        robot2.StopMoving();
    }
}
