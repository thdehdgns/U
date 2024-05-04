using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerContllor : MonoBehaviour
{
    [Header("이동")]
    public float MoveSpeed = 7; //이동속도
    public float JumpForce = 10; //점프력
    private float MoveInput;    //캐릭터 방향 
    public Transform startTransform;
    public Rigidbody2D rigidbody2D; //물리 기능을 제어하는 컴포넌트

    [Header("점프")]
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
        
        //Debug.Log("이렇게 쓰면 아주 많이 나올거임");
        MoveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(MoveSpeed * MoveInput,rigidbody2D.velocity.y);       
        
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            //점프구현 : Y postion _ rigidbody Y velocity를 점프 파워만큼 올려주면 된다.
            
            rigidbody2D.velocity = new Vector2(rigidbody2D.position.x, JumpForce);
            
        }
        
    }
    private void OndrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundDistance));
    }
}
