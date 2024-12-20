using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AddMaterialSwitcher : MonoBehaviour
{
    void Start()
    {
        // Hierarchy�� �ִ� ��� ������Ʈ �˻�
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // MeshRenderer�� �ִ� ������Ʈ���� ����
            if (obj.GetComponent<MeshRenderer>() != null)
            {
                MaterialSwitcher switcher = obj.GetComponent<MaterialSwitcher>();

                if (switcher == null)
                {
                    // MaterialSwitcher�� ������ �߰�
                    switcher = obj.AddComponent<MaterialSwitcher>();
                }

                // materialState ���� 1�� ����
                switcher.materialState = 1;
            }
        }

       // Debug.Log("MaterialSwitcher ��ũ��Ʈ�� �߰��ǰ� ��� materialState�� 1�� �����Ǿ����ϴ�.");
    }
}