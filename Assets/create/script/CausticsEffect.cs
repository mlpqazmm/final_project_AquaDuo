using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CausticsEffect : MonoBehaviour
{
    public Material causticsMaterial;  // 적용할 머티리얼
    public float scrollSpeed = 0.5f;   // 텍스처 이동 속도

    void Update()
    {
        // 텍스처 좌표를 시간에 따라 이동
        float offset = Time.time * scrollSpeed;
        causticsMaterial.SetTextureOffset("_BaseMap", new Vector2(offset, offset));
    }
}
