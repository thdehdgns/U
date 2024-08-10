using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    public GameObject goalobject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어가 목표지점에 도달함");

            goalobject.SetActive(true);
            //TMP_Text goalText = goalobject.GetComponent<TMP_Text>();
            //goalText.text = "게임 클리어!";
            Time.timeScale = 0f;
        }
    }

}
