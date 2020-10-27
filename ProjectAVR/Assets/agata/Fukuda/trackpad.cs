using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class trackpad : MonoBehaviour
{
    private SteamVR_Action_Vector2 TrackPad = SteamVR_Actions.default_TrackPad;

    private Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = TrackPad.GetLastAxis(SteamVR_Input_Sources.RightHand);
        transform.localPosition = new Vector3(pos.x * 0.1f, 0, pos.y * 0.1f);
    }
}
