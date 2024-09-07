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

    public Transform transform;

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
    private bool isRoul;
    [SerializeField] ParticleContoller particleContoller;

    public bool DashG = false;
    public CapsuleCollider2D capsuleCollider;

    public float Maxcooldown = 0f;
    public float cooldown = 2f; //������ ��Ÿ��
    public bool OnCooldown = false;

    [Header("Hp �� ���׹̳�")]
    public int currentHp = 1;
    public int MaxHp = 5;
    public float MaxStm = 30;
    public float currentStm = 30;
    public bool DashOn = false;
    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        transform = GetComponent<Transform>();
        currentHp = MaxHp;
    }

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
        IscoolDown();
        asdf();
        HandleAnimation();
        CollisionCheck();
        HandleInput();
        HandleFlip();
        Dash();
        Move();
        OnDash();
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
        if(AudioManager.instance == null)
        {
            Debug.LogWarning($"{nameof(AudioManager)}�� instance�� �����ϴ�.");
            return;
        }
        AudioManager.instance.PlaySFX(3); 
    }

    private void JumpButton()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            //�������� : Y postion _ rigidbody Y velocity�� ���� �Ŀ���ŭ �÷��ָ� �ȴ�.

            Jump();

        }
    }

    private void IscoolDown()
    {
        if(OnCooldown == true)
        {
            if(cooldown >= 0) 
            { 

                cooldown -= Time.deltaTime;
            }
            else if(cooldown <= 0)
            {
                cooldown = 2;
                OnCooldown = false;
            }
        }
    }

    private void asdf()
    {
        if (OnCooldown == false)
        { 
            if (currentStm >= 10)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Roul();
                    OnCooldown = true;
                }
            }
        }
    }

    private void Roul()
    {
        StartCoroutine(asf());
        
        StopCoroutine(asf());
    }

    IEnumerator asf()
    {
        currentStm -= 10;
        isRoul = true;
        animator.SetBool("IsRoul", isRoul);
        gameObject.tag = "Untagged";
        for(int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.05f);
            transform.position = new Vector2(transform.position.x + (1 * facingDriection), transform.position.y);
        }
        gameObject.tag = "Player";
        isRoul = false;
        animator.SetBool("IsRoul", isRoul);
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

   
    private void OnDash()
    {
        if(DashOn == true)
        {

            currentStm = currentStm - (Time.deltaTime*3);
            
        }
        else if(DashOn == false)
        {
            if(currentStm <= MaxStm)
            {
                currentStm += Time.deltaTime;
            }
            else if(currentStm >= MaxStm)
            {
                //Debug.Log("���¹̰� ���� �� �ֽ��ϴ�!");
            }
        }
    }

    private void Dash()
    {
        if(currentStm >= 3)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                MoveSpeed = DashSpeed;
                DashOn = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
            {
                MoveSpeed = 7;
                DashOn = false;
            }
        }
        else if(currentStm < 0)
        {
            Debug.Log("���׹̳��� �����մϴ�!.");
            DashOn = false;
            MoveSpeed = 7;
        }
        
        

    }
}
