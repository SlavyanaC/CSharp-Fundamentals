namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {

            StringBuilder builder = new StringBuilder();
            Type blackBoxType = typeof(BlackBoxInteger);
            Object classInstance = Activator.CreateInstance(blackBoxType, true);

            var methodsInfo = blackBoxType
                .GetMethods(BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.NonPublic);

            FieldInfo[] fieldsInfo = blackBoxType
                .GetFields(BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic);

            var inputArgs = Console.ReadLine().Split('_');
            while (inputArgs[0] != "END")
            {
                var value = int.Parse(inputArgs[1]);
                methodsInfo.FirstOrDefault(m => m.Name == inputArgs[0])?.Invoke(classInstance, new object[] { value});

                foreach (FieldInfo field in fieldsInfo)
                {
                    builder.AppendLine(field.GetValue(classInstance).ToString());
                }

                inputArgs = Console.ReadLine().Split('_');
            }

            Console.WriteLine(builder.ToString().TrimEnd());
        }
    }
}
