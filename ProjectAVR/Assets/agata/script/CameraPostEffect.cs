using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraPostEffect : MonoBehaviour
{

    [SerializeField, Header("ノイズマテリアル")]
    private Material material = null;

    [SerializeField, Header("レンダーテクスチャ生成スクリプト")]
    CreateNoiseRenTex m_noiseRenderTexture = null;
    
    //[SerializeField, Header("ノイズ以外描画レンダーテクスチャ")]
    private RenderTexture baseRenderTex = null;

    private void Start()
    {
        baseRenderTex = m_noiseRenderTexture.renderTexture;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {

        material.SetTexture("_AddRenderTex", baseRenderTex);

        Graphics.Blit(source, destination, material);
        
    }
}
