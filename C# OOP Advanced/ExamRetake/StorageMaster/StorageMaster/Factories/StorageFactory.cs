namespace StorageMaster.Factories
{
    using Entities.Storages;
    using System;
    using System.Linq;
    using System.Reflection;

    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            Type storageType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if (storageType == null || storageType.IsAbstract)
            {
                throw new InvalidOperationException("Invalid storage type!");
            }

            try
            {
                Storage storage = (Storage)Activator.CreateInstance(storageType, name);
                return storage;
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }
    }
}
