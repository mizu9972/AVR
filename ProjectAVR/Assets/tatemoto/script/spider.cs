using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider : MonoBehaviour
{
    public GameObject spiders;
    public int hpmax = 100;
    public bool hpflag = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hpmax <= 0)
        {
            hpflag = false;
            Destroy(spiders);
        }
        if (hpmax == 100)
        {
            hpflag = true;
        }
    }
}
