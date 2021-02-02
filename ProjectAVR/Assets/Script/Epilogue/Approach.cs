using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;

public class Approach : MonoBehaviour
{
    [Header("デフォルトの設定使用(中間地点1つ)")]
    public bool isUseDefault = true;

    [Header("スタート位置オブジェクト")]
    public GetPoint m_Start = null;

    [Header("終了位置オブジェクト")]
    public GetPoint m_End = null;

    [Header("中間オブジェクトまとめ")]
    public GetPoint m_Center = null;

    [Header("手オブジェクト")]
    public List<GameObject> m_Hands = new List<GameObject>();
    [SerializeField]
    private List<MoveHand> m_HandScripts = new List<MoveHand>();

    [SerializeField,Header("リスト用カウント")]
    private int m_Count = 0;

    [Header("手を動かす順番")]
    public int[] m_MoveTable = new int[10];

    [Header("手を動かす感覚(秒)")]
    public double m_Interval = 1;

    [Header("手を動かすスピード")]
    public float HandSpeed = 5f;

    private bool m_isStarted = false;//全ての手が動き出し終了したかを判定するため

    [SerializeField]
    private bool m_isStart = false;//スタート管理フラグ

    [SerializeField]
    private bool m_isFinished = false;//全ての手の動きが終了でtrue
    public bool isStart
    {
        set { m_isStart = value;}
        get { return m_isStart; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        int _cnt = 0;
        foreach(var Hand in m_Hands)//全ての手オブジェクトにスタートとエンドをセット
        {
            m_HandScripts.Add(Hand.GetComponent<MoveHand>());//更新処理用にスクリプトの取得
            Hand.GetComponent<MoveHand>().StartObj = m_Start.GetPointObj(_cnt);

            Hand.GetComponent<MoveHand>().EndObj = m_End.GetPointObj(_cnt);

            if (isUseDefault)//デフォルト設定使用の場合のみ手の中間地点とスピードを自動設定
            {
                Hand.GetComponent<MoveHand>().CenterObj = m_Center.GetPointObj(_cnt);
                Hand.GetComponent<MoveHand>().Speed = HandSpeed;
            }
            _cnt++;
        }
        //m_isStartがtrueになれば手の動きスタート
        this.UpdateAsObservable().
             Where(_=>m_isStart).
             Take(1).
             Subscribe(_ => PlayMoveStart());
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isStarted)
        {
            CheckAllHand();
        }
    }

    private void PlayMoveStart()
    {
        m_isFinished = false;

        MoveStart(m_MoveTable[m_Count]);//指定要素の手を動かし始める
        m_Count++;//次の変数へ
        if(m_Count >= m_Hands.Count)//リストの要素数以上のカウントになったら終了
        {
            m_isStarted = true;
        }

        //1発のみの腕の動きをスタート
        Observable.Timer(System.TimeSpan.FromSeconds(m_Interval)).
                   Subscribe(x => this.UpdateAsObservable().
                   Where(_=> m_isStarted == false).
                   Take(1).
                   Subscribe(_ => PlayMoveStart()));
        
    }

    private void MoveStart(int value)//HandのActiveをtrueに
    {
        m_Hands[value].GetComponent<MoveHand>().isActive = true;
    }

    private void CheckAllHand()//動いている物があるかチェック
    {
        foreach (var Hand in m_HandScripts)
        {
            //動いていなければ次のオブジェクトをチェック
            if(Hand.isMoving == false)
            {
                continue;
            }
            //動いているものがあればチェック終了
            else
            {
                return;
            }
        }
        m_isFinished = true;
    }
}
