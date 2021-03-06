﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
public class BgmSelect : MonoBehaviour
{
    public enum AudioType
    {
        NONE,
        BGM_GAMEMAIN,
        BGM_TITLE,
        BGM_STAGESELECT
    };
    [Header("BGMタイプ")]
    public AudioType audioType;

    private string keyName = null;//再生するBGMのキー名
    [Header("ボリューム")]
    public float Vol = 1f;
    // Start is called before the first frame update
    void Start()
    {
        this.UpdateAsObservable().Take(1).Subscribe(_ => BGMInit());
    }

    private void Update()
    {
        //if(!GameManager.Instance.GetisStage())
        //{
        //    AudioManager.Instance.SetBgmVolume(Vol);
        //}
    }

    private void BGMInit()
    {
        keyName = audioType.ToString();//定義情報名を文字情報に変換
        Debug.Log("再生するBGMのキー名:" + keyName);

        if (audioType != AudioType.NONE)//そのシーンにBGMの割り当てがあれば再生
        {
            
        }
        else//BGMの割り当てがなければBGM停止
        {
            AudioManager.Instance.StopBGM();
        }
    }
}
