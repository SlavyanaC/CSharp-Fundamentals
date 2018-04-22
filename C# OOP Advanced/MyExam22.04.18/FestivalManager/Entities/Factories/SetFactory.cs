using System;
using System.Linq;
using System.Reflection;

namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type setType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(type, StringComparison.OrdinalIgnoreCase));

            if (setType == null)
            {
                throw new ArgumentException(string.Format(Output.InvalidType, type));
            }
            if (typeof(IInstrument).IsAssignableFrom(setType))
            {
                throw new InvalidOperationException(string.Format(Output.NotAssignable, type, setType.GetType().Name));
            }

            ISet set = (ISet)Activator.CreateInstance(setType, name);

            return set;
        }
	}
}
