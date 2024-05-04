using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerContllor : MonoBehaviour
{
    [Header("�̵�")]
    public float MoveSpeed = 7; //�̵��ӵ�
    public float JumpForce = 10; //������
    private float MoveInput;    //ĳ���� ���� 
    public Transform startTransform;
    public Rigidbody2D rigidbody2D; //���� ����� �����ϴ� ������Ʈ

    [Header("����")]
    public bool isGrounded; //true = can jump, flase = can't jump
    public float groundDistance = 1f;
    public LayerMask groundLayer;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        transform.position = startTransform.position;
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
        
        //Debug.Log("�̷��� ���� ���� ���� ���ð���");
        MoveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(MoveSpeed * MoveInput,rigidbody2D.velocity.y);       
        
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            //�������� : Y postion _ rigidbody Y velocity�� ���� �Ŀ���ŭ �÷��ָ� �ȴ�.
            
            rigidbody2D.velocity = new Vector2(rigidbody2D.position.x, JumpForce);
            
        }
        
    }
    private void OndrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundDistance));
    }
}
