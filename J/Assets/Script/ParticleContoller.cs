using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleContoller : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;
    [SerializeField] ParticleSystem jumpparticle;
    [SerializeField] ParticleSystem myparticle;

    //�÷��̾� �ӵ��� ���� ��ƼŬ�� �����ϴ� ���� ����
    [SerializeField] int occurAfterVelocity;

    //���� ���� �ֱ�
    [SerializeField] float dustFormationTime;
    [SerializeField] Rigidbody2D playerRb;

    float counter;  //�������� �ֱ⸦ üũ�ϱ� ���� �ð� ����
    public bool isGround;  //�÷��̾��� ���� ���¸� üũ�ϱ� ���� ����

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
