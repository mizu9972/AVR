using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tikuon : MonoBehaviour
{
    public float endtime;
    public int flagNo;
    public float irir;
    public float irirpras;
    public float irirmax;
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
            if(FlagManager.Instance.flags[flagNo]==false)
            {
                MainAudioSource.Play();
                irir = 0.0f;
            }
        }
        if(MainAudioSource.time >= endtime)
        {
            MainAudioSource.Stop();
            MainAudioSource.time = 0;
            irir = irir + irirpras;
            if(irirmax<=irir)
            {
                FlagManager.Instance.flags[flagNo] = false;
            }
        }
    }
}
