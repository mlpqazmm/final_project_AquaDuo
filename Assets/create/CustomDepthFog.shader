Shader "Custom/CustomDepthFog"
{
    Properties
    {
        _FogNearColor("Fog Near Color", Color) = (1,1,1,1)
        _FogFarColor("Fog Far Color", Color) = (0,0,0,1)
        _StartDistance("Fog Start Distance", Float) = 10
        _EndDistance("Fog End Distance", Float) = 100
    }

        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            float4 _FogNearColor;
            float4 _FogFarColor;
            float _StartDistance;
            float _EndDistance;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 worldPos : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                // 카메라와의 거리 계산
                float depth = length(i.worldPos - _WorldSpaceCameraPos);

            // 거리 기반으로 Fog 색상 보간
            float fogFactor = saturate((depth - _StartDistance) / (_EndDistance - _StartDistance));
            half4 fogColor = lerp(_FogNearColor, _FogFarColor, fogFactor);

            return fogColor;
        }
        ENDCG
    }
    }
}