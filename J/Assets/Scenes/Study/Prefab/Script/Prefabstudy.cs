using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabstudy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Transform transform;
    public BoxCollider2D boxCollider2D;
    public Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

    }





}
