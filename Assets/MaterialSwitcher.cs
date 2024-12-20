using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{

    public Material originalMaterial; // 원래 Material
    public Material grayscaleMaterial; // 흑백 Material
    private MeshRenderer meshRenderer; // MeshRenderer 컴포넌트

    [Range(0, 1)] // 슬라이더를 사용하여 값을 0과 1로 제한
    public int materialState = 0; // 0: 원래 Material, 1: 흑백 Material

    private int previousState = -1; // 이전 상태를 저장하여 상태 변경 시에만 업데이트

    void Start()
    {
        // MeshRenderer 가져오기
        meshRenderer = GetComponent<MeshRenderer>();

        // 초기 Material 설정
        if (meshRenderer != null && originalMaterial == null)
        {
            originalMaterial = meshRenderer.material;
        }
    }

    void Update()
    {
        // Material 상태가 변경되었을 때만 업데이트
        if (materialState != previousState)
        {
            SwitchMaterial(materialState);
            previousState = materialState; // 현재 상태를 저장
        }
    }

    void SwitchMaterial(int state)
    {
        if (meshRenderer != null)
        {
            // 상태에 따라 Material 교체
            if (state == 0)
            {
                meshRenderer.material = originalMaterial;
            }
            else if (state == 1)
            {
                meshRenderer.material = grayscaleMaterial;
            }
        }
    }
}