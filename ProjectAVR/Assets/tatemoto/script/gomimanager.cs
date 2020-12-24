using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gomimanager : MonoBehaviour
{
    public float x;
    public bool scenechan1;
    public bool scenechan2;
    public bool scenechan3;
    public bool scenechan4;
    AsyncOperation a;

    public static gomimanager gomigomi;


    void Awake()
    {
        //　スクリプトが設定されていなければゲームオブジェクトを残しつつスクリプトを設定
        if (gomigomi == null)
        {
            DontDestroyOnLoad(gameObject);
            gomigomi = this;
            //　既にGameStartスクリプトがあればこのシーンの同じゲームオブジェクトを削除
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (scenechan1)
        {
            a = SceneManager.LoadSceneAsync("Stage1");
        }
        if (scenechan2)
        {
            a = SceneManager.LoadSceneAsync("Stage2");
        }
        if (scenechan3)
        {
            a = SceneManager.LoadSceneAsync("Stage3");
        }
        if (scenechan4)
        {
            a = SceneManager.LoadSceneAsync("select");
            Destroy(gameObject);
        }
    }
}
