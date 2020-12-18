using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianistAnimation : MonoBehaviour
{
    [SerializeField, Header("ピアニストのアニメーター")]
    private Animator PianistAnim = null;

    //椅子で攻撃してくるアニメーション起動
    public void AttackwithChair()
    {
        if(PianistAnim != null)
        {
            PianistAnim.SetTrigger("Attack");
        }
        else
        {
            Debug.LogAssertion("ピアニストのアニメーターが設定されていません");
        }
    }
}
