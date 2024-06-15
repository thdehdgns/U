using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleContoller : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;
    [SerializeField] ParticleSystem jumpparticle;
    [SerializeField] ParticleSystem myparticle;

    //플레이어 속도에 따라 파티클을 생성하는 제어 조건
    [SerializeField] int occurAfterVelocity;

    //먼지 생성 주기
    [SerializeField] float dustFormationTime;
    [SerializeField] Rigidbody2D playerRb;

    float counter;  //먼지생성 주기를 체크하기 위한 시간 변수
    public bool isGround;  //플레이어의 점프 상태를 체크하기 위한 변수

    private void Update()
    {
        CheckAfterVelocity();
    }

    

    public void PlayParticle()
    {
        myparticle.Play();
    }

    private void CheckAfterVelocity()
    {
        counter += Time.deltaTime;
        if (isGround && Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity)
        {
            CheckDustFormationTime();

        }
    }

    private void CheckDustFormationTime()
    {

        if ( counter > dustFormationTime)
        {
            movementParticle.Play();
            counter = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            jumpparticle.Play();
            isGround = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

}
