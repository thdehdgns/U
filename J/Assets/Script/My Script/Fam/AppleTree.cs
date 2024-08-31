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
            Debug.Log("�÷��̾�� ���Ǿ��� ������");
            OntrigerValue = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("�÷��̾�� ���Ǿ��� ����");
            OntrigerValue = false;
        }
    }
    private void InPalyer()
    {
        if(OntrigerValue == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (OnSeed == true) //������ ���� ��
                {
                    if (OnApple == true)
                    {
                        addApple();
                    }
                    else
                    {
                        if (IngApple == false)  //������ �ְ� ����� �ڶ������ ������
                        {
                            IngApple = true;
                            Debug.Log("���� ȿ���ߵ�");

                        }
                        else //������ ������ �̹� ����� �ڶ������ ��
                        {
                            Debug.Log("����� �ڶ���ֽ��ϴ�.");
                        }
                    }
                }
                else if (OnSeed == false || IngApple == true) //������ ���ų� ������ ���µ� ����� �ڶ������ ��
                {
                    if (OnApple == true)
                    {
                        //�ޱ�
                        addApple();

                    }
                    else if (OnApple == false)
                    {
                        //���
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
        if (itemManager.items.Length > 2) // �迭�� ���� Ȯ��
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
                Debug.Log("��Ÿ���� 0�����Դϴ�.");
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
