using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndrollBGM : MonoBehaviour
{
    public PlayBgm m_playBgm = null;
    // Start is called before the first frame update
    void Start()
    {
        m_playBgm.StartBgm();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float val)
    {
        m_playBgm.Volume = val;
    }
}
