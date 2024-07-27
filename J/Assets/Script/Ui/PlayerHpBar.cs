using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    public Slider Hpbar;
    public PlayerContllor palyer;

    private void Awake()
    {
        Hpbar.maxValue = palyer.MaxHp;
    }

    private void Update()
    {
        HpUI();
    }

    private void HpUI()
    {
        Hpbar.value = palyer.currentHp;
    }
}
