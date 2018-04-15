namespace RecyclingStation
{
    using BsuinessLayer.Core;
    using BusinessLayer.Contracts.Core;
    using BusinessLayer.Contracts.Factories;
    using BusinessLayer.Contracts.IO;
    using BusinessLayer.Factories;
    using BusinessLayer.IO;
    using System;
    using System.Collections.Generic;
    using WasteDisposal;
    using WasteDisposal.Interfaces;

    public class RecyclingStationMain
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IStrategyHolder strategyHolder = new StrategyHolder(new Dictionary<Type, IGarbageDisposalStrategy>());

            IGarbageProcessor garbageProcessor = new GarbageProcessor(strategyHolder);
            IWasteFactory wasteFactory = new WasteFactory();

            IRecyclingStation recyclingStation = new RecyclingMenager(garbageProcessor, wasteFactory);

            IEngine engine = new Engine(reader, writer, recyclingStation);
            engine.Run();
        }
    }
}
