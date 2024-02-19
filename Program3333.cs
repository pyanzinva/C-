class Program
{
    static void Main()
    {
        Robot robot1 = new Robot("Название робота 1", 0, 0);
        Robot robot2 = new Robot("Название робота 2", 0, 0);

        robot1.StartMoving();
        robot1.StartDisplayingInfo();

        robot2.StartMoving();
        robot2.StartDisplayingInfo();

        Thread.Sleep(5000);

        robot1.StopMoving();
        robot2.StopMoving();

        Console.ReadLine();
    }
}
