using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    public GameObject enemyPrefab;

    float spawnCycle = 1f;
    int spawnCount = 5;
    float patternDelay = 1f;


    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy());
    }
    
    private void Delay()
    {
        patternDelay += Time.deltaTime;
        if(patternDelay >= 7f-GameManager.instance.difficulty )
        {
            patternDelay = 0f;
            StartCoroutine(SpawnEnemy());
        }
    }

    private void Update()
    {
        //Delay();
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1f);

        int Repeatcount = 4;
        for(int i  = 0; i < Repeatcount; i++)
        {
            CreateEnemyinstance(spawnCount);

            yield return new WaitForSeconds(spawnCycle);
        }

        gameObject.SetActive(false);

    }

    private void CreateEnemyinstance(int count)
    {
        
        for(int i = 0; i < count; i++)
        {
            float RandomValue = Random.Range(-15, 15);
            Vector3 SpawnPostion = new Vector3(RandomValue, 9, 0);
            Instantiate(enemyPrefab,SpawnPostion,Quaternion.identity);

        }
    }
}
