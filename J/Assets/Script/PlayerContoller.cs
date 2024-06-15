using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerContllor : MonoBehaviour
{
    [Header("�̵�")]
    public float MoveSpeed = 7; //�̵��ӵ�
    public float DashSpeed = 17;
    public float JumpForce = 10; //������
    private float MoveInput;    //ĳ���� ���� 
    //public Transform startTransform;
    public Rigidbody2D rigidbody2D; //���� ����� �����ϴ� ������Ʈ

    [Header("����")]
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
        //giridbody.velocity : ���� rigidbody�� �ӵ� = 0 ����, !=0 �����̰��ִ»���
        isMove = rigidbody2D.velocity.x != 0;
        animator.SetBool("isMove",isMove);
        animator.SetBool("isGrounded", isGrounded);
        //SetFloat �Լ��� ���� y�ִ��� �� 1�� ��ȯ..y �ּ��� �� -1�� ��ȯ
        //���� Ű�� ������. ���������� y���� ����, 
        animator.SetFloat("yVelocity", rigidbody2D.velocity.y);
    }

    /// <summary>
    /// ������ �� �ٴ����� �ƴ��� üũ�ϴ� ���
    /// </summary>
    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
        particleContoller.isGround = isGrounded;
    }
    /// <summary>
    /// ������, ����
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
        //���������� ������ �ٶ󺸰����� �� ����
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
            //�������� : Y postion _ rigidbody Y velocity�� ���� �Ŀ���ŭ �÷��ָ� �ȴ�.

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
