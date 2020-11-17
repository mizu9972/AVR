using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;


public class BoardingAnimeManager : MonoBehaviour
{
    [SerializeField, Header("上のオブジェクト")]
    public GameObject UpPanel;

    [HideInInspector]
    public float UpPanelStartTime,UpPanelMoveTime,UpPanelRotateStartTime,UpPanelRotateTime;
    [HideInInspector]
    public Vector3 UpPanelToPosition,UpPanelToRotate;

    //シーケンス
    private Sequence UpPanelSequence;
    // Start is called before the first frame update
    void Start()
    {
        UpPanelSequence = DOTween.Sequence();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("搭乗アニメーション開始")]
    public void StartBoardingAnime()
    {
        UpPanelMove();
    }

    
    private void UpPanelMove()
    {
        UpPanelSequence.Insert(UpPanelStartTime, UpPanel.transform.DOMove(UpPanelToPosition, UpPanelMoveTime).SetRelative(true))
            .AppendInterval(UpPanelRotateStartTime)
            .Append(UpPanel.transform.DORotate(UpPanelToRotate, UpPanelRotateTime).SetRelative(true));
        //UpPanelSequence.Play();
    }
}

#if UNITY_EDITOR

[CustomEditor(typeof(BoardingAnimeManager))]
public class BAMEditor : Editor
{
    BoardingAnimeManager BAM;
    private bool UpPanelisOpen = false;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        BAM = target as BoardingAnimeManager;

        UpPanelisOpen = EditorGUILayout.Foldout(UpPanelisOpen, "上のオブジェクト設定項目");

        if (UpPanelisOpen)
        {
            UpPanelInspecter();
        }
    }

    private void UpPanelInspecter()
    {
        BAM.UpPanelStartTime = EditorGUILayout.FloatField("アニメーション開始待機時間", BAM.UpPanelStartTime);
        BAM.UpPanelToPosition = EditorGUILayout.Vector3Field("移動量", BAM.UpPanelToPosition);
        BAM.UpPanelMoveTime = EditorGUILayout.FloatField("移動時間", BAM.UpPanelMoveTime);
        BAM.UpPanelRotateStartTime = EditorGUILayout.FloatField("回転開始待機時間", BAM.UpPanelRotateStartTime);
        BAM.UpPanelToRotate = EditorGUILayout.Vector3Field("回転量", BAM.UpPanelToRotate);
        BAM.UpPanelRotateTime = EditorGUILayout.FloatField("回転時間", BAM.UpPanelRotateTime);
    }
}

#endif