using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRenderCamera : MonoBehaviour
{

    [SerializeField, Header("ノイズ合成レンダーテクスチャ")]
    private RenderTexture sourceRenderTex;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(sourceRenderTex, destination);
    }
}
