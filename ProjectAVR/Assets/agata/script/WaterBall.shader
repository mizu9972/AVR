Shader "Unlit/WaterBall"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
	_DistortionTex("Distortion Texture(RG)",2D) = "grey"{}
	_DistortionPower("Distortion Power",Range(0,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent"}
        LOD 100

		Cull Back
		ZWrite On
		ZTest LEqual
		ColorMask RGB

		GrabPass{"_GrabPassTexture"}


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
				half4 grabPos : TEXCOORD1;
            };

			//テクスチャサンプラ
            sampler2D _MainTex;
			sampler2D _DistortionTex;
			sampler2D _GrabPassTexture;
			//tiling offset
            float4 _MainTex_ST;
			half4 _DistortionTex_ST;

			half _DistortionPower;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.grabPos = ComputeGrabScreenPos(o.vertex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

			half2 uv = half2(i.grabPos.x / i.grabPos.w, i.grabPos.y / i.grabPos.w);

			half2 distortion = tex2D(_DistortionTex, i.uv + _Time.z * 0.1f).rg - 0.5;
			distortion *= _DistortionPower;

			uv = uv + distortion;

			return tex2D(_GrabPassTexture, uv);
                // apply fog
                //UNITY_APPLY_FOG(i.fogCoord, col);
                //return col;
            }
            ENDCG
        }
    }
}
