using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System;

using UniRx;

public class WaveFade : MonoBehaviour
{
    [SerializeField, Header("WaveFadeマテリアル")]
    private Material WaveFadeMat = null;

    [SerializeField, Header("フェード速度")]
    private float FadeSpeed = 1.0f;

    [SerializeField, Header("横方向移動速度")]
    private float HorizonMoveSpeed = 1.0f;

    [SerializeField, Header("開始UV座標")]
    private Vector2 StartUV = Vector2.zero;

    private bool isFade = false;


    ReactiveProperty<float> m_FunctionTimeCount = new ReactiveProperty<float>();
    Action<RenderTexture, RenderTexture> m_FadeFunction;//処理切り替え

    // Start is called before the first frame update
    void Start()
    {

        m_FadeFunction = NoFunction;

        //フェード終了通知
        m_FunctionTimeCount.Select(x => x * 0.01f >= 1.0).DistinctUntilChanged().Where(x => x).Subscribe(x =>
        {
            OnEndFadeInOut();
        });
    }

    //描画時処理
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        m_FadeFunction.Invoke(source, destination);
    }

    //フェード処理
    //なにもしない
    private void NoFunction(RenderTexture source,RenderTexture destination)
    {
        Graphics.Blit(source, destination);
    }

    //フェード中
    private void FadeFunction(RenderTexture source,RenderTexture destination)
    {
        WaveFadeMat.SetFloat("_TimeCount", m_FunctionTimeCount.Value);
        Graphics.Blit(source, destination, WaveFadeMat);
        m_FunctionTimeCount.Value += FadeSpeed;
    }


    [ContextMenu("フェード開始")]
    public void StartFade()
    {
        WaveFadeMat.SetFloat("_isActive", 1);
        WaveFadeMat.SetFloat("_PreUV_X", StartUV.x);
        WaveFadeMat.SetFloat("_PreUV_Y", StartUV.y);
        WaveFadeMat.SetFloat("_HorizonMoveSpeed", HorizonMoveSpeed);

        m_FunctionTimeCount.Value = 0;

        m_FadeFunction = FadeFunction;

        isFade = true;
    }

    //フェード終了時処理
    public void OnEndFadeInOut()
    {
        isFade = false;//フェード終了
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(WaveFade))]
class WaveFadeEditor : Editor
{
    private WaveFade m_WF;
    public override void OnInspectorGUI()
    {
        m_WF = target as WaveFade;
        base.OnInspectorGUI();

        serializedObject.Update();


        if (GUILayout.Button("フェード開始"))
        {
            m_WF.StartFade();
        }

    }
}
#endif