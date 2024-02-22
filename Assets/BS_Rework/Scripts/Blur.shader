Shader "Custom/HorizontalBlurShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _BlurAmount ("Blur Amount", Range(0, 100)) = 2.0
    }

    CGINCLUDE
    #include "UnityCG.cginc"
    ENDCG

    SubShader
    {
        Tags { "Queue" = "Overlay" }
        CGPROGRAM
        #pragma surface surf Standard

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;
        float _BlurAmount;

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            c += tex2D(_MainTex, IN.uv_MainTex + float2(_BlurAmount / 1920, 0));
            c += tex2D(_MainTex, IN.uv_MainTex - float2(_BlurAmount / 1080, 0));

            o.Albedo = c.rgb / 0.5;
            o.Alpha = 1.0;
        }
        ENDCG
    }
    FallBack "Diffuse"
}