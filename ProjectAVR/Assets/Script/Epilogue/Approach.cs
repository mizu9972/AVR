using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;

public class Approach : MonoBehaviour
{
    [Header("スタート位置オブジェクト")]
    public GameObject m_Start = null;

    [Header("終了位置オブジェクト")]
    public GameObject m_End = null;

    [Header("手オブジェクト")]
    public List<GameObject> m_Hands = new List<GameObject>();

    [SerializeField,Header("リスト用カウント")]
    private int m_Count = 0;

    [Header("手を動かす順番")]
    public int[] m_MoveTable = new int[10];

    [Header("手を動かす感覚(秒)")]
    public double m_Interval = 1;

    private bool m_isEnd = false;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(var Hand in m_Hands)//全ての手オブジェクトにスタートとエンドをセット
        {
            Hand.GetComponent<MoveHand>().StartObj = m_Start;
            Hand.GetComponent<MoveHand>().EndObj = m_End;
        }
        //1発のみの腕の動きをスタート
        this.UpdateAsObservable().
             Take(1).
             Subscribe(_ => PlayMoveStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayMoveStart()
    {
        MoveStart(m_MoveTable[m_Count]);//指定要素の手を動かし始める
        m_Count++;//次の変数へ
        if(m_Count >= m_Hands.Count)//リストの要素数以上のカウントになったら終了
        {
            m_isEnd = true;
        }

        //1発のみの腕の動きをスタート
        Observable.Timer(System.TimeSpan.FromSeconds(m_Interval)).
                   Subscribe(x => this.UpdateAsObservable().
                   Where(_=>m_isEnd==false).
                   Take(1).
                   Subscribe(_ => PlayMoveStart()));
        
    }

    private void MoveStart(int value)//HandのActiveをtrueに
    {
        m_Hands[value].GetComponent<MoveHand>().isActive = true;
    }

    
}
