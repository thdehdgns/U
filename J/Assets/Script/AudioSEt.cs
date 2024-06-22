using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSEt : MonoBehaviour
{
    public GameObject Setting;
    

    public void setting()
    {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Setting.SetActive(true);
                
            }

    }

    private void Update()
    {
        setting();
    }
    public void Exit()
    {
        
        Setting.SetActive(false);
    }
}
