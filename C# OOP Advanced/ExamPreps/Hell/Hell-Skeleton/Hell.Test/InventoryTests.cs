using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class InventoryTests
{
    private IInventory inventory = new HeroInventory();
    IDictionary<string, IItem> commonItems;
    IDictionary<string, IRecipe> recipeItems;

    IItem item = new CommonItem("Staff", 0, 10, 50, 100, 100);

    [SetUp]
    public void SetUp()
    {
        this.commonItems = GetCommonItems();
        this.recipeItems = GetRecipeItems();
    }

    [Test]
    public void AddsItemToCommonItems()
    {
        this.inventory.AddCommonItem(this.item);
        Assert.That(this.commonItems.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddsRecipeToRecipes()
    {

    }

    private IDictionary<string, IRecipe> GetRecipeItems()
    {
        FieldInfo itemsFromInventory = this.inventory.GetType()
                 .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                 .FirstOrDefault(f => f.Name.Equals("recipeItems", StringComparison.OrdinalIgnoreCase));

        IDictionary<string, IRecipe> recipesFromInventory = (IDictionary<string, IRecipe>)itemsFromInventory
            .GetValue(this.inventory);

        return recipesFromInventory;
    }

    private IDictionary<string, IItem> GetCommonItems()
    {
        FieldInfo commonItemsFromInventory = this.inventory.GetType()
                 .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                 .FirstOrDefault(f => f.Name.Equals($"{nameof(CommonItem)}s", StringComparison.OrdinalIgnoreCase));

        IDictionary<string, IItem> itemsFromInventory = (IDictionary<string, IItem>)commonItemsFromInventory
            .GetValue(this.inventory);

        return itemsFromInventory;
    }
}
