using UnityEngine;
using System.Collections;

public class trackingoff : MonoBehaviour
{
    public Vector3 basePos;
    public GameObject camera;
    private selectscene select;
    void Start()
    {
        basePos = transform.position;
        select= camera.GetComponent<selectscene>();
    }

    void Update()
    {
        // VR.InputTracking から hmd の位置を取得
        var trackingPos = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye);

        var scale = transform.localScale;
        trackingPos = new Vector3(
            trackingPos.x * scale.x,
            trackingPos.y * scale.y,
            trackingPos.z * scale.z
        );

        // 回転
        trackingPos = transform.rotation * trackingPos;

        // 固定したい位置から hmd の位置を
        // 差し引いて実質 hmd の移動を無効化する
        basePos = select.endpo;
        transform.position = basePos - trackingPos;

        // 子のカメラの座標がbasePosと同じ値になるかを確認する
        // Debug.Log(transform.GetChild(0).position);
    }
}
