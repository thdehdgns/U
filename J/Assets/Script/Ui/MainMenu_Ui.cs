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
        Bestscore.text =$"최고점수 {PlayerPrefs.GetFloat(GameData.BestScore)}";
        
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1); // 2번째 위치에 잇는 씬을 로드한다.
                                   // 배열은 0번째... 배열에 1에 해당하는 씬을 로드해라.
    }

    public void SwitchMenuTo(GameObject uiMenu)    // 버튼에 연결시킬 함수 이름(MainMenu_UI닫고, 원하는 UI 연다)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false); // MainMenu 하위의 자식들을 전부 비활성화 시켜라.
        }

        uiMenu.SetActive(true); // 대상 오브제트를 활성화 시켜라
    }
    public void LevelChoice(int level)
    {
        GameManager.instance.difficulty = level;
        GameManager.instance.SaveGameDiffculty();
    }
}
