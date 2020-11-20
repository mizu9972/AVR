using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeAnim : MonoBehaviour
{
    [SerializeField, Header("")]
    private Animator animator = null;

    [ContextMenu("アニメーション開始")]
    public void StartAnim()
    {
        if(animator == null)
        {
            return;
        }

        animator.Play("Entry");
    }
}
