using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashUnLock : MonoBehaviour
{
    public GameObject Ui;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Ui.SetActive(true);

            }
            else
            {
                Debug.Log("상호작용 활성화");
            }
        }
    }
   

    public void dashUnlock()
    {
        Ui.SetActive(false);
    }
}
