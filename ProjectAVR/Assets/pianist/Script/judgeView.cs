using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judgeView : MonoBehaviour
{
    public bool isInsideCamera
    {
        get;
        private set;
    }

    private void Awake()
    {
        isInsideCamera = false;
    }

    //カメラに写っているか
    private void OnBecameInvisible()
    {
        isInsideCamera = false;
    }

    private void OnBecameVisible()
    {
        isInsideCamera = true;
    }
}
