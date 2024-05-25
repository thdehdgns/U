using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GasRoom : MonoBehaviour
{
    private bool GasState = false;
    private int PlayerHp =10000;
    private int Damage = 1;

    public float checkTime = 2f;
    private float Timer = 0f;
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GasState = true;
            Debug.Log("현재 상태를 출력" + GasState);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GasState = false;
            Debug.Log("현재 상태를 출력" + GasState);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("아픈중"+ PlayerHp);
            PlayerHp = PlayerHp - Damage;
        }
    }

    private void Update() // PlayerController의 Update에서 작성하는 게 맞지만.
    {
        if (GasState)   // { } 가스 방에 들어갔을 때의 로직 작성한다. 체력을 깍이는 로직을 예시로 작성하였다.
        {
            // 단위 시간을 제어 Time.deltaTime
            //checkTime = 2f;
            Timer += Time.deltaTime; // 0.016. 컴퓨터마다 다르다. 1Frame 생성하는 시간.
            if (Timer >= checkTime)
            {
                Timer = 0;
                PlayerHp = PlayerHp - Damage;
                Debug.Log($"플레이어의 현재 체력 : {PlayerHp}");
            }
        }
    }

}
