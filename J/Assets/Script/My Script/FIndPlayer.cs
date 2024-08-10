using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIndPlayer : MonoBehaviour
{
    public PlayerCam playercam;

    private void Start()
    {
        playercam = GameObject.Find("Main Camera").GetComponent<PlayerCam>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ ȭ�鿡 �������� �ʽ��ϴ�.");
            playercam.playerTransform = null;
        }
    }


}
