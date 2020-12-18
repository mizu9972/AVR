using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySe : MonoBehaviour
{
    AudioSource MySource = null;

    //複数再生するための機能のためにリストと配列番号用の変数を用意
    [SerializeField, Header("オーディオクリップのリスト")]
    private List<AudioClip> ClipList = new List<AudioClip>();

    [SerializeField, Header("デフォルトで再生するBGMのリスト番号")]
    private int DefaultPlayClip = 0;

    // Start is called before the first frame update
    void Awake()
    {
        MySource = this.GetComponent<AudioSource>();
        MySource.spatialize = true;
        MySource.dopplerLevel = 0f;
        MySource.spatialBlend = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound()//再生するBGMをインスペクタから設定する場合
    {
        MySource.PlayOneShot(ClipList[DefaultPlayClip]);
    }

    public void PlaySound(int value)//再生するBGMをスクリプトを呼び出す側から指定する場合
    {
        MySource.PlayOneShot(ClipList[value]);
    }
}
