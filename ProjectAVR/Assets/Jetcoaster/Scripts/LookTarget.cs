using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour
{
    [Header("補間スピード")]
    public float Speed = 0.1f;

    private Transform NowTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = NowTarget.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(NowTarget)
        {
            // ターゲット方向のベクトルを取得
            Vector3 relativePos = NowTarget.position - this.transform.position;
            // 方向を、回転情報に変換
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            // 現在の回転情報と、ターゲット方向の回転情報を補完する
            transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Speed);
        }
    }

    public void SetTarget(Transform target)
    {
        NowTarget = target;
    }
}
