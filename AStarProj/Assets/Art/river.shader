Shader "BaaWolf/URPUnlitShaderTransparent"
{
    // The properties block of the Unity shader now contains a color property.
    Properties
    {
        _MainColor("Main Color", Color) = (1, 1, 1, 1) // Default to white.
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Transparent" "Queue" = "Transparent" "RenderPipeline" = "UniversalRenderPipeline"
        }

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha

            Offset -10, 1

            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

        // Introducing the color variable to the HLSL block.
        half4 _MainColor;

        struct Attributes
        {
            float4 positionOS : POSITION;
        };

        struct Varyings
        {
            float4 positionHCS : SV_POSITION;
        };

        Varyings vert(Attributes IN)
        {
            Varyings OUT;
            OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
            return OUT;
        }

        // Use the color property in the fragment shader.
        half4 frag() : SV_Target
        {
            return _MainColor;
        }

        ENDHLSL
    }
    }
}
