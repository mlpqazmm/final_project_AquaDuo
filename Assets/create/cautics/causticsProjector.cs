using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;

//using System.Threading;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class causticsProjector : MonoBehaviour
{

    public DecalProjector projector;  // Decal Projector 컴포넌트
    public Texture[] causticTextures; // 애니메이션에 사용할 텍스처 배열
    public int framesPerSecond = 30;  // 1초에 보여줄 프레임 수 (애니메이션 속도)
    public Material projectorMaterial; // 인스턴스화된 Material
    private int currentFrame = 0;       // 현재 프레임 인덱스
    private float timePerFrame;         // 각 프레임당 시간
    private float nextFrameTime;        // 다음 프레임으로 넘어갈 시간

    Material newMaterial;

    void Start()
    {
        projector.material = projectorMaterial;
        // Decal Projector의 현재 Material을 복사하여 인스턴스화
        projectorMaterial = new Material(projector.material);
        projector.material = projectorMaterial;  // 인스턴스화된 Material을 Decal Projector에 적용

        newMaterial = new Material(projector.material);

        timePerFrame = 1.0f / framesPerSecond;   // 각 프레임의 시간 계산
        nextFrameTime = Time.time + timePerFrame; // 첫 번째 프레임 전환 시간
    }

    void Update()
    {
        // 시간이 지나면 텍스처를 교체
        if (Time.time >= nextFrameTime)
        {
            currentFrame = (currentFrame + 1) % causticTextures.Length;  // 현재 프레임 업데이트
            //Material newMaterial = new Material(projector.material);
            newMaterial.SetTexture("_BaseMap", causticTextures[currentFrame]);  // 텍스처 변경
            projector.material = newMaterial;

            Debug.Log("Current Frame: " + currentFrame);  // 디버그 메시지 출력
            nextFrameTime += timePerFrame;  // 다음 프레임 시간 계산
        }
    }
}