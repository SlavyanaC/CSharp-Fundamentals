class LastArmyMain
{
    static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        IGameController gameController = new GameController(writer);

        IEngine engine = new Engine(reader, writer, gameController);
        engine.Run();
    }
}
