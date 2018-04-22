namespace FestivalManager.Entities.Sets
{
	using System;

	public class Short : Set
	{
        private const int ShortMaxDuration = 15;

		public Short(string name) 
			: base(name, new TimeSpan(0, ShortMaxDuration, 0))
		{
		}
	}
}