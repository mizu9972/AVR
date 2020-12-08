using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Approach : MonoBehaviour
{
    [Header("スタート位置オブジェクト")]
    public GameObject m_Start = null;

    [Header("終了位置オブジェクト")]
    public GameObject m_End = null;

    [Header("手オブジェクト")]
    public List<GameObject> m_Hands = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        foreach(var Hand in m_Hands)//全ての手オブジェクトにスタートとエンドをセット
        {
            Hand.GetComponent<MoveHand>().StartObj = m_Start;
            Hand.GetComponent<MoveHand>().EndObj = m_End;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveStart(int value)//HandのActiveをtrueに
    {
        m_Hands[value].GetComponent<MoveHand>().isActive = true;
    }

    
}
