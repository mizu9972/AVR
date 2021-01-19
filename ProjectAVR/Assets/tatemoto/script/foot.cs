using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foot : MonoBehaviour
{
    public GameObject SeSoundBox;
    public float oko;
    private int time;
    public int max;
    public int flagno;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FlagManager.Instance.flags[flagno])
        {
            if(time==0)
            {
                SeSoundBox.GetComponent<PlaySe>().PlaySound(1);
            }
            if(time==max/2)
            {
                SeSoundBox.GetComponent<PlaySe>().PlaySound(0);
            }
            time++;
            if (time >= max)
            {
                time = 0;
            }
        }
        else
        {
            time = 0;
        }
    }
}
