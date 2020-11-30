// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/NoiseDirt"
{
    Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_AddNoiseTex("加算テクスチャ",2D) = "black" {}
		_NoiseValue("ノイズの強さ",Range(0,1)) = 0
			_BaseColorStrength("ノイズでの加算色の強度",Float) = 0.85 
		_Offset("描画オフセット",Vector) = (0,0,0,0)
		_RGBNoise("画面全体のノイズ",Range(0,1)) = 0
		//_SinNoise_Width("NoiseWidth",Float) = 1
		//_SinNoise_Scale("NoiseScale",Float) = 1
		//_SinNoise_Offset("NoiseOffset",Float) = 1
	}
    SubShader
    {
        Tags { "RenderType"="Opaque" }

		GrabPass{
			"_GrabTex"
		}
        LOD 100

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
				float4 grabPos:TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

			float _BaseColorStrength;

			sampler2D _AddNoiseTex;
			float4 _AddNoiseTex_ST;

			sampler2D _AddRenderTex;
			float4 _AddRenderTex_ST;

			sampler2D _GrabTex;

			float _NoiseValue;
			float2 _Offset;
			//ノイズ設定
			float _RGBNoise;
			float _SinNoise_Width = 1;
			float _SinNoise_Scale = 1;
			float _SinNoise_Offset = 1;
			
			float randf(float2 col) {
				return frac(sin(dot(col.xy, float2(12.9898, 78.233))) * 43758.5453);
			}
			float2 modf(float2 a, float2 b) {
				return a - floor(a / b) * b;
			}

            v2f vert (appdata v)
            {
                v2f o;
                //o.vertex = UnityObjectToClipPos(v.vertex);
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
			
			half4 grabCol = tex2Dproj(_GrabTex, i.grabPos);
			float4 outcol;
			float4 baseCol;
			float4 noNoiseCol;
			float2 uv = i.uv;

			baseCol = tex2D(_MainTex, i.uv);
			noNoiseCol = tex2D(_AddRenderTex, i.uv);
			//ノイズのオフセット反映
			uv.x += sin(uv.y * _SinNoise_Width + _SinNoise_Offset) * _SinNoise_Scale;
			uv += _Offset;
			uv.x += (randf(floor(uv.y * 500) + _Time.y) - 0.5) * _NoiseValue;
			uv = modf(uv, 1);

			fixed4 noiseCol = tex2D(_AddNoiseTex, randf(uv));

			//RGBをずらす
			outcol.r = tex2D(_MainTex, uv).r;
			outcol.g = tex2D(_MainTex, uv - float2(0.002, 0)).g;
			outcol.b = tex2D(_MainTex, uv - float2(0.004, 0)).b;

			//ノイズ生成
			if (randf((randf(floor(uv.y * 500) + _Time.y) - 0.5) + _Time.y) < _RGBNoise) {
				outcol.r = randf(uv - 0.5 + float2(123 + _Time.y, 0));
				outcol.g = randf(uv - 0.5 + float2(123 + _Time.y, 1));
				outcol.b = randf(uv - 0.5 + float2(123 + _Time.y, 2));
			}

			//描画する色を設定
			float floorX = fmod(i.uv.x * _ScreenParams.x / 3, 1);
			outcol.r *= floorX > 0.3333;
			outcol.g *= floorX < 0.3333 || floorX > 0.6666;
			outcol.b *= floorX < 0.6666;

			//ノイズの位置確認
			noiseCol = noiseCol * sign(outcol);

			outcol += noiseCol * _BaseColorStrength;
			// apply fog
                UNITY_APPLY_FOG(i.fogCoord, outcol);
				return float4(noNoiseCol + baseCol +  outcol.rgb, 1);
            }
            ENDCG
        }
    }
}
