using System;

namespace GrandPrix
{
    class StartUp
    {
        static void Main()
        {
            RaceTower raceTower = new RaceTower();
            Engine engine = new Engine(raceTower);
            engine.Run();
        }
    }
}
