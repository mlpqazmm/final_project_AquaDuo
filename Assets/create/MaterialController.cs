using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{

    public MaterialSwitcher[] materialSwitchers; // MaterialSwitcher가 붙은 모든 오브젝트를 수동 연결
    private GameObject[] trashObjects; // "Trash" 태그를 가진 오브젝트 배열

    void Start()
    {
        // 초기 상태: 모든 MaterialSwitcher의 float 값을 1로 설정
        foreach (var switcher in materialSwitchers)
        {
            if (switcher != null)
            {
                switcher.materialState = 1; // 흑백 Material로 설정
            }
        }
    }

    void Update()
    {
        // 매 프레임마다 "Trash" 태그를 가진 오브젝트를 확인
        trashObjects = GameObject.FindGameObjectsWithTag("trash");

        // "Trash" 오브젝트가 모두 사라졌으면
        if (trashObjects.Length == 0)
        {
            // 모든 MaterialSwitcher의 float 값을 0으로 설정
            foreach (var switcher in materialSwitchers)
            {
                if (switcher != null)
                {
                    switcher.materialState = 0; // 원래 Material로 설정
                }
            }
        }
    }
}