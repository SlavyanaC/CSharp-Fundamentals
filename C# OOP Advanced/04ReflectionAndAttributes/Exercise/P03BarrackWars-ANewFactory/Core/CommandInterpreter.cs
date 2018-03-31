namespace _03BarracksFactory.Core
{
    using _03BarracksFactory.Contracts;
    using _03BarracksFactory.Core.Commands;
    using System;
    using System.Linq;
    using System.Reflection;

    class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string result = string.Empty;

            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

            if (commandType == null)
                throw new ArgumentException("Invalid Command!");

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
                throw new ArgumentException($"{commandName} is not a Command");

            FieldInfo[] fieldsToInject = commandType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

            object[] injectArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

            object[] constructorArgs = new object[] { data}.Concat(injectArgs).ToArray();
            IExecutable instance = (IExecutable)Activator.CreateInstance(commandType, constructorArgs);

            return instance;
        }
    }
}
