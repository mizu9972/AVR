using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraPostEffect : MonoBehaviour
{

    [SerializeField, Header("ノイズマテリアル")]
    private Material material = null;

    [SerializeField, Header("ノイズ以外描画レンダーテクスチャ")]
    private RenderTexture baseRenderTex = null;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {

        material.SetTexture("_AddRenderTex", baseRenderTex);

        Graphics.Blit(source, destination, material);
        
    }
}
