Shader "Custom/NewSurfaceShader"
{
    Properties
    {
        _MainTex("Caustics (RGB)", 2D) = "white" {}
        _Color("Main Color", Color) = (1,1,1,1)
        _Cutoff("Alpha Cutoff", Range(0,1)) = 0.5
    }
        SubShader
        {
            Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
            LOD 200

            // Projector 전용 설정: ZWrite Off, Blend On
            Pass
            {
                ZWrite Off
                ColorMask RGB
                Blend SrcAlpha OneMinusSrcAlpha

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                sampler2D _MainTex;
                fixed4 _Color;
                half _Cutoff;

                struct appdata_t
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float4 pos : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 tex = tex2D(_MainTex, i.uv) * _Color;

                // Alpha Cutoff를 사용한 투명 영역 처리
                clip(tex.a - _Cutoff);

                return tex;
            }
            ENDCG
        }
        }
            Fallback "Transparent/Cutout/VertexLit"
}