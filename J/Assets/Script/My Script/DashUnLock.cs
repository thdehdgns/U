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
                Debug.Log("��ȣ�ۿ� Ȱ��ȭ");
            }
        }
    }
   

    public void dashUnlock()
    {
        Ui.SetActive(false);
    }
}
