using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public struct IngredientInfo
    {
        // The ItemIcon in the ItemSlot
        public Item ingredient;
        public int indexInInventory;
        public int ingredientAmount;
    }

    public ItemSlot[] craftinGrid = new ItemSlot[9];
    public IngredientInfo[] ingredients = new IngredientInfo[9];
    
    [Header("Crafting Elements")]
    public GameObject result;

    [Header("Inventory Elements")]
    public Inventory inventory;

    [Header("Recipe Checks")]
    public int indexOffset;

    // Recipe List Scriptable Object
    // Which has a list of Recipe Scriptable Objects
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckRecipe()
    {
        
    }
}
