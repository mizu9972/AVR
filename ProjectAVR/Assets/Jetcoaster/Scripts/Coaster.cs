using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coaster : MonoBehaviour
{
    public List<Transform> waypoint;
    public int count = 0;

    public float BaseSpeed = 5f;
    public float speed = 5;
    [SerializeField]
    bool isMoving = false;

    [Header("床オブジェクト")]
    public GameObject FloorObj;

    private float g = -9.8f;//重力加速度
    private float h;//高さ
    private float v;//速さ

    public LookTarget lookTarget;
    //float x, y, z;

    //private void Start()
    //{
    //    x = transform.position.x;
    //    y = transform.position.y;
    //    z = transform.position.z;
    //}
    void Awake()
    {
        lookTarget.SetTarget(waypoint[count+1]);//ターゲットセット
        SetSpeed(speed);
    }


    void Update()
    {
        CalcSpeed();
        Vector3 d = waypoint[count].position - transform.position;//自分とターゲットの差分
        if (d.magnitude < speed * Time.deltaTime)
        {
            isMoving = false;
            
            count++;
            transform.position += d;
            if (count >= waypoint.Count)
            {
                count = 0;
            }
            lookTarget.SetTarget(waypoint[count]);//ターゲットセット
            
            return;
        }
        d.Normalize();
        transform.position += d * Time.deltaTime * speed;

        isMoving = true;
    }

    public void SetSpeed(float val)
    {
        speed = val;
        speed = BaseSpeed + speed;//ベースのスピードと減速度で速度を設定
    }

    private void CalcSpeed()
    {
        float sign;//符号

        //現在の高さを求める(床との差)
        h = this.transform.position.y - FloorObj.transform.position.y;

        v = 2 * g * h;//速度計算

        sign = Mathf.Sign(v);//符号取り出し
        v = Mathf.Abs(v);//絶対値取り出し
        v = Mathf.Sqrt(v);//2乗外す
        v = v * sign;//符号を元に戻す

        SetSpeed(v);//求めた値を代入
    }
}
