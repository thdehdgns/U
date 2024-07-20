using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainMenu_Ui : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI Bestscore;

    public TextMeshProUGUI curretScoreText;
    

    private void Update()
    {
        levelText.text = GameManager.instance.ReturnCurrentDifficulty();
        curretScoreText.text = GameManager.instance.score.ToString();
        Bestscore.text =$"�ְ����� {PlayerPrefs.GetFloat(GameData.BestScore)}";
        
    }

    

    public void StartNewGame()
    {
        SceneManager.LoadScene(2); // 2��° ��ġ�� �մ� ���� �ε��Ѵ�.
                                   // �迭�� 0��°... �迭�� 1�� �ش��ϴ� ���� �ε��ض�.
    }

    public void SwitchMenuTo(GameObject uiMenu)    // ��ư�� �����ų �Լ� �̸�(MainMenu_UI�ݰ�, ���ϴ� UI ����)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false); // MainMenu ������ �ڽĵ��� ���� ��Ȱ��ȭ ���Ѷ�.
        }

        uiMenu.SetActive(true); // ��� ������Ʈ�� Ȱ��ȭ ���Ѷ�
    }
    public void LevelChoice(int level)
    {
        GameManager.instance.difficulty = level;
        GameManager.instance.SaveGameDiffculty();
    }
}
