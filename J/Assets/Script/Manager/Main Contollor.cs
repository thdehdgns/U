using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainContollor : MonoBehaviour
{
    public TextMeshProUGUI Score;//현재점수
    public TextMeshProUGUI BestScore;//현재점수
    public TextMeshProUGUI Level;
    public static MainContollor instance;
    public GameObject GameOver;
    public GameObject GameScore;
    public float score;

    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void SLevel()
    {
        string name = null;

        switch (GameManager.instance.difficulty)
        {
            case 1:
                name = "이지";
                break;
            case 2:
                name = "노말";
                break;
            case 3:
                name = "하드";
                break;
            default:
                name = $"키 : {GameManager.instance.difficulty} 존재하지 않는 키 값입니다.";
                break;
        }

        Level.text = $"현재 난이도는: {name}입니다.";
    }

    public void Scorestart()
    {
        score += (Time.deltaTime*GameManager.instance.difficulty); //게임 난이도+1 * 시간 = 점수
    }

    private void Update()
    {
        SLevel();
        Scorestart();
        Score.text = score.ToString();
        BestScore.text = $"최고점수 {PlayerPrefs.GetFloat(GameData.BestScore2)}";
        bestScoreReset();
    }

    

    public void bestscore()//최고점수 갱신
    {
        if (score > PlayerPrefs.GetFloat(GameData.BestScore2))
            PlayerPrefs.SetFloat(GameData.BestScore2, score);
    }

    public void bestScoreReset()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.SetFloat(GameData.BestScore2,0);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOverUI()
    {
        GameOver.SetActive(true);
        GameScore.SetActive(false);
    }

    public void Retry()
    {
        GameOver.SetActive(false);
        GameScore.SetActive(true);
        score = 0;
    }

    public void gamequit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }

}
