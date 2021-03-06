﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eptext : MonoBehaviour
{
    [TextArea(1, 20)]
    public string[] sentences; // 文章を格納する
    [SerializeField] TextMesh uiText;   // uiTextへの参照

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharDisplay = 0.05f;   // 1文字の表示にかける時間

    public int currentSentenceNum = 0; //現在表示している文章番号
    private string currentSentence = string.Empty;  // 現在の文字列
    private float timeUntilDisplay = 0;     // 表示にかかる時間
    private float timeBeganDisplay = 1;         // 文字列の表示を開始した時間
    public int lastUpdateCharCount = -1;       // 表示中の文字数
    public GameObject lplp;
    private Approach ooo;
    public GameObject lll;


    void Start()
    {
        SetNextSentence();
        ooo = lplp.GetComponent<Approach>();
    }


    public void TextUpdate(bool _IsPush)
    {
        // 文章の表示完了 / 未完了
        if (IsDisplayComplete())
        {
            //最後の文章ではない & ボタンが押された
            if (currentSentenceNum < sentences.Length && _IsPush)
            {
                SetNextSentence();
            }
            else if (currentSentenceNum >= sentences.Length)
            {
                currentSentenceNum = 0;
                FlagManager.Instance.flags[100] = true;
                ooo.isStart=true;
                FlagManager.Instance.flags[127] = false;
                lll.SetActive(false);
            }
        }
        else
        {
            if (_IsPush)
            {
                timeUntilDisplay = 0; //※1
            }
        }

        //表示される文字数を計算
        int displayCharCount = (int)(Mathf.Clamp01((Time.time - timeBeganDisplay) / timeUntilDisplay) * currentSentence.Length);
        //表示される文字数が表示している文字数と違う
        if (displayCharCount != lastUpdateCharCount)
        {
            uiText.text = currentSentence.Substring(0, displayCharCount);
            //表示している文字数の更新
            lastUpdateCharCount = displayCharCount;
        }
    }

    // 次の文章をセットする
    void SetNextSentence()
    {
        currentSentence = sentences[currentSentenceNum];
        timeUntilDisplay = currentSentence.Length * intervalForCharDisplay;
        timeBeganDisplay = Time.time;
        currentSentenceNum++;
        lastUpdateCharCount = 0;
    }

    bool IsDisplayComplete()
    {
        return Time.time > timeBeganDisplay + timeUntilDisplay; //※2
    }
}
