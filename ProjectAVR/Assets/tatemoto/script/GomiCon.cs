using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomiCon : MonoBehaviour
{
    public static int[] gomi = new int[50];
    public int gomipara;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<50;i++)
        {
            gomi[i] = gomipara;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}