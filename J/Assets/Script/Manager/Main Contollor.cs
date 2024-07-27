using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainContollor : MonoBehaviour
{
    public TextMeshProUGUI Score;//��������
    public TextMeshProUGUI BestScore;//��������
    public TextMeshProUGUI Level;
    public static MainContollor instance;
    public GameObject GameOver;
    public GameObject GameScore;
    public PlayerContllor playercon;
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
        if(GameManager.instance.difficulty == 0 && GameManager.instance.difficulty == null)
        {
            GameManager.instance.difficulty = 1;
        }
        switch (GameManager.instance.difficulty)
        {
            case 1:
                name = "Esey";
                break;
            case 2:
                name = "Nomal";
                break;
            case 3:
                name = "Hard";
                break;
            default:
                name = $"Ű : {GameManager.instance.difficulty} �������� �ʴ� Ű ���Դϴ�.";
                break;
        }

        Level.text = $"{name}";
    }

    public void Scorestart()
    {
        score += (Time.deltaTime*GameManager.instance.difficulty); //���� ���̵�+1 * �ð� = ����
    }

    private void Update()
    {
        SLevel();
        Scorestart();
        Score.text = score.ToString();
        BestScore.text = $"�ְ����� {PlayerPrefs.GetFloat(GameData.BestScore2)}";
        bestScoreReset();
    }

    

    public void bestscore()//�ְ����� ����
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
        playercon.currentHp = playercon.MaxHp;
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