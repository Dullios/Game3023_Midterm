using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_Recipe List", menuName = "CraftingScriptableObjects/RecipeList", order = 0)]
public class RecipeListScriptableObject : ScriptableObject
{
    public RecipeScriptableObject[] recipeList;
}
