using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUi : MonoBehaviour
{
    public PlayerContllor contllor;
    public TextMeshProUGUI Text;
    public GameObject icon;



    private void IconRotation()
    {
        if(contllor.OnCooldown == false)
        {
            icon.GetComponent<Image>().fillAmount = 0;
        }
        else
        {

            icon.GetComponent<Image>().fillAmount =  contllor.cooldown /2;
        }
        
    }

    private void CoolDownMassge()
    {
        if (contllor.OnCooldown == false && contllor.currentStm >= 10)
        {
            Text.text = "";
            Text.color = Color.white;
        }
        else
        {
            if (contllor.currentStm < 10)
            {
                Text.text = "스테미나 부족!";
                Text.color = Color.red;
            }
            else
            {
                Text.text = $"{contllor.cooldown.ToString("F1")}";
                Text.color = Color.white;
            }
        }
    }


    private void Update()
    {
        IconRotation();
        CoolDownMassge();
    }
}
