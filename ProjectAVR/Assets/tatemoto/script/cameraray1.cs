﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraray1 : MonoBehaviour
{
    public GameObject camera;
    public GameObject hitobj;
    public float radius;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray=new Ray(camera.transform.position, camera.transform.forward);
        if(Physics.SphereCast(ray, radius, out hit))
        {
            if(hit.collider.gameObject==hitobj)
            {
                FlagManager.Instance.flags[0] = true;
            }
            else
            {
                FlagManager.Instance.flags[0] = false;
            }
        }
    }
}
