using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gomi : MonoBehaviour
{
    public int gomimax = 100;
    public int MAX=100;
    public bool gomiflag = true;
    public int gomiflagNo;
    // Start is called before the first frame update
    void Start()
    {
        gomimax = GomiCon.gomi[gomiflagNo];
    }

    // Update is called once per frame
    void Update()
    {
        if(gomimax<=0)
        {
            gomiflag = false;
        }
        if(gomimax>=MAX)
        {
            gomiflag = true;
        }
        GomiCon.gomi[gomiflagNo] = gomimax;
    }
}
