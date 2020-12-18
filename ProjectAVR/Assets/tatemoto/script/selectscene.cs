using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectscene : MonoBehaviour
{
    public GameObject camera;
    public int selectNo1;
    public int selectNo2;
    public int selectNo3;
    public int selectNo4;
    public int selectNo5;
    public int selectNo6;
    private move_Player move;
    public Vector3 endpo; 
    // Start is called before the first frame update
    void Start()
    {
        move = camera.GetComponent<move_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FlagManager.Instance.flags[selectNo1])
        {
            endpo.x = 5.7f;
            endpo.y = -1.819f;
            endpo.z = -17.21f;
            if(move.endflag)
            {
                endpo.x = 2.28f;
                endpo.y = -1.819f;
                endpo.z = -17.21f;
                FlagManager.Instance.flags[4] = true;
                if (FlagManager.Instance.flags[5])
                {
                    FlagManager.Instance.flags[selectNo4] = true;
                    FlagManager.Instance.flags[selectNo1] = false;
                }
            }
            move.enabled = true;
        }
        else
        {
            if (FlagManager.Instance.flags[selectNo2])
            {
                endpo.x = 7.4f;
                endpo.y = -1.819f;
                endpo.z = -13.37f;
                if (move.endflag)
                {
                    endpo.x = 9.0f;
                    endpo.y = -1.819f;
                    endpo.z = -13.37f;
                    FlagManager.Instance.flags[4] = true;
                    if(FlagManager.Instance.flags[5])
                    {
                        FlagManager.Instance.flags[selectNo5] = true;
                        FlagManager.Instance.flags[selectNo2] = false;
                    }
                }
                move.enabled = true;
            }
            else
            {
                if (FlagManager.Instance.flags[selectNo3])
                {
                    endpo.x = 5.7f;
                    endpo.y = -1.819f;
                    endpo.z = -6.611f;
                    if (move.endflag)
                    {
                        endpo.x = 2.28f;
                        endpo.y = -1.819f;
                        endpo.z = -6.611f;
                        FlagManager.Instance.flags[4] = true;
                        if (FlagManager.Instance.flags[5])
                        {
                            FlagManager.Instance.flags[selectNo6] = true;
                            FlagManager.Instance.flags[selectNo3] = false;
                        }
                    }
                    move.enabled = true;
                }
                else
                {

                }
            }
        }
        move.endPosition = endpo;
    }
}
