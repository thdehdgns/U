using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyInventory : MonoBehaviour
{
    public Item item;
    public string ItemName;
    public int itemid;
    public int itemvalue = 0;
    public int itemMaxvalue = 999;
    public TextMeshProUGUI valueText;

    private void Awake()
    {
        
        UpdateItemVisuals();
    }

    private void Update()
    {
        valueText.text = $"{itemvalue}";
        UpdateItemVisuals();
    }

    private void UpdateItemVisuals()
    {
        Image childImage = transform.Find("Item").GetComponent<Image>();
        if (item == null)
        {
            childImage.sprite = null;
            Color color = childImage.color;
            color.a = 0f;
            childImage.color = color;
            ItemName = "";
            itemid = 0;
        }
        else
        {
            childImage.sprite = item.itemSprite;
            Color color = childImage.color;
            color.a = 1f; // 알파값 1f으로 설정
            childImage.color = color;
            ItemName = item.itemName;
            itemid = item.itemId;
        }
    }
}
