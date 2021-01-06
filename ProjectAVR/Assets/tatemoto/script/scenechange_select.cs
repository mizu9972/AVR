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
        //a = SceneManager.LoadSceneAsync("Stage1");
        //a.allowSceneActivation = false;
        //b = SceneManager.LoadSceneAsync("stage2");
        //b.allowSceneActivation = false;
        //c = SceneManager.LoadSceneAsync("Stage3");
        //c.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FlagManager.Instance.flags[selectNo1])
        {
            FlagManager.Instance.ResetFlags();
            a = SceneManager.LoadSceneAsync("Stage1");
            //a.allowSceneActivation = true;
            //b=SceneManager.UnloadSceneAsync("stage2");
            //c=SceneManager.UnloadSceneAsync("Stage3");
        }
        if (FlagManager.Instance.flags[selectNo2])
        {
            FlagManager.Instance.ResetFlags();
            a = SceneManager.LoadSceneAsync("stage2");
            //b.allowSceneActivation = true;
            //a=SceneManager.UnloadSceneAsync("Stage1");
            //c=SceneManager.UnloadSceneAsync("Stage3");
        }
        if (FlagManager.Instance.flags[selectNo3])
        {
            FlagManager.Instance.ResetFlags();
            a = SceneManager.LoadSceneAsync("Stage3");
            //c.allowSceneActivation = true;
            //a=SceneManager.UnloadSceneAsync("Stage1");
            //b=SceneManager.UnloadSceneAsync("stage2");
        }
    }
}
