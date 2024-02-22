Shader "Custom/GaussianBlurShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _BlurAmount ("Blur Amount", Range(0, 10)) = 2.0
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
            fixed4 col = (1.0 / 16.0) * tex2D(_MainTex, IN.uv_MainTex);
            col += (2.0 / 16.0) * tex2D(_MainTex, IN.uv_MainTex + float2(_BlurAmount / 1920, 0));
            col += (2.0 / 16.0) * tex2D(_MainTex, IN.uv_MainTex - float2(_BlurAmount / 1920, 0));
            col += (4.0 / 16.0) * tex2D(_MainTex, IN.uv_MainTex + float2(2.0 * _BlurAmount / 1920, 0));
            col += (4.0 / 16.0) * tex2D(_MainTex, IN.uv_MainTex - float2(2.0 * _BlurAmount / 1920, 0));
            col += (2.0 / 16.0) * tex2D(_MainTex, IN.uv_MainTex + float2(3.0 * _BlurAmount / 1920, 0));
            col += (2.0 / 16.0) * tex2D(_MainTex, IN.uv_MainTex - float2(3.0 * _BlurAmount / 1920, 0));

            o.Albedo = col.rgb / 0.20;
            o.Alpha = 1.0;
        }
        ENDCG
    }
    FallBack "Diffuse"
}