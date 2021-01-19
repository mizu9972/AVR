﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outlines : MonoBehaviour
{
    public int flagNo = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FlagManager.Instance.flags[flagNo] == true)
        {
            var childsTrans = GetComponentsInChildren<Transform>();

            foreach(var itr in childsTrans)
            {
                itr.gameObject.layer = 9;
            }
            this.gameObject.layer = 9;
        }
        else
        {
            this.gameObject.layer = 0;
        }
    }
    
}
