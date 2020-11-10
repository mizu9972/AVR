using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//追加

public class Sceneload : MonoBehaviour
{
    AsyncOperation a;//AsyncOperation型の変数aを宣言
    void Start()
    {
        //SceneManager.LoadSceneAsync("GameScene")の返り値(型はAsyncOperation)を変数aに代入
        a = SceneManager.LoadSceneAsync("kari");

        //AsyncOperationの中の変数allowSceneActivationをfalseにする
        //これがtrueになるとシーン移動する
        a.allowSceneActivation = false;
    }

    //ボタンに割り当て
    public void Change_Scene_button()
    {
        //trueにしてシーン移動
        a.allowSceneActivation = true;
    }

    public void OnLoadSceneAdditive()
    {
        //SceneBを加算ロード。現在のシーンは残ったままで、シーンBが追加される
        SceneManager.LoadScene("tatemoto", LoadSceneMode.Additive);
    }

    void Update()
    {
        // 左に移動
        if (Input.GetKey(KeyCode.B))
        {
            Change_Scene_button();
        }
        if (Input.GetKey(KeyCode.C))
        {
            OnLoadSceneAdditive();
        }
    }
}
