using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class InventoryTests
{
    private IInventory inventory = new HeroInventory();
    Dictionary<string, IItem> commonItems;
    Dictionary<string, IRecipe> recipeItems;

    private IItem firstItem;
    private IItem secondItem;
    private IRecipe recipeItem;

    [SetUp]
    public void SetUp()
    {
        this.inventory = new HeroInventory();
    }

    [Test]
    public void AddsItemToCommonItems()
    {
        this.firstItem = new CommonItem("Knife", 0, 10, 0, 0, 30);
        this.inventory.AddCommonItem(firstItem);

        this.commonItems = GetCommonItems();

        Assert.That(this.commonItems.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddsRecipeToRecipeItems()
    {
        List<string> reqItems = new List<string>() { "Knife", "Stick" };
        this.recipeItem = new RecipeItem("Spear", 25, 10, 10, 100, 50, reqItems);
        this.inventory.AddRecipeItem(recipeItem);

        this.recipeItems = GetRecipeItems();

        Assert.That(this.recipeItems.Count, Is.EqualTo(1));
    }

    [Test]
    public void Test()
    {
        this.firstItem = new CommonItem("Knife", 0, 10, 0, 0, 30);
        this.inventory.AddCommonItem(firstItem);

        this.secondItem = new CommonItem("Stick", 0, 0, 10, 0, 5);
        this.inventory.AddCommonItem(secondItem);

        List<string> reqItems = new List<string>() { "Knife", "Stick" };
        this.recipeItem = new RecipeItem("Spear", 25, 10, 10, 100, 50, reqItems);
        this.inventory.AddRecipeItem(recipeItem);

        this.commonItems = GetCommonItems();
        this.recipeItems = GetRecipeItems();

        Assert.That(this.commonItems.Count, Is.EqualTo(1));
        Assert.That(this.recipeItems.Count, Is.EqualTo(1));
    }

    private Dictionary<string, IRecipe> GetRecipeItems()
    {
        FieldInfo itemsFromInventory = this.inventory.GetType()
                 .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                 .FirstOrDefault(f => f.Name.Equals("recipeItems", StringComparison.OrdinalIgnoreCase));

        Dictionary<string, IRecipe> recipesFromInventory = (Dictionary<string, IRecipe>)itemsFromInventory
            .GetValue(this.inventory);

        return recipesFromInventory;
    }

    private Dictionary<string, IItem> GetCommonItems()
    {
        FieldInfo commonItemsFromInventory = this.inventory.GetType()
                 .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                 .FirstOrDefault(f => f.Name.Equals($"{nameof(CommonItem)}s", StringComparison.OrdinalIgnoreCase));

        Dictionary<string, IItem> itemsFromInventory = (Dictionary<string, IItem>)commonItemsFromInventory
            .GetValue(this.inventory);

        return itemsFromInventory;
    }
}
