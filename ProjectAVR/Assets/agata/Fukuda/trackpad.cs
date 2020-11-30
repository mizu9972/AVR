using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class trackpad : MonoBehaviour
{
    private SteamVR_Action_Vector2 TrackPad = SteamVR_Actions.default_TrackPad;

    private Vector2 pos;

    [SerializeField ]private Camera camera;
    float r, sita;

    [SerializeField]
    float speed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        pos = TrackPad.GetLastAxis(SteamVR_Input_Sources.RightHand);
        //transform.localPosition = new Vector3(pos.x, 0, pos.y);

        r = Mathf.Sqrt(pos.x * pos.x + pos.y * pos.x);
        sita = Mathf.Atan2(pos.y, pos.x) / Mathf.PI * 180;


        float input = pos.y;
        Vector3 camerotate = Vector3.Scale(camera.transform.forward, new Vector3(1, 0, 1)).normalized;

        Vector3 moveForward = camerotate * pos.y + camera.transform.right * pos.x;
    


        camerotate = new Vector3(camerotate.x, 0, camerotate.z);
        Vector3 kakudo = new Vector3(pos.x,0,pos.y) ;

        Vector3 maware = Quaternion.Euler(camerotate) * kakudo;  


        if (r > 0.1)
        {
            //transform.position += maware * speed * Time.deltaTime;
            //transform.rotation = Quaternion.LookRotation(moveForward);
            transform.position += moveForward *  speed * Time.deltaTime;
            Debug.Log(maware);
            //Debug.Log(kakudo);
        }
        //💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩

    }

}
