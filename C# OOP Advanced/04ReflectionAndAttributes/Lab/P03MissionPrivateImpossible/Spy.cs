using System;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] methods = classType.GetMethods( BindingFlags.NonPublic |BindingFlags.Instance);

        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"All Private Methods of Class: {className}");
        builder.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var methodInfo in methods)
        {
            builder.AppendLine(methodInfo.Name);
        }

        return builder.ToString().Trim();
    }
}