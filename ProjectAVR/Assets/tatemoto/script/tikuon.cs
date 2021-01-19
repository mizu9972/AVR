using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tikuon : MonoBehaviour
{
    public float endtime;
    public int flagNo;
    public int flagNo_end;
    private int time = 0;
    public int gameover_time;
    [SerializeField]
    private AudioSource MainAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MainAudioSource.time==0)
        {
            if(FlagManager.Instance.flags[flagNo]==true)
            {
                MainAudioSource.Play();
                FlagManager.Instance.flags[flagNo] = false;
            }
            time++;
        }
        if(MainAudioSource.time >= endtime)
        {
            MainAudioSource.Stop();
            MainAudioSource.time = 0;
        }
        if(gameover_time * 30 <= time)
        {
            FlagManager.Instance.flags[flagNo_end] = true;
        }
    }
}
