using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraPostEffect : MonoBehaviour
{


    [SerializeField, Header("ノイズマテリアル")]
    private Material noiseMaterial = null;

    [SerializeField, Header("レンダーテクスチャ生成スクリプト")]
    CreateNoiseRenTex m_noiseRenderTexture = null;

    [SerializeField, Header("ノイズ以外描画レンダーテクスチャ")]
    private RenderTexture baseRenderTex = null;

    private bool _bool = false;
    private void Start()
    {
        baseRenderTex = m_noiseRenderTexture.renderTexture;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        noiseMaterial.SetTexture("_AddRenderTex", baseRenderTex);

        Graphics.Blit(source, destination, noiseMaterial);
        //if (_bool)
        //{


        //    this.GetComponent<Camera>().cullingMask = 1 << 11;
        //    Graphics.Blit(source, destination);
        //    //noiseMaterial.SetTexture("_AddRenderTex", baseRenderTex);


        //}
        //else
        //{

        //    this.GetComponent<Camera>().cullingMask = ~(1 << 11);
        //    Graphics.Blit(source, destination, noiseMaterial);
        //}
        //_bool = !_bool;
    }
}
