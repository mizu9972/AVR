using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsound : MonoBehaviour
{
    public AudioClip audioClip1;
    private AudioSource audioSource;
    public int flagno;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
    }

    // Update is called once per frame
    void Update()
    {
        if(FlagManager.Instance.flags[30])
        {
            if(audioSource.time==0)
            {
                audioSource.Play();
                FlagManager.Instance.flags[30] = false;
            }
        }
    }
}
