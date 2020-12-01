Shader "Custom/VertexColorOutline" {
	Properties{
		_OutlineWidth("OutlineWith", Range(0.001, 1)) = 0.003
		[MaterialToggle] _UseVertexColor("Use VertexColor", Float) = 1
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200
			Pass {
		// 頂点カラーを使ったアウトラインシェーダ
		Cull Front
		ZWrite On
		CGPROGRAM
		#include "UnityCG.cginc"
		#pragma vertex vert
		#pragma fragment frag
		float _OutlineWidth;
		float _UseVertexColor;
		struct appdata {
			float4 color: COLOR;
			float4 vertex: POSITION;
			float4 normal: NORMAL;
		};
		struct v2f {
			float4 pos: SV_POSITION;
			float4 color: COLOR;
		};

		v2f vert(appdata v) {
			v2f o;
			if (_UseVertexColor) {
				float4 color = v.color;
				// colorが0 ~ 1なので color = norm *.5 + .5されている
				// これを-1 ~ 1になおす
				color.xyz -= 0.5;
				color.xyz *= 2;
				// 書き出し時にUnityの座標系に直しているが、右手座標系から左手座標系になっていないのでxだけ補正する
				color.x *= -1;
				float4 normal = float4(normalize(color).xyz,0);
				float4 add = normal * _OutlineWidth;
				o.pos = UnityObjectToClipPos(v.vertex + add);
			}
else {
 o.pos = UnityObjectToClipPos(v.vertex + normalize(v.normal) * _OutlineWidth);
}
o.color = v.color;
return o;
}

fixed4 frag(v2f i) : SV_Target {
	return i.color;
}
ENDCG
}
	}
}
