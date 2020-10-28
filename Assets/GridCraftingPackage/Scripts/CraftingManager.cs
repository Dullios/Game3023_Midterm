using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [Header("Crafting Elements")]
    public ItemSlot[] craftingGrid = new ItemSlot[9];
    public ItemSlot result;

    [Header("Master Recipe List")]
    public RecipeListScriptableObject recipeBook;

    private List<Ingredient> tempRecipe;

    private Item gridIngredient;
    private int gridSpan;

    // Recipe List Scriptable Object
    // Which has a list of Recipe Scriptable Objects
    
    // Start is called before the first frame update
    void Start()
    {
        tempRecipe = new List<Ingredient>();
    }

    /// <summary>
    /// Create a temporary recipe every time an item is added to or removed from the grid
    /// </summary>
    public void CreateRecipe()
    {
        tempRecipe.Clear();

        gridIngredient = null;
        gridSpan = 0;

        for(int i = 0; i < craftingGrid.Length; i++)
        {
            if(craftingGrid[i].HasItem() && gridIngredient == null)
            {
                gridIngredient = craftingGrid[i].ItemInSlot;
            }
            else if(craftingGrid[i].HasItem() && gridSpan >= 0)
            {
                gridSpan++;
                tempRecipe.Add(new Ingredient(gridIngredient, gridSpan));
                
                gridIngredient = craftingGrid[i].ItemInSlot;
                gridSpan = 0;
            }
            else if(gridIngredient != null)
            {
                gridSpan++;
            }
        }

        if (gridIngredient != null)
        {
            tempRecipe.Add(new Ingredient(gridIngredient, 0));

            CheckRecipeList();
        }
    }

    private void CheckRecipeList()
    {
        bool recipeFound = true;

        foreach (RecipeScriptableObject recipe in recipeBook.recipeList)
        {
            recipeFound = true;
            for (int i = 0; i < recipe.ingredients.Length; i++)
            {
                if (tempRecipe.Count != recipe.ingredients.Length)
                {
                    recipeFound = false;
                    break;
                }
                else
                {
                    if (recipe.ingredients[i].ingredient != tempRecipe[i].ingredient ||
                        recipe.ingredients[i].span != tempRecipe[i].span)
                        recipeFound = false;
                }
            }

            if (recipeFound)
            {
                result.SetContents(recipe.result, 1);
                break;
            }
        }

        if (!recipeFound)
        {
            result.SetContents(result.ItemInSlot, 0);
        }
    }

    /// <summary>
    /// Reduce all the ingredients in the grid by one
    /// </summary>
    public void ConsumeIngredients()
    {
        if (result.HasItem())
        {
            foreach (ItemSlot slot in craftingGrid)
            {
                slot.SetContents(slot.ItemInSlot, slot.ItemCount - 1);
            }
        }
    }
}
