using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Saw : Trap
{
    public Animator anim;
    public Transform[] movePistions;    //톱니바퀴를 이동할 위치를 저장할 변수
    public float speed = 5f;
    public int moveIndex = 0;
    public bool OnGoing;
    public bool IsTrap = true;      //trap를 움직일지 말지 
    public int StopTime = 1;    //트랩 멈추는 시간

    private void Start()
    {
        anim = GetComponent<Animator>();

        isWorking = true;
    }

    private void Update()
    {
        anim.SetBool("isWorking", isWorking);

        if(IsTrap)
            MoveTrap();
    }

    IEnumerator CoMoveTrap()
    {
        IsTrap = false;
        yield return new WaitForSeconds(StopTime);
        IsTrap = true;
    }

    private void MoveTrap()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePistions[moveIndex].position,speed * Time.deltaTime);
        //조건문 - 함정이 목표 지역까지 도착했는가?
        if( Vector3.Distance(transform.position, movePistions[moveIndex].position) <= 0.1)
        {

            moveIndex++;
            StartCoroutine(CoMoveTrap());// startcorouthin은 update에 들어가면 않된다.
        }
        //다음 목표지적이 없으면..moveIndex = 0
        if(movePistions.Length <= moveIndex)
        {
            moveIndex = 0;
        }
    }


    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision); 
        if(collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
