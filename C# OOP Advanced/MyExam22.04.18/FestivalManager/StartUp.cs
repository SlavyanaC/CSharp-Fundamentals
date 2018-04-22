namespace FestivalManager
{
    using Core;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;
    using Entities.Contracts;

    public static class StartUp
    {
        public static void Main(string[] args)
        {
            IStage stage = new Stage();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ISetController setController = new SetController(stage);
            IFestivalController festivalController = new FestivalController(stage, setController);

            var engine = new Engine(reader, writer, festivalController, setController);
            engine.Run();
        }
    }
}