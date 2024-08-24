using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ItemManager itemManager;
    private int thisitemid;
    public InventoryManager inventoryManager;

    private void Start()
    {
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not assigned.");
        }

        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager is not assigned.");
        }
    }

    public void BuyApple()
    {
        if (itemManager.items.Length > 2) // 배열의 길이 확인
        {
            thisitemid = itemManager.items[2].itemId;
            inventoryManager.AddItem(thisitemid, itemManager.items[2]);
        }
        else
        {
            Debug.LogError("ItemManager does not have enough items.");
        }
    }
    public void BuyBanana()
    {
        if (itemManager.items.Length > 2) // 배열의 길이 확인
        {
            thisitemid = itemManager.items[1].itemId;
            inventoryManager.AddItem(thisitemid, itemManager.items[1]);
        }
        else
        {
            Debug.LogError("ItemManager does not have enough items.");
        }
    }
}
