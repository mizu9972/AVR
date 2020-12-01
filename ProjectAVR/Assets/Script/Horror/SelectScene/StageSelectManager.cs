using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    private float time = 0f;
    private bool once = false;
    
    // Update is called once per frame
    void Update()
    {
        // とりあえず3秒以上行ったら他のシーンアンロード
        if (time < 3f)
        {
            time += Time.deltaTime;
        }
        else{
            SceneOrganization();
        }
    }

    // 現在のシーン以外を破棄する
    void SceneOrganization()
    {
        // 
        if (once) return;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);

            // 現在のシーンと合わせたら終わり
            if (scene.name != SceneManager.GetActiveScene().name)
            {
                var asyncOperation = SceneManager.UnloadSceneAsync(scene);
            }
        }
        once = true;
    }
}
