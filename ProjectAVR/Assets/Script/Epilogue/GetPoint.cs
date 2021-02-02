using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_PointObj = new GameObject[10];
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPointObj(int arraynum)
    {
        return m_PointObj[arraynum];
    }

    public void SetPosition(int arraynum,Vector3 pos)
    {
        m_PointObj[arraynum].transform.localPosition = pos;
    }
}
