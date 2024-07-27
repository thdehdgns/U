using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistoryPostion : MonoBehaviour
{
    private void LateUpdate()
    {
        if (transform.position.x < Constrant.min.x||
        transform.position.x > Constrant.max.x ||
        transform.position.y < Constrant.min.y ||
        transform.position.y > Constrant.max.x)
    {
            Destroy(gameObject);
        }
    }
}
