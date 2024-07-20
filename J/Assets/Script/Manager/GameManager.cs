using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    // �̱��� ����
    public static GameManager instance;  // GameManager.instance

    public int difficulty; // 0 : ����, 1 : �븻, 2 : �ϵ�

    public float score;

    private void Update()
    {
        score += Time.deltaTime;
        if(Input.GetKeyUp(KeyCode.F))   //������ ������ �� �۵��ϴ°� ���� 
        {
            if(score> PlayerPrefs.GetFloat(GameData.BestScore))
            PlayerPrefs.SetFloat(GameData.BestScore,score);

        }
        
        
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(GameData.GameDifficulty))
        {
            difficulty = PlayerPrefs.GetInt(GameData.GameDifficulty);

        }
    }

    public string ReturnCurrentDifficulty()
    {
        string name = null;

        switch (difficulty)
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
                name = $"Ű : {difficulty} �������� �ʴ� Ű ���Դϴ�.";
                break;
        }

        return $"������ ���̵� : {name}";
    }


    public void SaveGameDiffculty()
    {
        PlayerPrefs.SetInt(GameData.GameDifficulty, difficulty);
        PlayerPrefs.GetInt(GameData.GameDifficulty);
    }
}
