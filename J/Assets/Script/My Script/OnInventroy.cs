using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInventroy : MonoBehaviour
{
    public GameObject inventorys;
    private bool Oninventory = false;

    private void Start()
    {
        inventorys.SetActive(false);
    }
    private void Update()
    {
        inventory();
    }

    private void inventory()
    {
        if(Input.GetKeyDown(KeyCode.I)&&Oninventory == false)
        {
            inventorys.SetActive(true);
            Oninventory = true;
        }
        else if (Input.GetKeyDown(KeyCode.I)&&Oninventory == true)
        {
            inventorys.SetActive(false);
            Oninventory = false;
        }
    }
}
