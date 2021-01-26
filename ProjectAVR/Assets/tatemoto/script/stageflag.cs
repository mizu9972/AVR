using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageflag : MonoBehaviour
{
    public bool stage1 = false;
    public bool stage2 = false;
    public bool stage3 = false;
    public int flagNo = 127;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(stage3)
        {
            FlagManager.Instance.flags[flagNo] = false;
        }
    }
}
