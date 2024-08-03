using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternContoller : MonoBehaviour
{
    public GameObject []Pattern;
    public Transform transform;

    [Header("플레이중인 패턴")]
    public int patternIndex = 0;
    public GameObject currentPattern;
    public StartGame startGame;

    private void Start()
    {
        transform = GetComponent<Transform>();
        foreach(var pattern in Pattern)
        {
            pattern.gameObject.SetActive(false);
        }
        
            ChangePattern();
        
    }

    private void Update()
    {
        if(currentPattern.activeSelf == false)
        {
            
                ChangePattern();
            
        }
    }

    public void ChangePattern()
    {
        if (startGame.GamesStaring == true)
        {
            currentPattern = Pattern[patternIndex];
            currentPattern.SetActive(true);

            patternIndex++;
            if (patternIndex >= Pattern.Length)
            {
                patternIndex = 0;
            }
        }
    }
}
