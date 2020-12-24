using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using UnityEngine.SceneManagement;
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

    private float UseFadeValue = 1f;

    [SerializeField, Header("エンドの文字")]
    private Text EndText = null;

    public EndrollBGM endrollBGM = null;

    [SerializeField]
    private float FadeSpeed = 0.01f;

    private bool isFadeEnd = false;

    private bool isFadeStart = false;
    // Start is called before the first frame update
    void Start()
    {
        MyRectTrans = this.GetComponent<RectTransform>();

        this.UpdateAsObservable().
             Where(_ => isFinished).Take(1).
             Subscribe(_ => endRollCoroutine = StartCoroutine(ScrollEnd()));

        this.UpdateAsObservable().
            Where(_ => isFadeEnd).Take(1).
            Subscribe(_ => OnSkip());

        this.UpdateAsObservable().
            Where(_ => isSkip).Take(1).
            Subscribe(_ => SceneManager.LoadScene("Title"));

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

        //TODO ＶＲ用の入力検知に変更
        else
        {
            if (!isFadeStart&&Input.GetKeyDown(KeyCode.Return))
            {
                //オーディオと文字のフェード開始
                isFadeStart = true;
            }

            if(isFadeStart&&!isFadeEnd)
            {
                //フェード中
                FadeWordandAudio();
            }
        }
    }

    IEnumerator ScrollEnd()
    {
        yield return new WaitForSeconds(WaitTime);//指定の秒数後にシーン遷移
        //オーディオと文字のフェード開始
        isFadeStart = true;
        yield return null;
    }

    public void OnSkip()//スキップ時に呼ぶ
    {
        isSkip = true;
    }

    public void FadeWordandAudio()
    {
        if(UseFadeValue<=0f)
        {
            isFadeEnd = true;
        }
        else
        {
            UseFadeValue -= FadeSpeed;
            EndText.color = new Color(EndText.color.r,EndText.color.g,EndText.color.b,UseFadeValue);
            endrollBGM.SetVolume(UseFadeValue);
        }
    }
}
