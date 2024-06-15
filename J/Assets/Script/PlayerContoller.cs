using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerContllor : MonoBehaviour
{
    [Header("이동")]
    public float MoveSpeed = 7; //이동속도
    public float DashSpeed = 17;
    public float JumpForce = 10; //점프력
    private float MoveInput;    //캐릭터 방향 
    //public Transform startTransform;
    public Rigidbody2D rigidbody2D; //물리 기능을 제어하는 컴포넌트

    [Header("점프")]
    public bool isGrounded; //true = can jump, flase = can't jump
    public float groundDistance = 1f;
    public LayerMask groundLayer;

    [Header("Flip")]
    public SpriteRenderer spriteRenderer;
    private bool facingRight = true;
    private int facingDriection = 1;

    public Animator animator;
    private bool isMove;

    [SerializeField] ParticleContoller particleContoller;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //transform.position = startTransform.position;
    }

    void InitalizePlayerStatus()
    {
        ///transform.position = startTransform.position;
        rigidbody2D.velocity = Vector2.zero;
        facingRight = true;
        spriteRenderer.flipX = false;
    }


    void Update()
    {
        HandleAnimation();
        CollisionCheck();
        HandleInput();
        HandleFlip();
        Dash();
        Move();
        //FallDownCheck();
    }

    private void FallDownCheck()
    {
        if(transform.position.y < -15)
        {
            InitalizePlayerStatus();
        }
    }

    private void HandleAnimation()
    {
        //giridbody.velocity : 현재 rigidbody의 속도 = 0 멈춤, !=0 움직이고있는상태
        isMove = rigidbody2D.velocity.x != 0;
        animator.SetBool("isMove",isMove);
        animator.SetBool("isGrounded", isGrounded);
        //SetFloat 함수에 의해 y최대일 때 1로 변환..y 최소일 때 -1로 변환
        //점프 키를 누르면. 순차적으로 y높이 증가, 
        animator.SetFloat("yVelocity", rigidbody2D.velocity.y);
    }

    /// <summary>
    /// 점프할 때 바닥인지 아닌지 체크하는 기능
    /// </summary>
    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
        particleContoller.isGround = isGrounded;
    }
    /// <summary>
    /// 움직임, 점프
    /// </summary>
    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            particleContoller.PlayParticle();
        }


        MoveInput = Input.GetAxis("Horizontal");
        JumpButton();
    }

    private void HandleFlip()
    {
        //오른쪽으로 방향을 바라보고있을 때 조건
        if (facingRight && MoveInput < 0)
        {
            Flip();
        }
        else if  (!facingRight && MoveInput > 0)
        {
            Flip();
        }

    }

    private void Flip()
    {
        facingDriection = facingDriection * -1;
        facingRight = !facingRight;
        spriteRenderer.flipX = !facingRight;
    }

    private void Jump()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.position.x, JumpForce);
    }

    private void JumpButton()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            //점프구현 : Y postion _ rigidbody Y velocity를 점프 파워만큼 올려주면 된다.

            Jump();

        }
    }

    private void Move()
    {
        
        rigidbody2D.velocity = new Vector2(MoveSpeed * MoveInput, rigidbody2D.velocity.y);
    }

    private void OndrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundDistance));
    }


    private void Dash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            MoveSpeed = DashSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            MoveSpeed = 7;
        }
    }
}
