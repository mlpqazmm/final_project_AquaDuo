using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyCaudticsMaterial : MonoBehaviour
{
    public Material causticsMaterial; // Caustic Material을 드래그해서 할당

    void Start()
    {
        // "CausticObjects"라는 레이어가 할당된 모든 오브젝트에 Material을 적용
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Caustics");

        foreach (GameObject obj in objects)
        {
            MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.material = causticsMaterial;
            }
        }
    }
}