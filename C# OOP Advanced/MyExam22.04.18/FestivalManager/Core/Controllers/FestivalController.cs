namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string Error = "ERROR:";
        private const string Result = "Results:";
        private const string SongsPlayed = "--Songs played:";

        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private readonly IStage stage;
        private ISetController setController;
        private ISetFactory setFactory;
        private IInstrumentFactory instrumentFactory;

        public FestivalController(IStage stage, ISetController setController)
        {
            this.stage = stage;
            this.setController = setController;
            this.setFactory = new SetFactory();
            this.instrumentFactory = new InstrumentFactory();
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

            var result = string.Format(Output.RegisterSet, set.GetType().Name);
            return result;
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);
            IPerformer performer = new Performer(name, age);

            args = args.Skip(2).ToArray();
            foreach (var instrumentType in args)
            {
                IInstrument instrument = this.instrumentFactory.CreateInstrument(instrumentType);
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return string.Format(Output.RegisterPerformer, performer.Name);
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            TimeSpan duaration = TimeSpan.ParseExact(args[1], TimeFormat, CultureInfo.InvariantCulture);

            ISong song = new Song(name, duaration);
            this.stage.AddSong(song);

            return string.Format(Output.RegisterSong, song);
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException($"{Error} Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException($"{Error} Invalid song provided");
            }

            ISet set = this.stage.GetSet(setName);
            ISong song = this.stage.GetSong(songName);

            set.AddSong(song);

            var result = $"Added {song.Name} ({song.Duration:mm\\:ss}) to {set.Name}";
            return result;
        }

        public string AddPerformerToSet(string[] args)
        {
            string performerName = args[0];
            string setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException($"{Error} Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException($"{Error} Invalid set provided");
            }

            IPerformer performer = this.stage.GetPerformer(performerName);
            ISet set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        public string ProduceReport()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(Result);
            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            var formattedTotalTime = string.Empty;
            if (totalFestivalLength.Hours > 0)
            {
                formattedTotalTime = $"{totalFestivalLength.TotalMinutes}:{totalFestivalLength.Seconds:D2}";
            }
            else
            {
                formattedTotalTime = $"{totalFestivalLength:mm\\:ss}";
            }

            builder.AppendLine(string.Format(Output.TotalFestivalLength, formattedTotalTime));

            foreach (var set in this.stage.Sets)
            {
                var actualDuration = string.Empty;
                if (set.ActualDuration.Hours > 0)
                {
                    actualDuration = $"{set.ActualDuration.TotalMinutes}:{set.ActualDuration.Seconds:D2}";
                }
                else
                {
                     actualDuration = $"{set.ActualDuration:mm\\:ss}";
                }

                builder.AppendLine(string.Format(Output.FinalSetLength, set.Name, actualDuration));

                foreach (var performer in set.Performers.OrderByDescending(p => p.Age))
                {
                    builder.Append($"---{performer} ");
                    string finalInstruments = string.Join(", ", performer.Instruments.OrderByDescending(i => i.Wear));
                    builder.AppendLine(string.Format(Output.FinalPerformerInstruments, finalInstruments));
                }

                if (set.Songs.Count > 0)
                {
                    builder.AppendLine(SongsPlayed);
                    foreach (var song in set.Songs)
                    {
                        builder.AppendLine($"----{song}");
                    }
                }
                if (set.Songs.Count == 0)
                {
                    builder.AppendLine("--No songs played");
                }
            }

            return builder.ToString().Trim();
        }
    }
}