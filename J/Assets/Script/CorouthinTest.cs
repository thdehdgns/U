using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorouthinTest : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("그냥호출 1");
        StartCoroutine(CoTest());
        SubTest();
    }

    IEnumerator CoTest()
    {
        Debug.Log("[코루틴]: 01호출");
        Debug.Log("[코루틴]: 02호출");
        yield return new WaitForSeconds(1);
        Debug.Log("[코루틴]: 03호출");

    }

    void SubTest()
    {
        Debug.Log("[서브 테스트 함수] : 01호출");
        Debug.Log("[서브 테스트 함수] : 02호출");
        Debug.Log("[서브 테스트 함수] : 03호출");
    }

}
