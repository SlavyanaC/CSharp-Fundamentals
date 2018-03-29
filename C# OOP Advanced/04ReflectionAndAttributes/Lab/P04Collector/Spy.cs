using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] methods = classType.GetMethods(BindingFlags.NonPublic |BindingFlags.Instance | BindingFlags.Public);

        StringBuilder builder = new StringBuilder();

        foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("get")))
        {
            builder.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set")))
        {
            builder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return builder.ToString().Trim();
    }
}