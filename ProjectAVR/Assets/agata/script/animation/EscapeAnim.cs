using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EscapeAnim : MonoBehaviour
{
    [SerializeField, Header("")]
    private Animator animator = null;

    [ContextMenu("アニメーション開始")]
    public void StartEscape()
    {
        animator.SetTrigger("EscapeStart");
    }
    //[ContextMenu("アニメーション開始")]
    //public void StartAnim()
    //{
    //    if(animator == null)
    //    {
    //        return;
    //    }

    //    animator.Play("Entry");
    //}
}

#if UNITY_EDITOR
[CustomEditor(typeof(EscapeAnim))]
class EscapeAnimEditor : Editor
{
    EscapeAnim m_EscapeAnim;

    public override void OnInspectorGUI()
    {
        m_EscapeAnim = target as EscapeAnim;
        serializedObject.Update();
        base.OnInspectorGUI();

        if (GUILayout.Button("アニメーション開始"))
        {
            m_EscapeAnim.StartEscape();
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif