using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{
    //スタート位置オブジェクト
    private GameObject m_StartObj = null;
    public GameObject StartObj
    {
        set { m_StartObj = value; }
    }

    //終了位置オブジェクト
    private GameObject m_EndObj = null;
    public GameObject EndObj
    {
        set { m_EndObj = value; }
    }

    //中間地点オブジェクト
    private GameObject m_CenterObj = null;
    public GameObject CenterObj
    {
        set { m_CenterObj = value; }
    }

    public List<Transform> waypoint;
    int count = 0;


    [SerializeField]
    private float speed = 5f;
    public float Speed
    {
        set { speed = value;}
    }


    [SerializeField]
    private bool m_isMoving = false;
    public bool isMoving
    {
        get { return m_isMoving; }
    }

    [SerializeField]
    private bool m_isActive = false;
    public bool isActive
    {
        get { return m_isActive; }
        set { m_isActive = value; }
    }

    private Transform MyTrans = null;

    void Start()
    {
        MyTrans = this.GetComponent<Transform>();
        
        //先頭と最後尾を設定
        waypoint[0] = m_StartObj.transform;
        waypoint[waypoint.Count - 1] = m_EndObj.transform;

        //中間地点が設定されていればセット(デフォルト設定使用)
        if(m_CenterObj!=null)
        {
            waypoint[1] = m_CenterObj.transform;
        }

        //スタート位置の設定
        MyTrans.position = m_StartObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isActive)//アクティブ状態の時のみ移動関数実行
        {
            MoveMain();
        }
    }

    private void MoveMain()
    {
        Vector3 d = waypoint[count].transform.position - transform.position;
        if (d.magnitude < speed * Time.deltaTime)
        {
            transform.position += d;
            count++;
            if (count >= waypoint.Count)
            {
                m_isMoving = false;
                m_isActive = false;
            }
            return;
        }
        d.Normalize();
        transform.position += d * Time.deltaTime * speed;
        
        m_isMoving = true;
    }
}
