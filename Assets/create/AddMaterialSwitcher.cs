using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AddMaterialSwitcher : MonoBehaviour
{
    void Start()
    {
        // Hierarchy에 있는 모든 오브젝트 검색
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // MeshRenderer가 있는 오브젝트에만 적용
            if (obj.GetComponent<MeshRenderer>() != null)
            {
                MaterialSwitcher switcher = obj.GetComponent<MaterialSwitcher>();

                if (switcher == null)
                {
                    // MaterialSwitcher가 없으면 추가
                    switcher = obj.AddComponent<MaterialSwitcher>();
                }

                // materialState 값을 1로 설정
                switcher.materialState = 1;
            }
        }

       // Debug.Log("MaterialSwitcher 스크립트가 추가되고 모든 materialState가 1로 설정되었습니다.");
    }
}