using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class fadein : MonoBehaviour
{
    public float fadeDuration; //フェードしていく秒数
    public Color before_color; //フェード前の色
    public Color after_color;  //フェード後の色
    // Start is called before the first frame update
    void Start()
    {
        SteamVR_Fade.Start(before_color, 0f);
        SteamVR_Fade.Start(after_color, fadeDuration);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
