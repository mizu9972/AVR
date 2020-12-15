using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{
    [Header("スピード")]
    public float m_Speed = 0.0001f;
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

    [SerializeField, Header("アクティブ状態")]
    private bool m_isActive = false;
    public bool isActive
    {
        set { m_isActive = value; }
        get { return m_isActive; }
    }

    private Transform MyTrans = null;
    private float m_NowTime = 0f;
    private float m_Zpos = 0f;
    // Start is called before the first frame update
    void Start()
    {
        MyTrans = this.GetComponent<Transform>();

        if(m_StartObj)//スタート位置にオブジェクトをセット(Zのみ)
        { 
            MyTrans.position = new Vector3(MyTrans.position.x, 
                                           MyTrans.position.y, 
                                           m_StartObj.transform.position.z);
            m_Zpos = MyTrans.position.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isActive)//アクティブ状態の時のみ移動関数実行
        {
            MoveMain();
        }
    }

    private void MoveMain()
    {
        m_NowTime += m_Speed;
        //Z座標の更新
        m_Zpos = Mathf.Lerp(m_StartObj.transform.position.z,
                            m_EndObj.transform.position.z, 
                            m_NowTime);

        MyTrans.position = new Vector3(MyTrans.position.x, MyTrans.position.y, m_Zpos);

        //エンドポイントに到着したらisActiveをfalseに

    }
}
