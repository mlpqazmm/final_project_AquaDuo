using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering.PostProcessing;
/*

[System.Serializable]
[PostProcess(typeof(CustomDepthFogRenderer), PostProcessEvent.AfterStack, "Custom/DepthFog")]
public sealed class CustomDepthFog : PostProcessEffectSettings
{
    // PostProcessEffectSettings���� �����ϴ� �Ķ���� ���� ���
    public ColorParameter fogNearColor = new ColorParameter { value = Color.white };
    public ColorParameter fogFarColor = new ColorParameter { value = Color.black };
    public FloatParameter startDistance = new FloatParameter { value = 10f };
    public FloatParameter endDistance = new FloatParameter { value = 100f };
}
public sealed class CustomDepthFogRenderer : PostProcessEffectRenderer<CustomDepthFog>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/CustomDepthFog"));
        sheet.properties.SetColor("_FogNearColor", settings.fogNearColor);
        sheet.properties.SetColor("_FogFarColor", settings.fogFarColor);
        sheet.properties.SetFloat("_StartDistance", settings.startDistance);
        sheet.properties.SetFloat("_EndDistance", settings.endDistance);

        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}*/