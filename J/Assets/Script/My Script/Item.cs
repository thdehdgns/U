using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public string itemName;
    public ItemType itemtype;
    public Sprite itemSprite;
    public int itemId;
    //public GameObject itemPrefab;

    public enum ItemType
    {
        Used,
        ETC
    }

    
}
