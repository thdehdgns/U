using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 offset;
    public GameObject playerPosition;
    
    void Start()
    {
        offset = transform.position - playerPosition.transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        
        offset = transform.position - playerPosition.transform.position;

        

        transform.position = playerPosition.transform.position + offset;

    }
}
