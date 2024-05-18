using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComTest : MonoBehaviour
{
    //�ڵ��� �帧
    //NullRefence����. �������� �����Ͱ� ��� �����ϴ� ����.�ذ��ϱ� ���� �����͸� �ʱ�ȭ
    //Awake -> OnEnable -> Start
    private void Awake()
    {
        Debug.Log("Awake ����");
            
    }

    private void Start()
    {
        Debug.Log("Start ����");
    }

    private void OnEnable()
    {
        Debug.Log("Onenable ����");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate ����");
    }

    private void Update()
    {
        Debug.Log("Update ����");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate ����");
    }
}
