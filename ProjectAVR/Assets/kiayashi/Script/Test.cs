using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.UpdateAsObservable().Take(1).
            Subscribe(_ => AudioManager.Instance.PlayMainBGM("BGM_GAMEMAIN", true));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
