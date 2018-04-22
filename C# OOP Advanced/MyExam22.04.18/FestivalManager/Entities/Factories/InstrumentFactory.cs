namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Entities.Contracts;

    public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            Type instrumentType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(type, StringComparison.OrdinalIgnoreCase));

            if (instrumentType == null)
            {
                throw new ArgumentException(string.Format(Output.InvalidType, type));
            }
            if (!typeof(IInstrument).IsAssignableFrom(instrumentType))
            {
                throw new InvalidOperationException(string.Format(Output.NotAssignable, type, instrumentType.GetType().Name));
            }

            IInstrument instrument = (IInstrument)Activator.CreateInstance(instrumentType, null);

            return instrument;
		}
	}
}