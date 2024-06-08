using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Trap
{
    public GameObject AppleObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AppleObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AppleObject.SetActive(true);
        }
    }


}
