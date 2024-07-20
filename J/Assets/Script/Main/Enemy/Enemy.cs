using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    BoxCollider2D boxCollider2d;
    Rigidbody2D rigidbody2d;
    SpriteRenderer spriteRenderer;

    void LoadComponents()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    void Awake()
    {
        LoadComponents();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainContollor.instance.GameOverUI();
            MainContollor.instance.bestscore();

        }
    }

    
}
