using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class CreateNoiseRenTex : MonoBehaviour
{
    [SerializeField, Header("カメラ")]
    private Camera VRCamera;

    //両目のレンダーテクスチャ
    RenderTexture m_LeftEyeRenderTexture;
    RenderTexture m_RightEyeRenderTexture;

    [SerializeField]
    public RenderTexture renderTexture;

    private Camera m_camera = null;

    private Vector3 m_EyeOffset;
    private void Awake()
    {
        //m_camera = this.GetComponent<Camera>();
        //m_camera.enabled = false;

        ////左右の目のレンダーテクスチャ作成
        //m_LeftEyeRenderTexture = new RenderTexture((int)SteamVR.instance.sceneWidth, (int)SteamVR.instance.sceneHeight, 24);
        //m_RightEyeRenderTexture = new RenderTexture((int)SteamVR.instance.sceneWidth, (int)SteamVR.instance.sceneHeight, 24);

        ////アンチエイリアス
        //int AntiAreas = QualitySettings.antiAliasing == 0 ? 1 : QualitySettings.antiAliasing;
        //m_LeftEyeRenderTexture.antiAliasing = AntiAreas;
        //m_RightEyeRenderTexture.antiAliasing = AntiAreas;

        var asad = this.GetComponent<Collider>();
    }

    //public void RenderMaterial(Material material)
    //{
    //    //左目
    //    m_EyeOffset = SteamVR.instance.eyes[0].pos;
    //    m_EyeOffset.z = 0.0f;

    //    //プロジェクションマッピングを取得
    //    Valve.VR.HmdMatrix44_t leftMatrix = SteamVR.instance.hmd.GetProjectionMatrix(Valve.VR.EVREye.Eye_Left,VRCamera.nearClipPlane,VRCamera.farClipPlane,)

    //}
}
