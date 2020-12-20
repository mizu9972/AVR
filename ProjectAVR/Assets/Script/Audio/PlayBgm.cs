﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBgm : MonoBehaviour
{
    AudioSource MySource = null;

    //複数再生するための機能のためにリストと配列番号用の変数を用意
    [SerializeField,Header("オーディオクリップのリスト")]
    private List<AudioClip> ClipList = new List<AudioClip>();
    
    [SerializeField, Header("デフォルトで再生するBGMのリスト番号")]
    private int DefaultPlayClip = 0;

    [SerializeField, Header("立体音響を適用するか(trueで)")]
    private bool isUse3DSound = false;
    // Start is called before the first frame update
    void Awake()
    {
        MySource = this.GetComponent<AudioSource>();
        if(isUse3DSound)//3DAudio
        {
            MySource.spatialize = true;
            MySource.dopplerLevel = 0f;
            MySource.spatialBlend = 1f;
        }
        else//2DAudio
        {
            MySource.spatialize = false;
            MySource.spatialBlend = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBgm()//再生するBGMをインスペクタから設定する場合
    {
        MySource.clip = ClipList[DefaultPlayClip];//デフォルトの番号のBGMを再生
        MySource.loop = true;//ループ再生
        MySource.Play();//再生
    }

    public void StartBgm(int value)//再生するBGMをスクリプトを呼び出す側から指定する場合
    {
        MySource.clip = ClipList[value];//実行する側から指定
        MySource.loop = true;//ループ再生
        MySource.Play();//再生
    }
}