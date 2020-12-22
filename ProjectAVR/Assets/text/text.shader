Shader "Custom/text"
{
    
Properties
    {
        _MainTex ("Font Texture", 2D) = "white" {}
	_Color ("Text Color", Color) = (1,1,1,1)
	_Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags{"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	Lighting Off Cull Off ZWrite Off Fog{Mode Off}
	Blend SrcAlpha OneMinusSrcAlpha
	Pass {
		Color [_Color]
		SetTexture [_MainTex]{
		combine primary,texture*primary
    		}
	}
     }
}
