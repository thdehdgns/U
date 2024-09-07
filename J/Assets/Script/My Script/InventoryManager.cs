using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private GameObject[] childObjects;
    private MyInventory[] itemComponents;
    public Item[] allItems; // ItemManager에서 가져온 Item 배열을 여기서 관리

    private void Start()
    {
        // 자식 오브젝트의 개수만큼 배열 초기화
        childObjects = new GameObject[transform.childCount];
        itemComponents = new MyInventory[transform.childCount];

        // 자식 오브젝트들을 배열에 추가
        for (int i = 0; i < transform.childCount; i++)
        {
            childObjects[i] = transform.GetChild(i).gameObject;
            itemComponents[i] = childObjects[i].GetComponentInChildren<MyInventory>();
        }

        foreach (GameObject child in childObjects)
        {
            Debug.Log("Child Object: " + child.name);
        }
    }

    public void AddItem(int itemId, Item item)
    {
        for (int i = 0; i < itemComponents.Length; i++)
        {
            if (itemComponents[i].itemid == itemId)
            {
                itemComponents[i].itemvalue++;
                return;
            }
            else if (itemComponents[i].itemid == 0)
            {
                itemComponents[i].item = item;
                itemComponents[i].itemid = item.itemId;
                itemComponents[i].itemvalue++;
                return;
            }
        }
    }
}

     
