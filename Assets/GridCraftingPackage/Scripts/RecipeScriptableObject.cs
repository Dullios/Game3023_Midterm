using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ingredient
{
    public Ingredient(Item _ingredient, int _span)
    {
        ingredient = _ingredient;
        span = _span;
    }

    [Tooltip("The ingredient in a recipe")]
    public Item ingredient;
    [Tooltip("The number of spaces until the next ingredient in a recipe")]
    public int span;
}


[CreateAssetMenu(fileName = "Recipe", menuName = "CraftingScriptableObjects/Recipe", order = 1)]
public class RecipeScriptableObject : ScriptableObject
{
    public Item result;
    public Ingredient[] ingredients;
}
