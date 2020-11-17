using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gomi : MonoBehaviour
{
    public int gomimax = 6;
    public bool gomiflag = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gomimax<=0)
        {
            gomiflag = false;
        }
        if(gomimax==6)
        {
            gomiflag = true;
        }
    }
}
