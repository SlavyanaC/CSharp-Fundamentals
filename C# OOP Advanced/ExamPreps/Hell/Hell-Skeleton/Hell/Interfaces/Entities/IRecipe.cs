using System.Collections.Generic;

public interface IRecipe : IItem
{
    IReadOnlyList<string> RequiredItems { get; }
}
