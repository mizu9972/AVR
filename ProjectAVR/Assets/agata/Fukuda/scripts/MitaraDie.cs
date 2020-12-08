using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MitaraDie : MonoBehaviour
{

    [SerializeField]
    [Header("死ぬまでの時間だ")]
    private float YouDeadTime = 10;

    [SerializeField]
    [Header("見てるフラグのenum番号設定してね")]
    private int LookFlag = 10;

    [SerializeField]
    [Header("死ぬフラグのenum番号設定してね")]
    private int DieFlag = 11;


    private float YouDeadTimeRetention;
    private float timekun;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timekun -= Time.deltaTime;

        //1秒
        if(timekun <= 0.0f)
        {
            timekun = 1.0f;
            if (FlagManager.Instance.flags[LookFlag] == true)
            {
                YouDeadTimeRetention += 1.0f;
            }

        }


        if(YouDeadTimeRetention >= YouDeadTime)
        {
            //死ぬフラグオン
            FlagManager.Instance.flags[DieFlag] = true;
        }

    }
}
