using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComTest : MonoBehaviour
{
    //코드의 흐름
    //NullRefence에러. 변수에서 데이터가 없어서 발행하는 에러.해결하기 위해 데이터를 초기화
    //Awake -> OnEnable -> Start
    private void Awake()
    {
        Debug.Log("Awake 실행");
            
    }

    private void Start()
    {
        Debug.Log("Start 실행");
    }

    private void OnEnable()
    {
        Debug.Log("Onenable 실행");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate 실행");
    }

    private void Update()
    {
        Debug.Log("Update 실행");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate 실행");
    }
}
