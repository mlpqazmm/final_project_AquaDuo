using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{

    public MaterialSwitcher[] materialSwitchers; // MaterialSwitcher�� ���� ��� ������Ʈ�� ���� ����
    private GameObject[] trashObjects; // "Trash" �±׸� ���� ������Ʈ �迭

    void Start()
    {
        // �ʱ� ����: ��� MaterialSwitcher�� float ���� 1�� ����
        foreach (var switcher in materialSwitchers)
        {
            if (switcher != null)
            {
                switcher.materialState = 1; // ��� Material�� ����
            }
        }
    }

    void Update()
    {
        // �� �����Ӹ��� "Trash" �±׸� ���� ������Ʈ�� Ȯ��
        trashObjects = GameObject.FindGameObjectsWithTag("trash");

        // "Trash" ������Ʈ�� ��� ���������
        if (trashObjects.Length == 0)
        {
            // ��� MaterialSwitcher�� float ���� 0���� ����
            foreach (var switcher in materialSwitchers)
            {
                if (switcher != null)
                {
                    switcher.materialState = 0; // ���� Material�� ����
                }
            }
        }
    }
}