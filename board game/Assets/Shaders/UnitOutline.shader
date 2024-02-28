Shader "Custom/UnitOutline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineWidth ("Outline Width", Range (0.0, 0.1)) = 0.01
    }
    SubShader
    {
        Tags {"Queue"="Overlay" "RenderType"="Opaque"}
        LOD 100
        
        Pass
        {
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            float _OutlineWidth;
            
            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);

                // Apply outline width
                float4 pos = UnityObjectToClipPos(v.vertex);
                float2 screenSize = _ScreenParams.xy / pos.w;
                pos.xy += normalize(pos.xy - _ScreenParams.xy) * _OutlineWidth * screenSize.x;
                o.pos = ComputeScreenPos(pos);

                return o;
            }

            fixed4 _OutlineColor;

            half4 frag(v2f i) : SV_Target
            {
                return _OutlineColor;
            }
            ENDCG
        }

        // Main pass for rendering the object's main texture
        CGPROGRAM
        #pragma surface surf Lambert

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    Fallback "Diffuse"
}
