namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string inputLine = string.Empty;
            while ((inputLine = Console.ReadLine()) != "HARVEST")
            {
                Type harvestingType = typeof(HarvestingFields);
                FieldInfo[] fields = harvestingType.GetFields(BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Static |
                    BindingFlags.Instance);

                string accessModiefier = inputLine;
                FieldInfo[] wantedFields = GetWantedFields(accessModiefier, fields);

                foreach (FieldInfo field in wantedFields)
                {
                    var defaultModifier = field.Attributes.ToString().ToLower();
                    var correctModifier = defaultModifier == "family" ? "protected" : defaultModifier;
                    Console.WriteLine($"{correctModifier} {field.FieldType.Name} {field.Name}");
                }
            }
        }

        private static FieldInfo[] GetWantedFields(string accessModiefier, FieldInfo[] fields)
        {
            switch (accessModiefier)
            {
                case "public":
                    fields = fields.Where(f => f.IsPublic).ToArray();
                    break;
                case "protected":
                    fields = fields.Where(f => f.IsFamily).ToArray();
                    break;
                case "private":
                    fields = fields.Where(f => f.IsPrivate).ToArray();
                    break;
            }

            return fields;
        }
    }
}
