using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class armscript : MonoBehaviour
{
    // Animator コンポーネント
    private Animator animator;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Input_Sources handType;
    // 設定したフラグの名前
    private const string key_isopen = "Isopen";

    // 初期化メソッド
    void Start()
    {
        // 自分に設定されているAnimatorコンポーネントを習得する
        this.animator = GetComponent<Animator>();
    }

    // 1フレームに1回コールされる
    void Update()
    {
        // 1
        if (grabAction.GetLastStateDown(handType))
        {
            this.animator.SetBool(key_isopen, false);
        }

        // 2
        if (grabAction.GetLastStateUp(handType))
        {
            this.animator.SetBool(key_isopen, true);
        }
        if (grabAction.GetState(handType))
        {

        }

    }
}
