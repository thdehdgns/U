using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�浹�ϱ� ���ؼ��� �� ��ü �� �� ��ü�� Rigidbody(2D)�� �������־�� �Ѵ�.
//�� ��ü ���δ� Collider�� ���� �־���Ѵ�.
//�÷��̾�� �浹�ϸ� 


public class Trap : MonoBehaviour
{
    //�浹 �̺�Ʈ�� �ۼ��� ��, ��� ������Ʈ�� ������� �ۼ��� ���� ���� ����.
    //���� ���� �鿡���� ��ȿ�����̴�.
    //�⵹ �̺�Ʈ�� Ư�� ��� �۵��ϵ��� �±׸� �޾��ش�.
    //Tag - ������ �浹 �̺�Ʈ ����
    //Layer - �����Ѱ�

    //Collider 2D�̰� Rigidbody 2D���� �Ѵ� 

    protected bool isWorking = false;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        //�÷��̾� �±׸� ������ �ִ°�?
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ ������ �ǰݴ���");
        }    
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ ������ �ǰݴ���");
        }
    }
}
