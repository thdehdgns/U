using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CooldownUi : MonoBehaviour
{
    public PlayerContllor contllor;
    public TextMeshProUGUI Text;
    private void Update()
    {
        if(contllor.OnCooldown == false && contllor.currentStm >= 10)
        {
            Text.text = "준비됨";
        }
        else
        {
            if(contllor.currentStm < 10)
            {
                Text.text = "스테미나가 부족하여 사용이 불가능함";
            }
            else
            {
                Text.text = $"{contllor.cooldown}";

            }
        }
    }
}
