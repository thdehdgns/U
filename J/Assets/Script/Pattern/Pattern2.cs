using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2 : MonoBehaviour
{

    
    public GameObject enemyPrefab;
    public GameObject warning;
    float spawnCycle = 0.3f;
    int spawnCount = 1;
    float patternDelay = 1f;


    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy());
    }

    
    private void Delay()
    {
        patternDelay += Time.deltaTime;
        if (patternDelay >= 7f - GameManager.instance.difficulty)
        {
            patternDelay = 0f;
            StartCoroutine(SpawnEnemy());
        }
    }

    

    private void OnDisable()
    {
        StopCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1f);
        
        int Repeatcount = 6;
        for (int i = 0; i < Repeatcount; i++)
        {
            PlayerContllor player = GameObject.Find("Player").GetComponent<PlayerContllor>();
            Transform transform = player.transform;
            //float RandomValue = Random.Range(-15, 15);
            Vector3 SpawnPostion = new Vector3(player.transform.position.x, 9, 0);
            Instantiate(warning, SpawnPostion, Quaternion.identity);
            Debug.Log("��� ������ ����");
            yield return new WaitForSeconds(1f);
            Instantiate(enemyPrefab, SpawnPostion, Quaternion.identity);
            yield return new WaitForSeconds(spawnCycle);
        }
        
        gameObject.SetActive(false);
        
    }
    
    
}
