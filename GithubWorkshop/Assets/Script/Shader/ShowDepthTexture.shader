Shader "Custom/ShowDepthTexture"
{
    SubShader
    {
        Cull Off
        ZTest Always
        ZWrite Off

        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
           #pragma vertex vert
           #pragma fragment frag
            
            #include "UnityCG.cginc"

            half _TargetDistance; // 被写体までの距離
            half _TargetThickness; // 被写体の厚み
            half _NearMax; // _Start〜被写体間の最大濃度
            half _FarMin; // 被写体〜_End間の最小濃度

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            sampler2D _CameraDepthTexture;
            float _Start;
            float _End;
            float4 _Color;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            fixed4 frag(v2f i) : SV_Target
            {
                half depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.uv);
                depth = LinearEyeDepth(depth);

                // 被写体の背面までの距離
                half back = _TargetDistance + _TargetThickness;

                // _Start〜被写体間のdepth値を、0〜_NearMaxの値に調整
                half near = lerp(0, _NearMax, (depth - _Start) / (back - _Start));
                // 被写体〜_End間のdepth値を、_FarMin〜1の値に調整
                half far = lerp(_FarMin, 1, (depth - back) / (_End - back));
                // この位置の深度がbackより前か後ろかで反映する値を仕分ける
                depth = near * clamp(sign(depth - back), 0, 1) + far * clamp(sign(back - depth), 0, 1);

                return depth * _Color;
            }
            ENDCG
        }
    }
}