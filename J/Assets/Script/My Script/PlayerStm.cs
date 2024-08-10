using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStm : MonoBehaviour
{
    public Slider StmBar;
    public PlayerContllor playerContllor;
    public GameObject Warning;


    private void Start()
    {
        StmBar = GetComponent<Slider>();
        StmBar.maxValue = playerContllor.MaxStm;
        Warning.SetActive(false);
    }

    private void Update()
    {
        asdf();
    }

    private void NullComtonent()
    {
        if (playerContllor == null)
        {
            playerContllor = GameObject.Find("Player").GetComponent<PlayerContllor>();
        }
        
    }

    private void asdf()
    {
        StmBar.value = playerContllor.currentStm;
        if(playerContllor.currentStm <= 3)
        {
            Warning.SetActive(true);
        }
        else
        {
            Warning.SetActive(false);
        }
    }
}
