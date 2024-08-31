using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public float Maxcooldwon = 150;
    public float curruntCool = 150;
    public bool OnApple = false;
    public bool IngApple = false;
    public bool OnSeed = true;
    private int thisitemid;
    public InventoryManager inventoryManager;
    public ItemManager itemManager;
    private bool OntrigerValue = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어와 엔피씨가 접근중");
            OntrigerValue = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어와 엔피씨가 떠남");
            OntrigerValue = false;
        }
    }
    private void InPalyer()
    {
        if(OntrigerValue == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (OnSeed == true) //씨앗이 있을 때
                {
                    if (OnApple == true)
                    {
                        addApple();
                    }
                    else
                    {
                        if (IngApple == false)  //씨앗이 있고 사과가 자라고있지 않을때
                        {
                            IngApple = true;
                            Debug.Log("씨앗 효과발동");

                        }
                        else //씨앗은 있지만 이미 사과가 자라고있을 때
                        {
                            Debug.Log("사과가 자라고있습니다.");
                        }
                    }
                }
                else if (OnSeed == false || IngApple == true) //씨앗이 없거나 씨앗은 없는데 사과가 자라고있을 때
                {
                    if (OnApple == true)
                    {
                        //받기
                        addApple();

                    }
                    else if (OnApple == false)
                    {
                        //경고
                    }
                }
            }
        }
            
    }
    

    public void Update()
    {
        InPalyer();
        CooldwonApple();
    }

    private void addApple()
    {
        if (itemManager.items.Length > 2) // 배열의 길이 확인
        {
            thisitemid = itemManager.items[2].itemId;
            inventoryManager.AddItem(thisitemid, itemManager.items[2]);
            OnApple = false;
        }
        else
        {
            Debug.LogError("ItemManager does not have enough items.");
        }
    }

    private void CooldwonApple()
    {
        if(IngApple == true)
        {
            if(curruntCool <= 0)
            {
                Debug.Log("쿨타임이 0이하입니다.");
                curruntCool = Maxcooldwon;
                IngApple = false;
                OnApple = true;
            }
            else
            {
                curruntCool -= Time.deltaTime;
            }
        }
    }



}
