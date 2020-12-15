Shader "Unlit/WaveFade"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_TransitionTex("参考画像",2D) = "white"{}

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue" = "Trasparent+1" }
        LOD 100

		Blend SrcAlpha OneMinusSrcAlpha
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
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

			//参考画像
			sampler2D _TransitionTex;
			float4 _TransitionTex_ST;

			uniform float _PreUV_X;//予めずらしておく座標
			uniform float _PreUV_Y;
			uniform float _TimeCount;//経過時間
			uniform float _isActive;//有効化どうか

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

			float2 texUv = float2(0, 0);
			texUv.x = i.uv.x;
			texUv.y = smoothstep(0.0,1.0,i.uv.y - _TimeCount * 0.01 * _isActive + _PreUV_Y);
			
				fixed4 TexCol = tex2D(_TransitionTex, texUv);
                
				col = col * TexCol;

				// apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
