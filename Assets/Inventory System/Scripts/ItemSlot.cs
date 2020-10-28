using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    // Event callbacks
    public UnityEvent<Item> onItemUse;

    // flag to tell ItemSlot it needs to update itself after being changed
    private bool b_needsUpdate = true;

    // Declared with auto-property
    public Item ItemInSlot { get; private set; }
    public int ItemCount { get; private set; }

    public bool isResultSlot;

    // scene references
    [SerializeField]
    private TMPro.TextMeshProUGUI itemCountText;

    [SerializeField]
    public Image itemIcon;

    private void Update()
    {
        if(b_needsUpdate)
        {
            UpdateSlot();
        }
    }

    /// <summary>
    /// Returns true if there is an item in the slot
    /// </summary>
    /// <returns></returns>
    public bool HasItem()
    {
        return ItemInSlot != null;
    }

    /// <summary>
    /// Removes everything in the item slot
    /// </summary>
    /// <returns></returns>
    public void ClearSlot()
    {
        ItemInSlot = null;
        b_needsUpdate = true;
    }

    /// <summary>
    /// Attempts to remove a number of items. Returns number removed
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public int TryRemoveItems(int count)
    {
        if(count > ItemCount)
        {
            int numRemoved = ItemCount;
            ItemCount -= numRemoved;
            b_needsUpdate = true;
            return numRemoved;
        } else
        {
            ItemCount -= count;
            b_needsUpdate = true;
            return count;
        }
    }

    /// <summary>
    /// Sets what is contained in this slot
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    public void SetContents(Item item, int count)
    {
        ItemInSlot = item;
        ItemCount = count;
        b_needsUpdate = true;
    }

    public void DecrementItemCount()
    {
        ItemCount--;
        b_needsUpdate = true;
    }

    /// <summary>
    /// Activate the item currently held in the slot
    /// </summary>
    public void UseItem()
    {
        if(ItemInSlot != null)
        {
            if(ItemCount >= 1)
            {
                ItemInSlot.Use();
                onItemUse.Invoke(ItemInSlot);
                ItemCount--;
                b_needsUpdate = true;
            }
        }
    }

    /// <summary>
    /// Select the item currently held in the slot, or place an item in the slot
    /// </summary>
    public void SelectItem()
    {
        if (!ItemSelector.Instance().ItemSelected())
        {
            if(isResultSlot && HasItem())
            {
                ItemSelector.Instance().item = ItemInSlot;
                ItemSelector.Instance().source = this;
                ItemSelector.Instance().isResultItem = true;
                itemIcon.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            }
            else if (HasItem())
            {
                ItemSelector.Instance().item = ItemInSlot;
                ItemSelector.Instance().source = this;
                itemIcon.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            }
        }
        else if(ItemSelector.Instance().ItemSelected() && !isResultSlot)
        {
            bool isPlaced = false;

            if(!ItemSelector.Instance().isResultItem && HasItem() && ItemSelector.Instance().item != ItemInSlot)
            {
                isPlaced = true;
            }
            else if (HasItem() && ItemSelector.Instance().item == ItemInSlot)
            {
                SetContents(ItemInSlot, ItemCount + 1);
                ItemSelector.Instance().source.DecrementItemCount();
                isPlaced = true;
            }
            else if (!HasItem())
            {
                ItemSelector.Instance().source.DecrementItemCount();
                SetContents(ItemSelector.Instance().item, 1);
                isPlaced = true;
            }
            
            if(isPlaced)
                ItemSelector.Instance().ClearSelection();
            UpdateSlot();
        }
        else if(ItemSelector.Instance().ItemSelected() && isResultSlot && !ItemSelector.Instance().isResultItem)
        {
            ItemSelector.Instance().ClearSelection();
        }
    }

    /// <summary>
    /// Update visuals of slot to match items contained
    /// </summary>
    public void UpdateSlot()
    {
        if (ItemCount == 0)
        {
            ItemInSlot = null;
        }

        if (ItemInSlot != null)
        {
            itemCountText.text = ItemCount.ToString();
            itemIcon.sprite = ItemInSlot.Icon;
            itemIcon.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            //itemIcon.gameObject.SetActive(true);
        }
        else
        {
            //itemIcon.gameObject.SetActive(false);

            itemIcon.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            itemIcon.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
        }

        b_needsUpdate = false;
    }
}
