namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Performer : IPerformer
	{
		private readonly IList<IInstrument> instruments;

		public Performer(string name, int age)
		{
            this.instruments = new List<IInstrument>();
			this.Name = name;
			this.Age = age;
		}

		public string Name { get; }

		public int Age { get; }

		public IReadOnlyCollection<IInstrument> Instruments => this.instruments.ToList().AsReadOnly();

		public void AddInstrument(IInstrument instrument)
		{
			this.instruments.Add(instrument);
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}
