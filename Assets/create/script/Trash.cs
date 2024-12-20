using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class Trash : MonoBehaviour
{

    public Material dissolveMaterial; // Dissolve Shader Material
    private Material instantiatedMaterial; // ������ Material
    private Renderer objectRenderer; // ������Ʈ Renderer
    private float intensity = -2f; // ������ ���൵ (-2���� ����)
    private bool isDissolving = false; // ������ ����
    public float dissolveSpeed = 1f; // ������ �ӵ� ����
    private bool isPlayerInRange = false; // �÷��̾ ���� �ȿ� �ִ��� Ȯ��
    public GameObject dissolveParticlePrefab; // Dissolve Particle Prefab
    private GameObject particleObject; // ������ Particle System ������Ʈ

    void Start()
    {
        // Renderer �������� �� Material ����
        objectRenderer = GetComponent<Renderer>();
        instantiatedMaterial = new Material(dissolveMaterial); // Material ����
        objectRenderer.material = instantiatedMaterial; // Renderer�� ������ Material ����
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾ ������ �������� ǥ��
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾ ������ ������� ǥ��
            isPlayerInRange = false;
        }
    }

    void Update()
    {
        // �÷��̾ ���� �ȿ� �ְ�, E Ű�� ������ ���� ������ ����
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !isDissolving)
        {
            isDissolving = true;

            // ������ ���� �� ��ƼŬ ���� �� ���
            if (dissolveParticlePrefab != null)
            {
                particleObject = Instantiate(dissolveParticlePrefab, transform.position, Quaternion.identity);
                ParticleSystem particleSystem = particleObject.GetComponent<ParticleSystem>();
                if (particleSystem != null)
                {
                    particleSystem.Play(); // Particle System ���� ����
                }
                else
                {
                   // Debug.LogError("No ParticleSystem component found on the prefab!");
                }
            }
        }

        if (isDissolving)
        {
            // intensity ���� ���������� ����
            intensity += Time.deltaTime * dissolveSpeed;
            instantiatedMaterial.SetFloat("_intensity", intensity); // Shader �Ӽ� ����

            if (particleObject != null)
            {
                // ��ƼŬ ��ġ�� ������ ������Ʈ�� ����ȭ
                particleObject.transform.position = transform.position;
            }

            // ������ �Ϸ� �� ������Ʈ ����
            if (intensity >= 1f)
            {
                if (particleObject != null)
                {
                    // ��ƼŬ ��� �Ϸ� �� ��ƼŬ ������Ʈ ����
                    Destroy(particleObject, 2f); // 2�� �� �ڵ� ����
                }
                Destroy(gameObject); // ������ ������Ʈ ����
            }
        }
    }
}