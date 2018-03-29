using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] fields = classType.GetFields(
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.Public);

        StringBuilder builder = new StringBuilder();

        MethodInfo[] methods = classType.GetMethods(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);

        foreach (var fieldInfo in fields)
        {
            builder.AppendLine($"{fieldInfo.Name} must be private!");
        }

        foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
        {
            if (!method.IsPublic)
                builder.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
        {
            if (!method.IsPrivate)
                builder.AppendLine($"{method.Name} have to be private!");
        }

        return builder.ToString().Trim();
    }
}