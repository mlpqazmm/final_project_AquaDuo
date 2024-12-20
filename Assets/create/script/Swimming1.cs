using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming1 : MonoBehaviour
{
    public float moveSpeed = 1f;      // 기본 이동 속도
    public float fastSpeedMultiplier = 2f;  // 빠른 이동 시 속도 배수
    public Camera playerCamera;       // 플레이어가 따라갈 카메라
    public Animator animator;         // 애니메이션 제어를 위한 애니메이터
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
        HandleAnimations();
    }

    void MovePlayer()
    {
        // 카메라가 바라보는 방향을 기준으로 이동 방향 설정
        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        // 입력 받기
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 카메라의 모든 회전(상하/좌우)을 반영하여 이동 방향 결정
        Vector3 moveDirection = forward * vertical + right * horizontal;

        // 'S'키를 눌렀을 때 후진
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection = -forward;  // 후진 방향
        }

        // SHIFT를 눌렀을 때 속도 증가
        bool isFast = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float currentSpeed = isFast ? moveSpeed * fastSpeedMultiplier : moveSpeed;

        // 캐릭터가 움직일 때, 이동하는 방향을 바라보도록 회전 처리
        if (moveDirection.magnitude > 0.1f)
        {
            // 이동하는 방향을 바라보도록 회전
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 0.1f);
        }

        // 플레이어 움직이기
        characterController.Move(moveDirection * currentSpeed * Time.deltaTime);
    }

    void HandleAnimations()
    {
        // 플레이어가 움직이는지 여부 확인
        Vector3 velocity = characterController.velocity;
        velocity.y = 0;  // Y축을 무시한 수평 속도

        bool isMoving = velocity.magnitude > 0.1f;
        bool isFast = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // 애니메이터 파라미터 설정
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isFast", isFast);

        // 애니메이션 처리
        if (!isMoving)
        {
            // 움직이지 않을 때
            animator.Play("IDLE");
        }
        else
        {
            if (isFast)
            {
                // 빠르게 이동 중일 때
                animator.Play("FAST");
            }
            else
            {
                // 일반 속도로 이동 중일 때
                animator.Play("MOVE");
            }
        }
    }
}
