namespace FestivalManager.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Stage : IStage
    {
        private readonly IList<ISet> sets;
        private readonly IList<ISong> songs;
        private readonly IList<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets.ToList();

        public IReadOnlyCollection<ISong> Songs => this.songs.ToList();

        public IReadOnlyCollection<IPerformer> Performers => this.performers.ToList();

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer wantedPerformer = this.Performers.FirstOrDefault(s => s.Name.Equals(name));

            if (!this.HasPerformer(name))
            {
                throw new ArgumentException(string.Format(Output.NoItemFound, name));
            }

            return wantedPerformer;
        }

        public ISet GetSet(string name)
        {
            ISet wantedSet = this.Sets.FirstOrDefault(s => s.Name.Equals(name));

            if (!this.HasSet(name))
            {
                throw new ArgumentException(string.Format(Output.NoItemFound, name));
            }

            return wantedSet;
        }

        public ISong GetSong(string name)
        {
            ISong wantedSong = this.Songs.FirstOrDefault(s => s.Name.Equals(name));
            if (!this.HasSong(name))
            {
                throw new ArgumentException(string.Format(Output.NoItemFound, name));
            }

            return wantedSong;
        }

        public bool HasPerformer(string name)
        {
            return this.Performers.Any(p => p.Name.Equals(name));
        }

        public bool HasSet(string name)
        {
            return this.Sets.Any(p => p.Name.Equals(name));
        }

        public bool HasSong(string name)
        {
            return this.Songs.Any(p => p.Name.Equals(name));
        }
    }
}
