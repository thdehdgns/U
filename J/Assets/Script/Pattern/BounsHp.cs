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
                Debug.Log("체력이 가득 차있습니다!");
                player.currentHp = player.MaxHp;
            }
            Debug.Log("체력이 회복됨");
            Destroy(gameObject);
        }
    }

}
