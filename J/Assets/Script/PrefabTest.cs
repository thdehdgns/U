using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnposition;



    void Start()
    {
        // ������ ������ �����͸� ���� �ְ�, ������ ��ġ(Vector),������Ʈ�� ����
        //Instantiate(prefab);// �������� ��ġ�� �⺻��ġ, ȸ�������� �����ȴ�.
        //Instantiate(prefab,transform.position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SpawnPrefab();
        }
    }


    private void SpawnPrefab()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
