using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item item;
    public int count;
    public Image itemimage;

    [SerializeField]
    private TextMeshProUGUI text_count;
    [SerializeField]
    private GameObject go_countImage;

    private void SetColor(float _alpha)
    {
        Color color = itemimage.color;
        color.a= _alpha;
        itemimage.color = color;
    }

    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        count = _count;
        itemimage.sprite = item.itemSprite;
        go_countImage.SetActive(true);
        text_count.text = count.ToString();

        SetColor(1);
    }

    public void SetSlotCount(int _count)
    {
        count += _count;
        text_count.text = count.ToString();

        if (count <= 0)
            ClearSlot();
    }



    private void ClearSlot()
    {
        item = null;
        count = 0;
        itemimage.sprite= null;
        SetColor(0);
        
        text_count.text = "0";
        go_countImage.SetActive(false);
    }
}
