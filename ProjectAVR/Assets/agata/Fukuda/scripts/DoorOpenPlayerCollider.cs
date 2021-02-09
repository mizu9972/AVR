using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorOpenPlayerCollider : MonoBehaviour
{

    [SerializeField]
    [Header("ドア開けるFlag番号設定してね")]
    private int Flag = 7;

    [SerializeField]
    private GameObject player;
  


    void Start()
    {
        FlagManager.Instance.flags[Flag] = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(FlagManager.Instance.flags[Flag])
        {
            player.GetComponent<CapsuleCollider>().enabled = false;
           
        }
        else
        {
            player.GetComponent<CapsuleCollider>().enabled = true;
        }
    }
}
