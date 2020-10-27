using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeList", menuName = "CraftingScriptableObjects/Item", order = 0)]
public class RecipeListScriptableObject : ScriptableObject
{
    public RecipeScriptableObject[] recipeList;
}
