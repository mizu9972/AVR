using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    protected bool m_OnceFlag = false;//1回限定のイベントのアクティブ状態
    protected bool m_NowEventFlag = false;//イベントのアクティブ状態
    [SerializeField, Header("イベントネーム")]
    protected string m_EventName = null;

    #region Getter&Setter
    public bool OnceFlag//1回きりのイベント
    {
        get { return m_OnceFlag; }
        set { m_OnceFlag = value; }
    }
    public bool NowEventFlag//通常イベント用フラグ
    {
        get { return m_NowEventFlag; }
        set { m_NowEventFlag = value; }
    }
    public string EventName//イベントの名前
    {
        get { return m_EventName; }
        set { m_EventName = value; }
    }
    #endregion

    public virtual void StartEvent(){ }//イベント開始処理
    public virtual void Event() { }//イベントのメイン処理(Update)
    public virtual void EndEvent() { }//イベント終了処理
    
}
