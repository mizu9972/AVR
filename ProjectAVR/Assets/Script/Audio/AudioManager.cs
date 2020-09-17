using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [Header("BGM用のメインオーディオソース")]
    public AudioSource BGM_audioSource;


    [Header("SE用のオーディオソース")]
    public AudioSource SE_audioSource;

    private float SE_LoopVol = 1.0f;//ループSE用のボリューム

    [SerializeField, Header("BGMの音量")]
    [Range(0, 1)] private float BgmVol = 1.0f;

    [SerializeField, Header("SEの音量")]
    [Range(0, 1)] private float SeVol = 1.0f;

    private Dictionary<string, AudioClip> ClipList ;

    private uint arraySize;//オーディオリストのサイズ

    private AudioFade audioFade;
    private bool isFadeOut = false;
    //private int Channel = 4;
    private void Start()
    {
        audioFade = this.GetComponent<AudioFade>();
        arraySize = this.GetComponent<AudioList>().GetArraySize();//要素数を取得

        //オーディオリストを取得
        ClipList = new Dictionary<string, AudioClip>(this.GetComponent<AudioList>().AudioDict);
    }

    void Update()
    {
        if(isFadeOut)//BGMのフェードがあれば実行
        {
            if(audioFade.AudioFadeOut())
            {
                FadeEndFunc();
            }
        }

        BGM_audioSource.volume = BgmVol;//BGMの音量設定
        

        SE_audioSource.volume = SeVol;//SEの音量設定


    }

    //メインBGM再生関数
    public void PlayMainBGM(string KeyName,bool isLoop)//再生したい音源のキー名とループするかを引数で指定(trueでループ)
    {
        BGM_audioSource.loop = isLoop;//ループするかを設定
        BGM_audioSource.clip = ClipList[KeyName];//指定したキー名のオーディオクリップをセット
        BGM_audioSource.Play();//指定したクリップを再生
    }


    //SE再生
    public void PlaySE(string KeyName)
    {
        SE_audioSource.PlayOneShot(ClipList[KeyName]);
    }

    public void SetSeVolume(float vol)
    {
        SeVol = vol;//0~1の範囲で音量をセット
    }

    public void SetBgmVolume(float vol)
    {
        BgmVol = vol;
        //BgmVol= Mathf.Clamp(BgmVol, 0f, 1.0f);//0~1の範囲で音量をセット
    }

    public float GetSeVolume()
    {
        return SeVol;
    }

    public float GetBgmVolume()
    {
        return BgmVol;
    }


    public void StopBGM()
    {
        BGM_audioSource.clip = null;
    }

    public AudioClip GetDictionalyClip(string keyname)//オーディオリストの取得
    {
        return ClipList[keyname];
    }

    public void AudioFadeOutStart()//オーディオのフェードアウト開始
    {
        isFadeOut = true;
    }

    public void FadeEndFunc()//フェードが終了した後に通る
    {
        isFadeOut = false;
        BgmVol = 1.0f;
    }
}
