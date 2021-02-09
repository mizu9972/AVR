using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class fadeout : MonoBehaviour
{
    public float fadeDuration; //フェードしていく秒数
    public Color before_color; //フェード前の色
    public Color after_color;  //フェード後の色
    public int selectNo1;
    public string scenename;
    private int cnt = 0;
    private bool fadefa = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (FlagManager.Instance.flags[selectNo1])
        {
            fadefa = true;
        }
        if (fadefa)
        {
            if (cnt == 0)
            {
                SteamVR_Fade.Start(before_color, 0f);
                SteamVR_Fade.Start(after_color, fadeDuration);
            }
        
            cnt++;
            if (cnt >= 300)
            {
                FlagManager.Instance.ResetFlags();
                SceneManager.LoadScene(scenename);
            }
        }
    }
}
