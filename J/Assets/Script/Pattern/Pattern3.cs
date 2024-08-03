using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern3 : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnCycle = 0.1f;
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
        int Repeatcount = 10*GameManager.instance.difficulty;
        for (int i = 0; i < Repeatcount; i++)
        {
            PlayerContllor player = GameObject.Find("Player").GetComponent<PlayerContllor>();
            Transform transform = player.transform;
            //float RandomValue = Random.Range(-15, 15);
            Vector3 SpawnPostion = new Vector3(player.transform.position.x, 9, 0);
            Instantiate(enemyPrefab, SpawnPostion, Quaternion.identity);
            yield return new WaitForSeconds(spawnCycle);
        }

        gameObject.SetActive(false);

    }
}
