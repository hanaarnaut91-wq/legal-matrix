Shader "UI/CircleMaskSmooth"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _Radius ("Radius", Range(0,0.5)) = 0.5
        _Softness ("Softness", Range(0.0001, 0.1)) = 0.01
        _RectSize ("Rect Size", Vector) = (100,100,0,0)
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "IgnoreProjector"="True"
            "CanUseSpriteAtlas"="True"
        }

        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv     : TEXCOORD0;
                float4 color  : COLOR;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv     : TEXCOORD0;
                float4 color  : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;

            float _Radius;
            float _Softness;
            float2 _RectSize;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color * _Color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // center UV
                float2 uv = i.uv - 0.5;

                // FIX: correct aspect using actual UI RectTransform size
                float aspect = _RectSize.x / _RectSize.y;
                uv.x *= aspect;

                // circle SDF
                float dist = length(uv);

                // smooth circle edge
                float alpha = 1.0 - smoothstep(_Radius - _Softness, _Radius, dist);

                fixed4 col = tex2D(_MainTex, i.uv) * i.color;
                col.a *= alpha;

                return col;
            }
            ENDCG
        }
    }
}
