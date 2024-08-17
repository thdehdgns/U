using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Npc : MonoBehaviour
{

    public GameObject NpcCanvers;
    public string[] NpcTall;
    public TextMeshProUGUI NpcText;
    public int index = 0;
    public bool OnCanvers = false;
    public bool OntrigerValue = false;
    public GameObject ShopCanvers;

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

    private void text()
    {
        if(OntrigerValue == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                NpcCanvers.SetActive(true);
                NpcText.text = NpcTall[index];
                OnCanvers = true;
            }
        }
    }

    public void OpenShop()
    {
        ShopCanvers.SetActive(true);
    }
    
    public void CloseShop()
    {
        ShopCanvers.SetActive(false);
    }
    

    private void Update()
    {

        text();
        textInputKey();
        if (index > NpcTall.Length -1)
        {
            index = 0;
            NpcCanvers.SetActive(false);
            OnCanvers = false;
            OpenShop();
        }
        else
        {
            NpcText.text = NpcTall[index];
        }
    }

    public void NpcCanversFlase()
    {
        NpcCanvers.SetActive(false);
        index = 0;
        OntrigerValue = false;
        OnCanvers = false;
        OpenShop();
    }

    private void textInputKey()
    {
        if(OnCanvers == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                NextText();
            }
        }
    }

    public void NextText()
    {

            index++;
    }

}
