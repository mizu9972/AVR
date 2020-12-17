using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class EndrollSystem : MonoBehaviour
{
    [SerializeField,Header("スクロールスピード")]
    private float textScrollSpeed = 30;

    [SerializeField,Header("テキストの制限位置")]
    private float limitPosition = 730f;

    [Header("終了のウェイト")]
    public float WaitTime = 0f;

    [SerializeField,Header("エンドロール終了フラグ")]
    private bool isFinished = false;

    [SerializeField, Header("スキップフラグ")]
    private bool isSkip = false;
    


    private RectTransform MyRectTrans = null;
    
    private Coroutine endRollCoroutine;//　シーン移動用コルーチン

    // Start is called before the first frame update
    void Start()
    {
        MyRectTrans = this.GetComponent<RectTransform>();

        this.UpdateAsObservable().
             Where(_ => isFinished).Take(1).
             Subscribe(_ => endRollCoroutine = StartCoroutine(ScrollEnd()));
    }

    // Update is called once per frame
    void Update()
    {
        //　エンドロールが終了した時
        if (!isFinished)
        {
            //　エンドロール用テキストがリミットを越えるまで動かす
            if (MyRectTrans.localPosition.y <= limitPosition)
            {
                MyRectTrans.localPosition = new Vector3(MyRectTrans.localPosition.x,
                                                   MyRectTrans.localPosition.y + textScrollSpeed * Time.deltaTime,
                                                   MyRectTrans.localPosition.z);
            }
            else
            {
                isFinished = true;
            }
        }

        //TODO デバッグ用終わったら消す
        else
        {
            if (Input.GetKeyDown(KeyCode.Return)/*isSkip*/)
            {
                Debug.Log("終わり");
                OnSkip();
            }
        }
    }

    IEnumerator ScrollEnd()
    {
        yield return new WaitForSeconds(WaitTime);//指定の秒数後にシーン遷移
        if (isSkip)
        {
            yield break;
        }
        Debug.Log("終わり");
        yield return null;
    }

    public void OnSkip()//スキップ時に呼ぶ
    {
        isSkip = true;
    }
}
