using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnposition;



    void Start()
    {
        // 생성할 프리펩 데이터를 먼저 넣고, 생성할 위치(Vector),오브젝트의 각도
        //Instantiate(prefab);// 프리펩의 위치는 기본위치, 회전값으로 생선된다.
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
