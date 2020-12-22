using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judgeView : MonoBehaviour
{

    //判定するカメラのタグ名
    private const string CAMERATAG_NAME = "MainCamera";

    public bool isInsideCamera
    {
        get;
        private set;
    }

    private void Awake()
    {
        isInsideCamera = false;
    }

    private void Update()
    {
        isInsideCamera = false;
    }

    ////カメラに写っているか
    //private void OnBecameInvisible()
    //{
    //    isInsideCamera = false;
    //}

    //private void OnBecameVisible()
    //{
    //    isInsideCamera = true;
    //}

    private void OnWillRenderObject()
    {
        if(Camera.current.tag == CAMERATAG_NAME)
        {
            isInsideCamera = true;

            Debug.Log("写った");
        }
    }
}
