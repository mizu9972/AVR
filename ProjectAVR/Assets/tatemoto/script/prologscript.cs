using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prologscript : MonoBehaviour
{
    public GameObject cap;
    public GameObject yogo;
    public GameObject moveing;
    public bool endflag = false;
    // Start is called before the first frame update
    void Start()
    {
        FlagManager.Instance.ResetFlags();
    }

    // Update is called once per frame
    void Update()
    {
        if (FlagManager.Instance.flags[0]==true)
        {
            if (FlagManager.Instance.flags[1] == false)
            {
                cap.transform.rotation = Quaternion.Euler(45, 0, 0);
                yogo.SetActive(true);
                FlagManager.Instance.flags[1] = true;
            }
        }
        endflag = yogo.GetComponent<gomi>().gomiflag;
        if (endflag == false)
        {
            FlagManager.Instance.flags[4] = true;
            FlagManager.Instance.flags[3] = false;
        }
        if (FlagManager.Instance.flags[4] == true)
        {
            moveing.SetActive(true);
        }
        if (FlagManager.Instance.flags[5] == true)
        {
            FlagManager.Instance.flags[3] = false;
            FlagManager.Instance.flags[6] = true;
        }
        else
        {
            FlagManager.Instance.flags[6] = false;
        }
        if (FlagManager.Instance.flags[5] == false && FlagManager.Instance.flags[0] == true)
        {
            FlagManager.Instance.flags[3] = true;
        }
    }
}
