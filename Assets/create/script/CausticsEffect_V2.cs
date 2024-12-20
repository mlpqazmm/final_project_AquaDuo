using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CausticsEffect_V2 : MonoBehaviour
{
    public float scrollSpeedX = 0.1f;
    public float scrollSpeedY = 0.1f;
    private Material causticsMaterial;
    private Vector2 offset;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        causticsMaterial = renderer.material;
    }

    void Update()
    {
        offset.x += scrollSpeedX * Time.deltaTime;
        offset.y += scrollSpeedY * Time.deltaTime;
        causticsMaterial.SetTextureOffset("_CausticsTex", offset);
    }
}