using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    public GameObject goalobject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ ��ǥ������ ������");

            goalobject.SetActive(true);
            //TMP_Text goalText = goalobject.GetComponent<TMP_Text>();
            //goalText.text = "���� Ŭ����!";
            Time.timeScale = 0f;
        }
    }

}
