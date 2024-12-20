using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{

    public Material originalMaterial; // ���� Material
    public Material grayscaleMaterial; // ��� Material
    private MeshRenderer meshRenderer; // MeshRenderer ������Ʈ

    [Range(0, 1)] // �����̴��� ����Ͽ� ���� 0�� 1�� ����
    public int materialState = 0; // 0: ���� Material, 1: ��� Material

    private int previousState = -1; // ���� ���¸� �����Ͽ� ���� ���� �ÿ��� ������Ʈ

    void Start()
    {
        // MeshRenderer ��������
        meshRenderer = GetComponent<MeshRenderer>();

        // �ʱ� Material ����
        if (meshRenderer != null && originalMaterial == null)
        {
            originalMaterial = meshRenderer.material;
        }
    }

    void Update()
    {
        // Material ���°� ����Ǿ��� ���� ������Ʈ
        if (materialState != previousState)
        {
            SwitchMaterial(materialState);
            previousState = materialState; // ���� ���¸� ����
        }
    }

    void SwitchMaterial(int state)
    {
        if (meshRenderer != null)
        {
            // ���¿� ���� Material ��ü
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