using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    BoxCollider2D boxCollider2d;
    Rigidbody2D rigidbody2d;
    SpriteRenderer spriteRenderer;
    public bool starting = true;

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

            PlayerContllor player = collision.gameObject.GetComponent<PlayerContllor>();

            player.currentHp = player.currentHp - GameManager.instance.difficulty - 1; //난이도 만큼 체력이 깎임 
            
            if(player.currentHp <= 0)
            {
                MainContollor.instance.GameOverUI();
            }
             
            
            


            MainContollor.instance.bestscore();

        }
    }

    
}
