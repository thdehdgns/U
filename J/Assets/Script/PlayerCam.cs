using Unity.VisualScripting;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // 벡터의 연산으로 구현
    Vector3 offset;
    public Transform playerTransform;
    public float smoothSpeed = 0.015f;
    public float fixedYPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        // transform = 카메라, 벡터의 합, 빼기  ->   A - B :   B에서 출발해서 A까지 이동하는 화살표 
        offset = transform.position  - playerTransform.position;
    }

    // 플레이어의 Update 움직인 직 후, 카메라가 따라서 움직인다.
    void LateUpdate()
    {
        CameraPos();
        // 벡터의 합 - 순간이동
        //transform.position = playerTransform.position + offset;
        // 플레이어가 움직일 겁니다.

        // 카메라의 Y 고정
        Vector3 targetPosition = playerTransform.position + offset;
        targetPosition.y = fixedYPosition;
        
        // 부드러운 카메라 이동
        Vector3 smoothPosition = Vector3.Lerp(new Vector3(transform.position.x, fixedYPosition, transform.position.z), targetPosition, smoothSpeed);
        transform.position = smoothPosition;
    }
    
    void CameraPos()
    {
        if(playerTransform.position.y >= 21)
        {
            fixedYPosition = 21;
        }
        else if(playerTransform.position.y >= 10)
        {
            fixedYPosition = 10;
        }
        else
        {
            fixedYPosition = 0;
        }
    }
}
