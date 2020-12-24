using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tikuon : MonoBehaviour
{
    public float endtime;
    public int flagNo;
    public int flagNo_irir;
    public int flagNo_end;
    public float irir;
    public float irirpras;
    public float irirmax;
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
                irir = 0.0f;
                FlagManager.Instance.flags[flagNo] = false;
            }
            time++;
        }
        if(MainAudioSource.time >= endtime)
        {
            MainAudioSource.Stop();
            MainAudioSource.time = 0;
            irir = irir + irirpras;
        }
        if (irirmax <= irir)
        {
            FlagManager.Instance.flags[flagNo_irir] = true;
        }
        if(gameover_time<=time*30)
        {
            FlagManager.Instance.flags[flagNo_end] = true;
        }
    }
}
