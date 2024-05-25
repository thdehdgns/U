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
            Debug.Log("���� ���¸� ���" + GasState);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GasState = false;
            Debug.Log("���� ���¸� ���" + GasState);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("������"+ PlayerHp);
            PlayerHp = PlayerHp - Damage;
        }
    }

    private void Update() // PlayerController�� Update���� �ۼ��ϴ� �� ������.
    {
        if (GasState)   // { } ���� �濡 ���� ���� ���� �ۼ��Ѵ�. ü���� ���̴� ������ ���÷� �ۼ��Ͽ���.
        {
            // ���� �ð��� ���� Time.deltaTime
            //checkTime = 2f;
            Timer += Time.deltaTime; // 0.016. ��ǻ�͸��� �ٸ���. 1Frame �����ϴ� �ð�.
            if (Timer >= checkTime)
            {
                Timer = 0;
                PlayerHp = PlayerHp - Damage;
                Debug.Log($"�÷��̾��� ���� ü�� : {PlayerHp}");
            }
        }
    }

}
