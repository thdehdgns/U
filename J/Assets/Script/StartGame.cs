using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StartGame : MonoBehaviour
{
    public TextMeshProUGUI Starting;
    public bool GamesStaring = false;

    private void Start()
    {
        StartCoroutine(startingGame());
    }

    private void OnEnable()
    {
        GamesStaring = false;
    }
    IEnumerator startingGame()
    {
        
        Starting.text = "3";
        yield return new WaitForSeconds(1f);
        Starting.text = "2";
        yield return new WaitForSeconds(1f);
        Starting.text = "1";
        yield return new WaitForSeconds(1f);
        GamesStaring = true;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(startingGame());
    }

}
