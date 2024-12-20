using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera: MonoBehaviour
{

    public Transform swimmerBot;    // 헤엄치는 로봇
    public Transform crawlerBot;     // 플레이어 캐릭터
    public Swimming swimmerMovement; // 헤엄치는 로봇의 이동 스크립트
    public Swimming1 crawlerMovement; // 바닥 로봇의 이동 스크립트
    public float distance = 5.0f;   // 카메라와 플레이어 사이의 거리
    public float height = 2.0f;     // 카메라의 높이
    public float rotationSpeed = 5.0f;  // 마우스 회전 속도
    private Transform player; // 현재 카메라가 따라다니는 대상
    private float currentX = 0.0f;  // 마우스의 X축 이동
    private float currentY = 0.0f;  // 마우스의 Y축 이동

    void Start()
    {
        player = swimmerBot; // 초기 타겟 설정
        SwitchMovement(true);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchTarget();
        }

        // 마우스 입력을 받아 카메라 회전 처리
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        currentY = Mathf.Clamp(currentY, -20, 60);  // 카메라 Y축 회전 각도 제한
    }
    
    void LateUpdate()
    {
        // 카메라의 위치 및 회전 설정
        Vector3 direction = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = player.position + rotation * direction;
        transform.LookAt(player.position + Vector3.up * height);
    }

    void SwitchTarget()
    {
        // 현재 타겟을 전환
        if (player == swimmerBot)
        {
            player = crawlerBot;
            SwitchMovement(false); // swimmerBot 멈추고 crawlerBot 활성화
        }
        else
        {
            player = swimmerBot;
            SwitchMovement(true); // crawlerBot 멈추고 swimmerBot 활성화
        }
    }


    void SwitchMovement(bool isSwimmerActive)
    {
        swimmerMovement.enabled = isSwimmerActive; // swimmerBot 이동 활성화
        crawlerMovement.enabled = !isSwimmerActive; // crawlerBot 이동 비활성화
    }

}