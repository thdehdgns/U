using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//충돌하기 위해서는 두 물체 중 한 물체는 Rigidbody(2D)를 가지고있어야 한다.
//두 물체 전부다 Collider를 갖고 있어야한다.
//플레이어와 충돌하면 


public class Trap : MonoBehaviour
{
    //충돌 이벤트를 작성할 때, 모든 오브젝트를 대상으로 작성할 일은 거이 없다.
    //성능 적인 면에서도 비효율적이다.
    //출돌 이벤트가 특정 대상만 작동하도록 태그를 달아준다.
    //Tag - 낱개의 충돌 이벤트 설정
    //Layer - 여러ㅡ개

    //Collider 2D이고 Rigidbody 2D여야 한다 

    protected bool isWorking = false;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        //플레이어 태그를 가지고 있는가?
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("플레이어가 함정에 피격당함");
        }    
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어가 함정에 피격당함");
        }
    }
}
