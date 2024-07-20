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
                name = "����";
                break;
            case 2:
                name = "�븻";
                break;
            case 3:
                name = "�ϵ�";
                break;
            default:
                name = $"Ű : {GameManager.instance.difficulty} �������� �ʴ� Ű ���Դϴ�.";
                break;
        }

        Level.text = $"���� ���̵���: {name}�Դϴ�.";
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
