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
                FieldInfo[] fieldsInfo = harvestingType
                    .GetFields(BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Instance |
                    BindingFlags.Static);

                string accessModifier = inputLine;
                FieldInfo[] resultFields = GetFieldsWithSpecificModifier(accessModifier, fieldsInfo);
                foreach (FieldInfo field in resultFields)
                {
                    string defauldModifier = field.Attributes.ToString().ToLower();
                    string fieldModifier = defauldModifier == "family" ? "protected" : defauldModifier;
                    Console.WriteLine($"{fieldModifier} {field.FieldType.Name} {field.Name}");
                }
            }
        }

        private static FieldInfo[] GetFieldsWithSpecificModifier(string accessModifier, FieldInfo[] fieldsInfo)
        {
            switch (accessModifier)
            {
                case "public":
                    fieldsInfo = fieldsInfo.Where(f => f.IsPublic).ToArray();
                    break;
                case "private":
                    fieldsInfo = fieldsInfo.Where(f => f.IsPrivate).ToArray();
                    break;
                case "protected":
                    fieldsInfo = fieldsInfo.Where(f => f.IsFamily).ToArray();
                    break;
            }

            return fieldsInfo;
        }
    }
}
