using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounsHp : MonoBehaviour
{
    
    public int plusHp = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerContllor player = collision.gameObject.GetComponent<PlayerContllor>();
            player.currentHp += plusHp;
            if (player.currentHp > player.MaxHp)
            {
                Debug.Log("ü���� ���� ���ֽ��ϴ�!");
                player.currentHp = player.MaxHp;
            }
            Debug.Log("ü���� ȸ����");
            Destroy(gameObject);
        }
    }

}
