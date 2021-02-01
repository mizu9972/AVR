using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCenterPos : MonoBehaviour
{
    [Header("計算に使用する数値")]
    public float Num;

    public GetPoint m_getPoint;
    private float m_OldDistance;//前の距離
    private float m_NowDistance;//
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    [ContextMenu("拡大")]
    private void ExpantionCircle()
    {
        //それぞれに値使用して拡大
    }

    [ContextMenu("縮小")]
    private void ShrinkCircle()
    {
        //それぞれに値使用して縮小
    }
}
