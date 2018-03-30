using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Tracker
{
    public string PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
        StringBuilder builder = new StringBuilder();
        foreach (MethodInfo method in methods)
        {
            if (method.CustomAttributes.Any(a => a.AttributeType == typeof(SoftUniAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);
                foreach (SoftUniAttribute attribute in attributes)
                {
                    builder.AppendLine($"{method} is written by {attribute.Name}");
                }
            }
        }

        return builder.ToString().TrimEnd();
    }
}
