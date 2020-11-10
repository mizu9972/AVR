using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float time;
    public float up_posi;
    public float down_posi;
    float up_time;
    float down_time;
    bool move = true;
    // Start is called before the first frame update
    public float nowPosi;

    void Start()
    {
        nowPosi = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, nowPosi + Mathf.PingPong(Time.time, 1.0f), transform.position.z);
    }
}
