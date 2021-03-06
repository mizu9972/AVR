﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class doorscript : MonoBehaviour
{
    // Animator コンポーネント
    private Animator animator;
    // 設定したフラグの名前
    private const string open = "open";
    private const string close = "close";
    public int selectNo;
    public int selectNo1;
    // 初期化メソッド
    void Start()
    {
        // 自分に設定されているAnimatorコンポーネントを習得する
        this.animator = GetComponent<Animator>();
    }

    // 1フレームに1回コールされる
    void Update()
    {

        if (FlagManager.Instance.flags[selectNo] && FlagManager.Instance.flags[20])
        {
            FlagManager.Instance.flags[120] = true;
            this.animator.SetBool(open, true);
            FlagManager.Instance.flags[selectNo1] = true;
            //this.animator.SetBool(close, false);
        }
        else
        {
        }
   

    }
}
