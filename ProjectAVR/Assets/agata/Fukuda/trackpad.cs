using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class trackpad : MonoBehaviour
{
    private SteamVR_Action_Vector2 TrackPad = SteamVR_Actions.default_TrackPad;

    private Vector2 pos;

    float r, sita;

    [SerializeField]
    float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = TrackPad.GetLastAxis(SteamVR_Input_Sources.RightHand);
        //transform.localPosition = new Vector3(pos.x, 0, pos.y);

        r = Mathf.Sqrt(pos.x * pos.x + pos.y * pos.x);
        sita = Mathf.Atan2(pos.y, pos.x) / Mathf.PI * 180;

        
        //💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩

        Vector3 kakudo = new Vector3(pos.x,0,pos.y) ;

        Vector3 maware = Quaternion.Euler(kakudo) * Vector3.forward;

        //入力範囲くそ狭いのにシビアかも💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩

        /* 💩💩💩💩💩💩💩💩💩💩💩💩使い方💩💩💩💩💩💩💩💩💩💩💩💩
         
         
            Say!（Yeah!） 

            ほら その顔上げて　みんなで手を取れば 

            （Fuwa、Fuwa、Fuwa、Fuwa） 
            Dive!（Foo!）まだまだ道の途中 世界を越えよう  

            （せーのっ!） 

            Say!（Yeah!） 

            ほら 推しお仕事も止まらない 全力ですから！ 

            （Fuwa、Fuwa、Fuwa、Fuwa、Foo!） 

            夢を書きかえたら 追いかけ続けよう 

            ともに（はい!）繋ぐ（はい!） 

            ファンファーレ（Go!）  
         */





        if (r > 0.1)
        {
   
            transform.position += -kakudo * speed * Time.deltaTime;

           
            Debug.Log(maware);
            Debug.Log(kakudo);
        }
        //💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩💩

    }

}
