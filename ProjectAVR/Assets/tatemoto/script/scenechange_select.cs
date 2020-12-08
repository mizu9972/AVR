using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange_select : MonoBehaviour
{
    public int selectNo1;
    public int selectNo2;
    public int selectNo3;
    AsyncOperation a;
    AsyncOperation b;
    AsyncOperation c;
    // Start is called before the first frame update
    void Start()
    {
        a = SceneManager.LoadSceneAsync("Stage1");
        a.allowSceneActivation = false;
        b = SceneManager.LoadSceneAsync("Stage2");
        b.allowSceneActivation = false;
        c = SceneManager.LoadSceneAsync("Stage3");
        c.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FlagManager.Instance.flags[selectNo1])
        {
            a.allowSceneActivation = true;
            b=SceneManager.UnloadSceneAsync("Stage2");
            c=SceneManager.UnloadSceneAsync("Stage3");
        }
        if (FlagManager.Instance.flags[selectNo2])
        {
            b.allowSceneActivation = true;
            a=SceneManager.UnloadSceneAsync("Stage1");
            c=SceneManager.UnloadSceneAsync("Stage3");
        }
        if (FlagManager.Instance.flags[selectNo3])
        {
            c.allowSceneActivation = true;
            a=SceneManager.UnloadSceneAsync("Stage1");
            b=SceneManager.UnloadSceneAsync("Stage2");
        }
    }
}
