using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleUo : MonoBehaviour
{
    public GameObject AppleObject;
    public Transform appleUp;
    public Transform appleDown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AppleObject.transform.position = appleUp.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AppleObject.transform.position = appleDown.transform.position;
        }
    }





}
