using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelector
{
    private static ItemSelector instance;
    private ItemSelector()
    {

    }

    public static ItemSelector Instance()
    {
        if (instance == null)
            instance = new ItemSelector();

        return instance;
    }

    public Item item;
    public ItemSlot source;

    public bool ItemSelected()
    {
        return item != null;
    }

    public void ClearSelection()
    {
        item = null;
        source.itemIcon.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        source = null;
    }
}
