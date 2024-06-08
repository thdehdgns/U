using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullit : MonoBehaviour
{
    public int moveIndex = 0;
    public Transform[] movePistions;
    public float speed = 20f;

    private void bullit()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePistions[moveIndex].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePistions[moveIndex].position) <= 0.1)
        {

            moveIndex++;
            
        }
        if (movePistions.Length <= moveIndex)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        bullit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


}
