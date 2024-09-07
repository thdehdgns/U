using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public float Maxcooldwon = 150;
    public float curruntCool = 150;
    public bool OnApple = false;
    public bool IngApple = false;
    public bool water = true;
    private int thisitemid;
    public TextMeshPro AppleText;
    public GameObject Apple;
    public GameObject AppleMassage;
    public InventoryManager inventoryManager;
    public ItemManager itemManager;
    private bool OntrigerValue = false;
    private float time;
    private bool Ontime;


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
                if (water == true) //���� ���� ��
                {
                    if (OnApple == true)
                    {
                        addApple();
                    }
                    else
                    {
                        if (IngApple == false)  //���� �ְ� ����� �ڶ������ ������
                        {
                            IngApple = true;
                            Debug.Log("���� ȿ���ߵ�");
                            //���� ���� ���̱�

                        }
                        else //���� ������ �̹� ����� �ڶ������ ��
                        {
                            AppleMassage.SetActive(true);
                            Ontime = true;
                            time = 3;
                            AppleText.text = $"����� �ڶ���ֽ��ϴ�!\n{curruntCool.ToString("F0")}�� ����!";
                            Debug.Log("����� �ڶ���ֽ��ϴ�.");
                            
                        }
                    }
                }
                else if (water == false || IngApple == true) //�� ���ų� ������ ���µ� ����� �ڶ������ ��
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
    
    private void timer()
    {
        if(Ontime == true)
        {
            
            time -= Time.deltaTime;
            if(time <= 0)
            {
                Ontime = false;
                AppleMassage.SetActive(false);
            }
        }
    }


    private void appleSprite()
    {
        Apple.SetActive(true);
    }

    public void Update()
    {
        timer();
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
            Apple.SetActive(false);
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
                appleSprite();
            }
            else
            {
                curruntCool -= Time.deltaTime;
            }
        }
    }



}
