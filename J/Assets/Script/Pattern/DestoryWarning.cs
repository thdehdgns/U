using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestoryWarning : MonoBehaviour
{
    
    public float Tick = 0f;
    private void Update()
    {
        TickTime();
    }

    public void TickTime()
    {
        Tick += Time.deltaTime;
        if(Tick >= 4f)
        {

            Destroy(gameObject);
        }
        
    }
}
