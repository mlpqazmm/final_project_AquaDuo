using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class Trash : MonoBehaviour
{

    public Material dissolveMaterial; // Dissolve Shader Material
    private Material instantiatedMaterial; // 복제된 Material
    private Renderer objectRenderer; // 오브젝트 Renderer
    private float intensity = -2f; // 디졸브 진행도 (-2에서 시작)
    private bool isDissolving = false; // 디졸브 상태
    public float dissolveSpeed = 1f; // 디졸브 속도 조절
    private bool isPlayerInRange = false; // 플레이어가 범위 안에 있는지 확인
    public GameObject dissolveParticlePrefab; // Dissolve Particle Prefab
    private GameObject particleObject; // 생성된 Particle System 오브젝트

    void Start()
    {
        // Renderer 가져오기 및 Material 복제
        objectRenderer = GetComponent<Renderer>();
        instantiatedMaterial = new Material(dissolveMaterial); // Material 복제
        objectRenderer.material = instantiatedMaterial; // Renderer에 복제된 Material 적용
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어가 범위에 들어왔음을 표시
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어가 범위를 벗어났음을 표시
            isPlayerInRange = false;
        }
    }

    void Update()
    {
        // 플레이어가 범위 안에 있고, E 키를 눌렀을 때만 디졸브 시작
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !isDissolving)
        {
            isDissolving = true;

            // 디졸브 시작 시 파티클 생성 및 재생
            if (dissolveParticlePrefab != null)
            {
                particleObject = Instantiate(dissolveParticlePrefab, transform.position, Quaternion.identity);
                ParticleSystem particleSystem = particleObject.GetComponent<ParticleSystem>();
                if (particleSystem != null)
                {
                    particleSystem.Play(); // Particle System 수동 실행
                }
                else
                {
                   // Debug.LogError("No ParticleSystem component found on the prefab!");
                }
            }
        }

        if (isDissolving)
        {
            // intensity 값을 점진적으로 증가
            intensity += Time.deltaTime * dissolveSpeed;
            instantiatedMaterial.SetFloat("_intensity", intensity); // Shader 속성 전달

            if (particleObject != null)
            {
                // 파티클 위치를 디졸브 오브젝트와 동기화
                particleObject.transform.position = transform.position;
            }

            // 디졸브 완료 시 오브젝트 제거
            if (intensity >= 1f)
            {
                if (particleObject != null)
                {
                    // 파티클 재생 완료 후 파티클 오브젝트 삭제
                    Destroy(particleObject, 2f); // 2초 후 자동 삭제
                }
                Destroy(gameObject); // 쓰레기 오브젝트 삭제
            }
        }
    }
}