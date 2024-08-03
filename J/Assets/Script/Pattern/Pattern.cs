using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bouns;
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

    private void spawnbouns()
    {
        float RandomValue2 = Random.Range(-15, 15);
        Vector3 SpawnPostion2 = new Vector3(RandomValue2, 10, 0);
        Instantiate(bouns, SpawnPostion2, Quaternion.identity);
        Debug.Log("과일이 생성됨");
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1f);
        spawnbouns();
        int Repeatcount = 4*GameManager.instance.difficulty;
        for(int i  = 0; i < Repeatcount; i++)
        {
            CreateEnemyinstance(spawnCount);
            
            yield return new WaitForSeconds(spawnCycle);
        }

        gameObject.SetActive(false);

    }

    private void CreateEnemyinstance(int count)
    {
        
        for (int i = 0; i < count; i++)
        {
            float RandomValue = Random.Range(-15, 15);
            Vector3 SpawnPostion = new Vector3(RandomValue, 9, 0);
            Instantiate(enemyPrefab,SpawnPostion,Quaternion.identity);
        }
    }
}
