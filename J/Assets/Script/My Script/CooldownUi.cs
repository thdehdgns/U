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
            Text.text = "�غ��";
        }
        else
        {
            if(contllor.currentStm < 10)
            {
                Text.text = "���׹̳��� �����Ͽ� ����� �Ұ�����";
            }
            else
            {
                Text.text = $"{contllor.cooldown}";

            }
        }
    }
}
